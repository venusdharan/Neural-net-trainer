using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NeuralNetTrainer
{
    public partial class SplashScreen : Form
    {
        MainForm h;
        public SplashScreen()
        {
            InitializeComponent();
            h = new MainForm();
           
            
           // h.ShowDialog();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                h.ShowDialog();
            }
            catch
            {

            }
        }
    }
}
