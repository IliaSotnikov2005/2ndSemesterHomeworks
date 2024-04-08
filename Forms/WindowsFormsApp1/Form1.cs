using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (sender == checkButton)
            {
                if (checkBox1.Checked && checkBox2.Checked)
                {
                    progressBar1.Value = 10;
                    while (progressBar1.Value < 98)
                    {
                        Random rnd = new Random();
                        progressBar1.Value = progressBar1.Value + (rnd.Next(1, 3) == 1 ? 2 : -1);
                        Thread.Sleep(rnd.Next(1, 100));

                    }
                    progressBar1.Value = 100;
                    label1.Visible = true;
                }
            }
        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
