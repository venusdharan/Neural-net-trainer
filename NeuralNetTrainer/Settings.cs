using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace NeuralNetTrainer
{
    public partial class Settings : Form
    {
        TcpClient c = new TcpClient();
        public Settings()
        {
            InitializeComponent();
            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Connect(IPAddress.Parse(textBox1.Text.Trim()), int.Parse(textBox2.Text.Trim()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
              NetworkStream s = c.GetStream();
              byte[] msg = Encoding.ASCII.GetBytes("hello");
              s.Write(msg, 0, msg.Length);
              byte[] d = new byte[c.Available];
              var f = s.Read(d, 0, d.Length);
              MessageBox.Show(Encoding.ASCII.GetString(d));
          
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
