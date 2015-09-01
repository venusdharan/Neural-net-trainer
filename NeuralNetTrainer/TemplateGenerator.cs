using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ThinkGearNET;
using ZedGraph;


using AForge;
using AForge.Controls;
using AForge.Fuzzy;
using AForge.Genetic;
using AForge.MachineLearning;
using AForge.Math;
using AForge.Math.Geometry;
using AForge.Math.Metrics;
using AForge.Math.Random;
using AForge.Neuro;
using AForge.Neuro.Learning;
using System.IO;
using System.Threading;
using System.Diagnostics;


using Accord;
using Accord.Audio;
using Accord.Audio.ComplexFilters;
using Accord.Audio.Filters;
using Accord.Audio.Formats;
using Accord.Audio.Generators;
using Accord.Audio.Windows;
using Accord.Audition;
using Accord.Audition.Beat;
using Accord.Controls;
using Accord.Controls.Vision;
using Accord.DirectSound;
using Accord.Imaging;
using Accord.Imaging.Converters;
using Accord.Imaging.Filters;
using Accord.Imaging.Moments;
using Accord.MachineLearning;
using Accord.MachineLearning.Bayes;
using Accord.MachineLearning.Boosting;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.Geometry;
using Accord.MachineLearning.Structures;
using Accord.MachineLearning.VectorMachines;
using Accord.Math;
using Accord.Math.Comparers;
using Accord.Math.ComplexExtensions;
using Accord.Math.Decompositions;
using Accord.Math.Differentiation;
using Accord.Math.Environments;
using Accord.Math.Geometry;
using Accord.Math.Kinematics;
using Accord.Math.Optimization;
using Accord.Math.Wavelets;
using Accord.Neuro;
using Accord.Neuro.ActivationFunctions;
using Accord.Neuro.Layers;
using Accord.Neuro.Learning;
using Accord.Neuro.Networks;
using Accord.Neuro.Neurons;
using Accord.Neuro.Visualization;



namespace NeuralNetTrainer
{
    public partial class TemplateGenerator : Form
    {
        public float meditationvar;
        public float attentionvar;
        public string meditationstring;
        public string attentionstring;

        public static bool start = false;
        public double[,] chartv = new double[1024, 1024];
        public static double val = 0;
        public ThinkGearWrapper tw = new ThinkGearWrapper();
        public GraphPane myPane;
        public PointPairList listPointsOne;
        public LineItem myCurveOne;
        public static List<float> chartdata = new List<float>();
        public static Stopwatch watch1;
        //double now = Environment.TickCount / 1000.0;

        public static float[] testValues = new float[128];


        Wavechart chart = new Wavechart();
        public TemplateGenerator()
        {
            watch1 = new Stopwatch();
            //panel2.Controls.Add(chart);
            //chart.Dock = DockStyle.Fill;
            InitializeComponent();
            tw.ThinkGearChanged += tw_ThinkGearChanged;
            tw.EnableBlinkDetection(true);
            
            backgroundWorker1.WorkerSupportsCancellation = true;
            myPane = new GraphPane();
            listPointsOne = new PointPairList();

            myPane = zedGraphControl1.GraphPane;

            // set a title
            myPane.Title.Text = "Error VS Time";

            // set X and Y axis titles
            myPane.XAxis.Title.Text = "Time in Milliseconds";
            myPane.YAxis.Title.Text = "Error";
            myCurveOne = myPane.AddCurve("Learning curve", listPointsOne, Color.Red, SymbolType.None);
            //double xRange = myPane.XAxis.Scale.Max - myPane.XAxis.Scale.Min;
            //myPane.XAxis.Scale.Max = new XDate(DateTime.Now);
            //myPane.XAxis.Scale.Min = myPane.XAxis.Scale.Max - xRange;
            //zedGraphControl1.IsShowHScrollBar = true;
            //zedGraphControl1.IsSynchronizeXAxes = true;

            //// add new waveform to the chart
            //chart.AddWaveform("Test", Color.DarkGreen, 3);
            // update the chart
            //for (int i = 0; i < 128; i++)
            //{
            //    testValues[i] = Convert.ToSingle(Math.Sin(i / 18.0 * Math.PI));
            //}
            // add new waveform to the chart
            chart.AddWaveform("Test", Color.DarkGreen, 1);
            // update the chart
           // chart.UpdateWaveform("Test", testValues);
            


        }

        void tw_ThinkGearChanged(object sender, ThinkGearChangedEventArgs e)
        {
            //throw new NotImplementedException();
            val = (double) e.ThinkGearState.Raw;

            SetTextTime(e.ThinkGearState.BlinkStrength.ToString());
            
            
        }

        delegate void SetTextCallbackTime(string text);

        private void SetTextTime(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.label2.InvokeRequired)
            {

                SetTextCallbackTime d = new SetTextCallbackTime(SetTextTime);
                try
                {
                    this.Invoke(d, new object[] { text });
                }
                catch
                {

                }
            }
            else
            {
                this.label2.Text = text;
            }
        }


        delegate void SetTextgraph(float[] g);

        private void SetTextg(float[] g)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.chart.InvokeRequired)
            {

                SetTextgraph d = new SetTextgraph(SetTextg);
                try
                {
                    this.Invoke(d, new object[] { g });
                }
                catch
                {

                }
            }
            else
            {
                chart.UpdateWaveform("Test",g);
            }
        }


        private void TemplateGenerator_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var ports = SerialPort.GetPortNames();
            foreach(string s in ports)
            {
                comboBox1.Items.Add(s);

            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var ports = SerialPort.GetPortNames();
            foreach (string s in ports)
            {
                comboBox1.Items.Add(s);

            }
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!tw.Connect(comboBox1.SelectedItem.ToString(), 57600, true))
            {
                MessageBox.Show("Could not connect to headset.");
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
                start = true;
                watch1.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                tw.Disconnect();
                start = false;
                backgroundWorker1.CancelAsync();
                watch1.Stop();
            }
            catch
            { }
        }


        delegate void SetTextCallbackPanel(Color c);

        private void SetTextPanel(Color c)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            try
            {
                if (this.panel1.InvokeRequired)
                {

                    SetTextCallbackPanel d = new SetTextCallbackPanel(SetTextPanel);
                    this.Invoke(d, new object[] { c });

                }
                else
                {

                    panel1.BackColor = c;


                }
            }
            catch
            {

            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (start)
            {

                if(listPointsOne.ToArray().Length == 511)
                {
                    
                    listPointsOne.Clear();
                }
                if(i < 127)
                {
                    
                    testValues[i] = Convert.ToSingle(val);
                    
                }
                if(i == 127)
                {
                    i = 0;
                    SetTextg(testValues);
                }
                
                listPointsOne.Add((double)watch1.ElapsedMilliseconds, val);
                axisChangeZedGraph(zedGraphControl1);
                i++;
                val = 0;
                Thread.Sleep(10);

            }
        }


        delegate void axisChangeZedGraphCallBack(ZedGraphControl zg);
        private void axisChangeZedGraph(ZedGraphControl zg)
        {
            if (zg.InvokeRequired)
            {
                axisChangeZedGraphCallBack ad = new axisChangeZedGraphCallBack(axisChangeZedGraph);
                zg.Invoke(ad, new object[] { zg });
            }
            else
            {
                //double xRange = myPane.XAxis.Scale.Max - myPane.XAxis.Scale.Min;
                //myPane.XAxis.Scale.Max = watch1.ElapsedMilliseconds;
                //myPane.XAxis.Scale.Min = myPane.XAxis.Scale.Max - xRange;
                zg.AxisChange();
                zg.Invalidate();
                zg.Refresh();
            }
        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            myPane.CurveList.Remove(myCurveOne);
            zedGraphControl1.Refresh();
            myCurveOne.Clear();
            listPointsOne.Clear();
            myCurveOne = myPane.AddCurve("Back Propagation", listPointsOne, Color.Red, SymbolType.None);
            //myCurveOne = myPane.AddCurve("Resilient Back Propagation", listPointstwo, Color.Green, SymbolType.None);
            //myCurveOne = myPane.AddCurve("Genetic Learning", listPointsthree, Color.Blue, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.PerformAutoScale();
            zedGraphControl1.ResetText();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
