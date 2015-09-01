using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NeuralNetTrainer
{
    public partial class Error_Logger : Form
    {
        public static bool start = true;
        public Error_Logger()
        {
            InitializeComponent();
            button3.Enabled = false;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;
            button1.Enabled = false;
        }

        private void Error_Logger_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Log file (*.log)|*.log";
            s.Title = "Save Log file";
            s.InitialDirectory = null;
            s.FileName = null;
            var r = s.ShowDialog();
            if(r != System.Windows.Forms.DialogResult.Cancel)
            {
                File.WriteAllText(s.FileName, textBox1.Text);
            }
        }
    }
}
