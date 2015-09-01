using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accord.Audio;
using Accord.Audio.Windows;
namespace NeuralNetTrainer
{
    public partial class MainForm : Form
    {
        public Accord.Controls.Wavechart chart;
        public Signal signal;


        public BackPropogation bp;
        public EvolutionaryLearningForm el;
        public ResilientBackpropagationLearningForm rf;
        public BinarySplitForm sb;
        public BootstrapForm bs;
        public CrossValidationForm cs;
        public KernelSupportVectorMachineForm ksvm;
        public KMeansForm km;
        public KNearestNeighborsForm knn;
        public MinimumMeanDistanceClassifierForm mmd;
        public RestrictedBoltzmannMachineForm rbm;
        public SupportVectorMachineForm svm;
        public MeanShiftForm ms;


        public MainForm()
        {
            InitializeComponent();
           

            bp = new BackPropogation();
            bp.FormClosed += bp_FormClosed;

            el = new EvolutionaryLearningForm();
            rf = new ResilientBackpropagationLearningForm();
            sb = new BinarySplitForm();
            bs = new BootstrapForm();
            cs = new CrossValidationForm();
            ksvm = new KernelSupportVectorMachineForm();
            km = new KMeansForm();
            knn = new KNearestNeighborsForm();
            mmd = new MinimumMeanDistanceClassifierForm();
            rbm = new RestrictedBoltzmannMachineForm();
            svm = new SupportVectorMachineForm();
            ms = new MeanShiftForm();

        }

        void bp_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //chart.Parent = this;
            //chart.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                bp.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                el.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rf.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            knn.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bs.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            svm.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            rbm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cs.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            km.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sb.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ksvm.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ms.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mmd.ShowDialog();
        }

        private void templateGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemplateGenerator t = new TemplateGenerator();
            t.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 f = new AboutBox1();
            f.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ErrorViewer r = new ErrorViewer();
            r.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch
            { }
        }

        private void button15_Click(object sender, EventArgs e)
        {
           
        }
    }
}
