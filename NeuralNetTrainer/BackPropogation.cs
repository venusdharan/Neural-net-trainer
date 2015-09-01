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



using ZedGraph;
using System.Net.Sockets;
using System.Net;

namespace NeuralNetTrainer
{
    public partial class BackPropogation : Form
    {
        public double[][] input = new double[1][];
        public double[][] output = new double[1][];
        public static double[] signaldata = new double[1000];
        public static List<int> gerrror = new List<int>();
        public static List<float> chartdata = new List<float>();
        public static float[] gdata = new float[1000];
        public double[,] chartv = new double[1000,1000];
        public ActivationNetwork network1;
        public ActivationNetwork network2;
        public ActivationNetwork network3;
        public ActivationNetwork network4;
        public ActivationNetwork network5;
        public ActivationNetwork network6;
        public BackPropagationLearning teacher;
        public EvolutionaryLearning evteacher;
        public ResilientBackpropagationLearning reprop;
        public LevenbergMarquardtLearning lbteacher;
        public DeltaRuleLearning delta;
        public PerceptronLearning perceptron;
        public static Boolean work = false;
        public static Boolean logger = false;
        public static Boolean signal = false;
        public static string error = null;
        public  Error_Logger logg;
        public Accord.Controls.Wavechart chart;
        public static Stopwatch watch1;
        public static Stopwatch watch2;
        public static Stopwatch watch3;
        public GraphPane myPane;
        public PointPairList listPointsOne;
        public PointPairList listPointstwo;
        public PointPairList listPointsthree;
        public LineItem myCurveOne;
        public string template = null;
        public bool ServerStared = false;
        public bool SessionStared = false;
        public bool RecoStarted = false;
        public bool LearningStared = false;
        
        public Socket Client;
        public static int selected_algorythm = 0;
        public static int selected_algorythm_recog = 0;
        public static int sleeptime = 0;
        public static int sleeptime_recog = 0;

        public static int param1 = 0;
        public static int param2 = 0;
        public static int param3 = 0;
        public static int param4 = 0;
        public static int param5 = 0;



        public ActivationNetwork activation_nework;

        public BackPropogation()
        {
            InitializeComponent();

            activation_nework = new ActivationNetwork(new BipolarSigmoidFunction(), 50, 50,  10, 1);

            watch1 = new Stopwatch();

            watch2 = new Stopwatch();

            watch3 = new Stopwatch();

            backgroundWorkerTrainer.Disposed += backgroundWorkerTrainer_Disposed;
            backgroundWorkerTrainer.DoWork += backgroundWorkerTrainer_DoWork;
            backgroundWorkerTrainer.ProgressChanged += backgroundWorkerTrainer_ProgressChanged;
            backgroundWorkerTrainer.WorkerSupportsCancellation = true;
            backgroundWorkerTrainer.WorkerReportsProgress = true;
            saveFileDialog1.Filter = "feed forward network files (*.ffn)|*.ffn";
            saveFileDialog1.Title = "Save neural networkfile";
            saveFileDialog1.InitialDirectory = null;
            saveFileDialog1.FileName = null;

            openFileDialog1.Filter = "feed forward network files (*.ffn)|*.ffn";
            openFileDialog1.Title = "Load neural network file";
            openFileDialog1.InitialDirectory = null;
            openFileDialog1.FileName = null;

            backgroundWorkerSignal.Disposed += backgroundWorkerSignal_Disposed;
            backgroundWorkerSignal.WorkerSupportsCancellation = true;
            backgroundWorkerSignal.WorkerReportsProgress = true;
            backgroundWorkerSignal.DoWork += backgroundWorkerSignal_DoWork;
            backgroundWorkerSignal.RunWorkerCompleted += backgroundWorkerSignal_RunWorkerCompleted;//80, 70, 60, 50, 40,
            network1 = activation_nework;
            network2 = activation_nework; // new ActivationNetwork(new BipolarSigmoidFunction(), 50, 50, 40, 1);
            network3 = activation_nework; // new ActivationNetwork(new BipolarSigmoidFunction(), 50, 50, 40, 1);
            network4 = activation_nework; // new ActivationNetwork(new BipolarSigmoidFunction(), 50, 50, 40, 1);
            network5 = new ActivationNetwork(new BipolarSigmoidFunction(), 50,1);
            network6 = new ActivationNetwork(new BipolarSigmoidFunction(), 50, 1);
            teacher = new BackPropagationLearning(network1);
            evteacher = new EvolutionaryLearning(network2, 100);
            reprop = new ResilientBackpropagationLearning(network3);
            lbteacher = new LevenbergMarquardtLearning(network4);
            delta = new DeltaRuleLearning(network5);
            perceptron = new PerceptronLearning(network6);
            delta.LearningRate = 1;
            perceptron.LearningRate = 0.1;
            myPane = new GraphPane();
            listPointsOne = new PointPairList();
            
            myPane = zedGraphControl1.GraphPane;

            // set a title
            myPane.Title.Text = "Error VS Time";

            // set X and Y axis titles
            myPane.XAxis.Title.Text = "Time in Milliseconds";
            myPane.YAxis.Title.Text = "Error";
            myCurveOne = myPane.AddCurve("Learning curve", listPointsOne, Color.Red, SymbolType.None);
           // myCurveOne = myPane.AddCurve("Resilient Back Propagation", listPointstwo, Color.Green, SymbolType.None);
           // myCurveOne = myPane.AddCurve("Genetic Learning", listPointsthree, Color.Blue, SymbolType.None);

            

                 

        }

        void backgroundWorkerSignal_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void backgroundWorkerSignal_DoWork(object sender, DoWorkEventArgs e)
        {
            //byte[] buffer = new byte[102400];
            //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            //IPAddress ipAddress = ipHostInfo.AddressList[0];
            //IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("192.168.25.50"), 399);

            // Create a TCP/IP  socket.

            template = File.ReadAllText("template\\try.fft");
            var c = template.Split(',');
            int i = 0;
            double[] temp = new double[50];
            for (int g = 0; g < 50; g++)
            {
                temp[g] = double.Parse(c[g]);

            }


            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (signal)
            {

                //try {
                //     try {
                //        client .Connect(remoteEP);

                //        Console.WriteLine("Socket connected to {0}",client .RemoteEndPoint.ToString());
                //        byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");
                //        int bytesSent = client .Send(msg);
                //        int bytesRec = client .Receive(buffer);
                //        Console.WriteLine("Echoed test = {0}",Encoding.ASCII.GetString(buffer,0,bytesRec));

                //    } catch (ArgumentNullException ane) {
                //        //notifyIcon1.ShowBalloonTip(1000, "Error", ane.Message, ToolTipIcon.Error);           
                //    } catch (SocketException se) {
                //        //notifyIcon1.ShowBalloonTip(1000, "Error", se.Message, ToolTipIcon.Error);
                //    } catch (Exception el) {
                //       // notifyIcon1.ShowBalloonTip(1000, "Error", el.Message, ToolTipIcon.Error);
                //    }

                //} catch (Exception ek) {
                //    Console.WriteLine( ek.ToString());
                //}


                /*
                 * 
                 * computing the values from the neural network
                 */

                if (selected_algorythm_recog == 0)
                {
                    double[] output = network1.Compute(temp);
                    SetTextValue1(Convert.ToSingle(output[0]) * 10);
                    //SetTextValue2(Convert.ToSingle(output[1]));
                    //SetTextValue3(Convert.ToSingle(output[2]));


                }
                if (selected_algorythm_recog == 1)
                {
                    double[] output = network2.Compute(temp);
                    SetTextValue1(Convert.ToSingle(output[0]) * 10);
                    //SetTextValue2(Convert.ToSingle(output[1]));
                    //SetTextValue3(Convert.ToSingle(output[2]));


                }
                if (selected_algorythm_recog == 2)
                {
                    double[] output = network3.Compute(temp);
                    SetTextValue1(Convert.ToSingle(output[0]) * 10);
                    //SetTextValue2(Convert.ToSingle(output[1]));
                    //SetTextValue3(Convert.ToSingle(output[2]));


                }
                if (selected_algorythm_recog == 3)
                {
                    double[] output = network4.Compute(temp);
                    SetTextValue1(Convert.ToSingle(output[0]) * 10);
                    //SetTextValue2(Convert.ToSingle(output[1]));
                    //SetTextValue3(Convert.ToSingle(output[2]));


                }
                if (selected_algorythm_recog == 4)
                {
                    double[] output = network5.Compute(temp);
                    SetTextValue1(Convert.ToSingle(output[0]) * 10);
                    //SetTextValue2(Convert.ToSingle(output[1]));
                    //SetTextValue3(Convert.ToSingle(output[2]));




                }
                if (selected_algorythm_recog == 5)
                {
                    double[] output = network6.Compute(temp);
                    SetTextValue1(Convert.ToSingle(output[0]) * 10);
                    //SetTextValue2(Convert.ToSingle(output[1]));
                    //SetTextValue3(Convert.ToSingle(output[2]));


                }



                Thread.Sleep(sleeptime_recog / 2);

                SetTextValue1(0);
                //SetTextValue2(0);
                //SetTextValue3(0);
                Thread.Sleep(sleeptime_recog / 2);
                //client.Shutdown(SocketShutdown.Both);
                //client.Close();
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
                double error = 0;
               
                // run epoch of learning procedure
                
                if(selected_algorythm == 0)
                {
                    error = teacher.RunEpoch(input, output);
                    listPointsOne.Add((double)watch1.ElapsedMilliseconds, error);
                }
                if(selected_algorythm == 1)
                {
                    error = reprop.RunEpoch(input, output);
                    listPointsOne.Add((double)watch1.ElapsedMilliseconds, error);
                }
                if(selected_algorythm == 2)
                {
                    error = evteacher.RunEpoch(input, output);
                    listPointsOne.Add((double)watch1.ElapsedMilliseconds, error);
                }
                if (selected_algorythm == 3)
                {
                    error = lbteacher.RunEpoch(input, output);
                    listPointsOne.Add((double)watch1.ElapsedMilliseconds, error);
                }
                if (selected_algorythm == 4)
                {
                    error = delta.RunEpoch(input, output);
                    listPointsOne.Add((double)watch1.ElapsedMilliseconds, error);
                }
                if (selected_algorythm == 5)
                {
                    error = perceptron.RunEpoch(input, output);
                    listPointsOne.Add((double)watch1.ElapsedMilliseconds, error);
                }
                
                // check error value to see if we need to stop
                // ...
             
                var c = error * 10;
                var d = c.ToString();
                //gerrror.Add(Convert.ToInt32(c));

                SetText(error.ToString());
                chartdata.Add(Convert.ToSingle(c));
                
                
                
                axisChangeZedGraph(zedGraphControl1);
                Thread.Sleep(2);
                if (logger)
                {
                    SetTextLogger(error.ToString());
                    
                }
                if(watch1.IsRunning)
                {
                    SetTextTime(watch1.ElapsedMilliseconds.ToString());
                }
                Thread.Sleep(sleeptime);

            }
        }

        void backgroundWorkerTrainer_Disposed(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BackPropogation_Load(object sender, EventArgs e)
        {
            foreach(var items in comboBox1.Items)
            {
                comboBox2.Items.Add(items);
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            // set your pane
            template = File.ReadAllText("template\\template.fft");
            var c = template.Split(',');
            int i = 0;
            double[] temp = new double[50];
            toolStripProgressBar1.Maximum = temp.Length;
            toolStripProgressBar1.Value = 0;
            
            for (int g = 0; g < 50; g++ )
            {
                temp[g] = double.Parse(c[g]);
                toolStripProgressBar1.Value++;
            }
            input[0] = temp;
            SetInput();
            notifyIcon1.ShowBalloonTip(1000, "Welcome", "Template loaded!", ToolTipIcon.Info);

            toolStripStatusLabel1.Text = "Loading necessary files completed!";
           
            
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        
        private void loadfile(object sender, EventArgs e)
        {
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
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


        #region Logger thread acess

        delegate void SetTextCallbackLogger(string text);

        private void SetTextLogger(string text)
        {
            

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
        #endregion

        #region guage value thread acess

        delegate void SetTextCallbackValue1(float val);

        private void SetTextValue1(float val)
        {
         try
            {
                if (this.aquaGauge1.InvokeRequired)
                {

                    SetTextCallbackValue1 d = new SetTextCallbackValue1(SetTextValue1);
                    this.Invoke(d, new object[] { val });

                }
                else
                {

                    aquaGauge1.Value = val;


                }
            }
            catch
            {

            }

        }

        delegate void SetTextCallbackValue2(float val);

        private void SetTextValue2(float val)
        {
            try
            {
                if (this.aquaGauge2.InvokeRequired)
                {

                    SetTextCallbackValue2 d = new SetTextCallbackValue2(SetTextValue2);
                    this.Invoke(d, new object[] { val });

                }
                else
                {

                    aquaGauge2.Value = val;


                }
            }
            catch
            {

            }

        }


        delegate void SetTextCallbackValue3(float val);

        private void SetTextValue3(float val)
        {
            try
            {
                if (this.aquaGauge3.InvokeRequired)
                {

                    SetTextCallbackValue3 d = new SetTextCallbackValue3(SetTextValue3);
                    this.Invoke(d, new object[] { val });

                }
                else
                {

                    aquaGauge3.Value = val;


                }
            }
            catch
            {

            }

        }


        

        

        #endregion

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
           
           

        }

        private void button6_Click(object sender, EventArgs e)
        {
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
            if(backgroundWorkerSignal.IsBusy)
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

        private void BackPropogation_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void BackPropogation_ResizeEnd(object sender, EventArgs e)
        {

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
                        network1.Save(saveFileDialog1.FileName);

                        saveFileDialog1.FileName = null;

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    network1.Save(saveFileDialog1.FileName);

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
                    network1 = n as ActivationNetwork;
                }
                catch (Exception eg)
                {
                    MessageBox.Show("Error occured!");

                }

            }
        }

        private void sTARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripStatusLabel1.Text = "Session started";
        }

        private void sTOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = "Session stopped";
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
            comboBox1.Enabled = false;
            //if(network1.Equals(null) )
            //{
                
            //}
            if (backgroundWorkerTrainer.IsBusy == false)
            {
                SetInput();
                backgroundWorkerTrainer.RunWorkerAsync();
                work = true;
                watch1.Start();
                rANDOMIZEToolStripMenuItem.Enabled = false;
                rECOGToolStripMenuItem.Enabled = false;
                tabControl1.SelectedIndex = 0;
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                toolStripStatusLabel1.Text = "Learning started";
                rESETALLToolStripMenuItem.Enabled = false;
            }
        }

        private void sTOPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerTrainer.CancelAsync();
                backgroundWorkerTrainer.Dispose();
                work = false;
                watch1.Stop();
                rANDOMIZEToolStripMenuItem.Enabled = true;
                rECOGToolStripMenuItem.Enabled = true;
                comboBox1.Enabled = true;
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                toolStripStatusLabel1.Text = "Session stopped";
                toolStripProgressBar1.Value = 0;
                rESETALLToolStripMenuItem.Enabled = true;
            }
            catch
            {

            }
        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 h = new AboutBox1();
            h.ShowDialog();
        }

        private void sTARTToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            lEARNINGToolStripMenuItem.Enabled = false;
            tabControl1.SelectedIndex = 1;
            if (!backgroundWorkerSignal.IsBusy)
            {
                try
                {
                    backgroundWorkerSignal.RunWorkerAsync();
                    signal = true;
                    toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                    toolStripStatusLabel1.Text = "Recognition started";
                }
                catch (Exception k)
                {
                    MessageBox.Show(k.Message);
                }
            }
        }

        private void sTOPToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (backgroundWorkerSignal.IsBusy)
                {
                    lEARNINGToolStripMenuItem.Enabled = true;
                    toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                    toolStripStatusLabel1.Text = "Recognition Stopped";
                    toolStripProgressBar1.Value = 0;
                    backgroundWorkerSignal.CancelAsync();
                    signal = false;
                    aquaGauge1.Value = 0;
                    aquaGauge2.Value = 0;
                    aquaGauge3.Value = 0;
                }
            }
            catch
            { }
            
        }

        private void rANDOMIZEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var c = MessageBox.Show("Warning Randomizing will erase memmory! Do you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (c == System.Windows.Forms.DialogResult.Yes)
            {
                network1.Randomize();
                network2.Randomize();
                network3.Randomize();
                network4.Randomize();
                network5.Randomize();
            }
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        public void SetInput()
        {
            double[] tempinput = new double[1];

            tempinput[0] = Convert.ToSingle(trackBar1.Value);//(double)trackBar1.Value;
            tempinput[0] = tempinput[0] / 10;
            //tempinput[1] = (double)trackBar2.Value;
            //tempinput[2] = (double)trackBar3.Value;
            //tempinput[3] =(double)trackBar4.Value;
            output[0] = tempinput;
       
        }

        private void BackPropogation_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void sTARTToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorkerSignal.IsBusy)
                {
                    backgroundWorkerSignal.RunWorkerAsync();
                    signal = true;
                    toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                    toolStripStatusLabel1.Text = "Server started";
                }
            }
            catch
            {

            }
        }

        private void sTOPToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (backgroundWorkerSignal.IsBusy)
            {
                try
                {
                   // backgroundWorkerSignal.CancelAsync();
                   // signal = false;
                   
                }
                catch
                {

                }
            }

            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            toolStripStatusLabel1.Text = "Server stopped";
            toolStripProgressBar1.Value = 0;
        }

        private void BackPropogation_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            
            if( MessageBox.Show(this,"Do you want to exit?","Exit prompt",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_algorythm = 0;
            selected_algorythm = comboBox1.SelectedIndex;
            comboBox2.SelectedIndex = comboBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
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
            watch1.Reset();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            sleeptime = trackBar4.Value;
            label11.Text = sleeptime.ToString();
        }

        private void aquaGauge2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_algorythm_recog = comboBox2.SelectedIndex;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            label15.Text = trackBar5.Value.ToString();
            sleeptime_recog = trackBar5.Value;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        public void setnetwork()
        {

        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            label16.Text = trackBar6.Value.ToString();
            param1 = trackBar6.Value;
            button2.Enabled = true;
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            label18.Text = trackBar7.Value.ToString();
            param2 = trackBar7.Value;
            button3.Enabled = true;
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            label20.Text = trackBar8.Value.ToString();
            param3 = trackBar8.Value;
            button4.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2.Enabled = false;
            network2 = null;
            reprop = null;
            network2 = new ActivationNetwork(new BipolarSigmoidFunction(param1), 100, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 1);
            reprop = new ResilientBackpropagationLearning(network3);
            network2.Randomize();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button3.Enabled = false;
            network1 = null;
            teacher = null;
            network1 = new ActivationNetwork(new BipolarSigmoidFunction(param2), 100, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 1);
            teacher = new BackPropagationLearning(network1);
            network1.Randomize();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            button4.Enabled = false;
            network3 = null;
            evteacher = null;
            network3 = new ActivationNetwork(new BipolarSigmoidFunction(param3), 100, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 1);
            evteacher = new EvolutionaryLearning(network2, 100);
            network3.Randomize();
        }

        private void rESETALLToolStripMenuItem_Click(object sender, EventArgs e)
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
            watch1.Reset();
            textBox1.Text = "";
            textBox6.Text = "";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        

    }
}
