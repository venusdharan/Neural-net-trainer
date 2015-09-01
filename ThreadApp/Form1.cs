using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ThreadApp
{
    public partial class Form1 : Form
    {
        public static bool run = false;

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.WorkerSupportsCancellation = true;
            
        }


        delegate void SetTextCallbackTime(string text);

        private void SetTextTime(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
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
                this.textBox1.Text = text;
            }
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (run)
            {
                SetTextTime(i.ToString());
                i++;
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                run = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            run = false;
            backgroundWorker1.CancelAsync();
        }
    }
}
