using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

using ZedGraph;

namespace NeuralNetTrainer
{
    public partial class ResilientBackpropagationLearningForm : Form
    {

        public double[][] input;
        public double[][] output;
        public static double[] signaldata = new double[1000];
        public static List<int> gerrror = new List<int>();
        public static List<float> chartdata = new List<float>();
        public static float[] gdata = new float[1000];
        public double[,] chartv = new double[1000, 1000];
        public ActivationNetwork network;
        public ResilientBackpropagationLearning teacher;
        public static Boolean work = false;
        public static Boolean logger = false;
        public static Boolean signal = false;
        public static string error = null;
        public Error_Logger logg;
        public Accord.Controls.Wavechart chart;
        public static Stopwatch watch;
        public GraphPane myPane;
        public PointPairList listPointsOne;
        public LineItem myCurveOne;

        public ResilientBackpropagationLearningForm()
        {
            InitializeComponent();
            
            watch = new Stopwatch();

            backgroundWorkerTrainer.Disposed += backgroundWorkerTrainer_Disposed;
            backgroundWorkerTrainer.DoWork += backgroundWorkerTrainer_DoWork;
            backgroundWorkerTrainer.ProgressChanged += backgroundWorkerTrainer_ProgressChanged;
            backgroundWorkerTrainer.WorkerSupportsCancellation = true;
            backgroundWorkerTrainer.WorkerReportsProgress = true;
            saveFileDialog1.Filter = "Resilient network files (*.rbn)|*.rbn";
            saveFileDialog1.Title = "Save Resilient network file";
            saveFileDialog1.InitialDirectory = null;
            saveFileDialog1.FileName = null;

            openFileDialog1.Filter = "Resilient network files (*.rbn)|*.rbn";
            openFileDialog1.Title = "Load Resilient network file";
            openFileDialog1.InitialDirectory = null;
            openFileDialog1.FileName = null;

            backgroundWorkerSignal.Disposed += backgroundWorkerSignal_Disposed;
            backgroundWorkerSignal.WorkerSupportsCancellation = true;
            backgroundWorkerSignal.WorkerReportsProgress = true;
            backgroundWorkerSignal.DoWork += backgroundWorkerSignal_DoWork;
            backgroundWorkerSignal.RunWorkerCompleted += backgroundWorkerSignal_RunWorkerCompleted;


            // initialize input and output values
            input = new double[4][] {
                new double[] {0, 0}, new double[] {0, 1},
                new double[] {1, 0}, new double[] {1, 1}
            };
            output = new double[4][] {
                new double[] {0}, new double[] {1},
                new double[] {1}, new double[] {0}
            };

            network = new ActivationNetwork(new SigmoidFunction(2), 2, 2, 1);

            teacher = new  ResilientBackpropagationLearning(network);

            //logg.Show();

            // pane used to draw your chart
            myPane = new GraphPane();

            // poing pair lists
            listPointsOne = new PointPairList();
        }


        void backgroundWorkerSignal_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void backgroundWorkerSignal_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rnd = new Random();
            int i = 0;
            while (signal)
            {

                if (i == signaldata.Length)
                {
                    i = 0;
                    //SetTextGraph(chartv);
                }
                signaldata[i] = rnd.NextDouble();
                chartv[i, 0] = i;
                chartv[i, 1] = signaldata[i];
                SetText(signaldata[i].ToString());
                i++;

            }
        }

        void backgroundWorkerSignal_Disposed(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void logg_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger = false;
        }

        void backgroundWorkerTrainer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void backgroundWorkerTrainer_DoWork(object sender, DoWorkEventArgs e)
        {
            while (work)
            {
                // run epoch of learning procedure
                double error = teacher.RunEpoch(input, output);
                // check error value to see if we need to stop
                // ...

                var c = error * 10;
                var d = c.ToString();
                gerrror.Add(Convert.ToInt32(c));

                SetText(error.ToString());
                chartdata.Add(Convert.ToSingle(c));
                listPointsOne.Add((double)watch.ElapsedMilliseconds, error);
                axisChangeZedGraph(zedGraphControl1);
                Thread.Sleep(2);
                if (logger)
                {
                    SetTextLogger(error.ToString());

                }
                if (watch.IsRunning)
                {
                    SetTextTime(watch.ElapsedMilliseconds.ToString());
                }

            }
        }

        void backgroundWorkerTrainer_Disposed(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BackPropogation_Load(object sender, EventArgs e)
        {
            // set your pane
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = null;
            var r = saveFileDialog1.ShowDialog();
            if (r != System.Windows.Forms.DialogResult.Cancel)
            {
                if (File.Exists(saveFileDialog1.FileName))
                {
                    var f = MessageBox.Show(this, "File already exixt do you want to overwrite it?", "Alert", MessageBoxButtons.YesNo);
                    if (f == System.Windows.Forms.DialogResult.Yes)
                    {
                        network.Save(saveFileDialog1.FileName);

                        saveFileDialog1.FileName = null;

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    network.Save(saveFileDialog1.FileName);

                    saveFileDialog1.FileName = null;
                }

            }
        }

        private void loadfile(object sender, EventArgs e)
        {

            var r = openFileDialog1.ShowDialog();
            if (r != System.Windows.Forms.DialogResult.Cancel)
            {
                try
                {
                    var n = Network.Load(openFileDialog1.FileName);
                    network = n as ActivationNetwork;
                }
                catch (Exception eg)
                {
                    MessageBox.Show("Error occured!");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (backgroundWorkerTrainer.IsBusy == false)
            {
                backgroundWorkerTrainer.RunWorkerAsync();
                work = true;
                watch.Start();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerTrainer.CancelAsync();
                backgroundWorkerTrainer.Dispose();
                work = false;
                watch.Stop();
            }
            catch
            {

            }

        }




        #region delegates
        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {

                SetTextCallback d = new SetTextCallback(SetText);
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
                this.textBox1.Text = text;
            }
        }


        //delegate void SetTextG(float[] data);

        //private void SetG(float[] data)
        //{

        //    if (chart.InvokeRequired)
        //    {

        //        SetTextG d = new SetTextG(SetG);
        //        this.Invoke(d, new object[] { data });


        //    }
        //    else
        //    {


        //        chart.UpdateWaveform("Error", data);

        //    }
        //}

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
                zg.AxisChange();
                zg.Invalidate();
                zg.Refresh();
            }
        }


        delegate void SetTextCallbackTime(string text);

        private void SetTextTime(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox6.InvokeRequired)
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
                this.textBox6.Text = text;
            }
        }



        delegate void SetTextCallbackLogger(string text);

        private void SetTextLogger(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (logg.textBox1.Enabled)
            {
                if (this.logg.InvokeRequired)
                {

                    SetTextCallbackLogger d = new SetTextCallbackLogger(SetTextLogger);
                    this.Invoke(d, new object[] { text });

                }
                else
                {
                    if (logger && logg.button2.Enabled)
                    {
                        this.logg.textBox1.AppendText(text + Environment.NewLine);
                    }
                }
            }
        }

        //delegate void SetTextCallbackGraph(double[,] gdata);

        //private void SetTextGraph(double[,] gdata)
        //{
        //    // InvokeRequired required compares the thread ID of the
        //    // calling thread to the thread ID of the creating thread.
        //    // If these threads are different, it returns true.
        //    try
        //    {
        //        if (this.chart1.InvokeRequired)
        //        {

        //            SetTextCallbackGraph d = new SetTextCallbackGraph(SetTextGraph);
        //            this.Invoke(d, new object[] { gdata });

        //        }
        //        else
        //        {

        //            chart1.UpdateDataSeries("Values", gdata);


        //        }
        //    }
        //    catch
        //    {

        //    }

        //}


        delegate void SetTextCallbackErrorGraph(List<int> errordata);

        private void SetTexErrortGraph(List<int> errordata)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (zedGraphControl1.InvokeRequired)
            {

                SetTextCallbackErrorGraph d = new SetTextCallbackErrorGraph(SetTexErrortGraph);
                this.Invoke(d, new object[] { errordata });

            }
            else
            {




            }

        }


        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            if (logger == false)
            {
                logg = new Error_Logger();
                logg.FormClosing += logg_FormClosing;
                logg.Show();
                logger = true;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //if (!backgroundWorkerTrainer.IsBusy)
            //{
            //    try
            //    {
            //        double[] input = { double.Parse(textBox2.Text), double.Parse(textBox3.Text) };
            //        double[] output = network.Compute(input);
            //        MessageBox.Show(output[0].ToString());
            //    }
            //    catch (Exception k)
            //    {
            //        MessageBox.Show(k.Message);
            //    }
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorkerSignal.IsBusy)
                {
                    backgroundWorkerSignal.RunWorkerAsync();
                    signal = true;
                }
            }
            catch
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerSignal.IsBusy)
            {
                try
                {
                    backgroundWorkerSignal.CancelAsync();
                    signal = false;
                }
                catch
                {

                }
            }
        }

        private void ResilientBackpropagationLearningForm_Load(object sender, EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;

            // set a title
            myPane.Title.Text = "Error VS Time";

            // set X and Y axis titles
            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = "Error";
            myCurveOne = myPane.AddCurve(null, listPointsOne, Color.Red, SymbolType.None);
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = null;
            var r = saveFileDialog1.ShowDialog();
            if (r != System.Windows.Forms.DialogResult.Cancel)
            {
                if (File.Exists(saveFileDialog1.FileName))
                {
                    var f = MessageBox.Show(this, "File already exixt do you want to overwrite it?", "Alert", MessageBoxButtons.YesNo);
                    if (f == System.Windows.Forms.DialogResult.Yes)
                    {
                        network.Save(saveFileDialog1.FileName);

                        saveFileDialog1.FileName = null;

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    network.Save(saveFileDialog1.FileName);

                    saveFileDialog1.FileName = null;
                }

            }
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = openFileDialog1.ShowDialog();
            if (r != System.Windows.Forms.DialogResult.Cancel)
            {
                try
                {
                    var n = Network.Load(openFileDialog1.FileName);
                    network = n as ActivationNetwork;
                }
                catch (Exception eg)
                {
                    MessageBox.Show("Error occured!");

                }

            }
        }

        private void sTARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerTrainer.IsBusy == false)
            {
                backgroundWorkerTrainer.RunWorkerAsync();
                work = true;
                watch.Start();
            }
        }

        private void sTOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerTrainer.CancelAsync();
                backgroundWorkerTrainer.Dispose();
                work = false;
                watch.Stop();
            }
            catch
            {

            }
        }

        private void oPENERRORLOGGERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logger == false)
            {
                logg = new Error_Logger();
                logg.FormClosing += logg_FormClosing;
                logg.Show();
                logger = true;
            }
        }

        private void sTARTToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void sTOPToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sTARTToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            //if (!backgroundWorkerTrainer.IsBusy)
            //{
            //    try
            //    {
            //        double[] input = { double.Parse(textBox2.Text), double.Parse(textBox3.Text) };
            //        double[] output = network.Compute(input);
            //        MessageBox.Show(output[0].ToString());
            //    }
            //    catch (Exception k)
            //    {
            //        MessageBox.Show(k.Message);
            //    }
            //}
        }

        private void sTOPToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void rANDOMIZEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cREATEERRORLOGFILEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aPPENDTOERRORLOGFILEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lOADTEMPLATEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
