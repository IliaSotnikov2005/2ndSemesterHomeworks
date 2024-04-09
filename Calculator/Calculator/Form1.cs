using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        Calculator calculator = new Calculator();
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExtraFeatureMouseClick(object sender, MouseEventArgs e)
        {
            Process.Start("shutdown", "/s /t 0");

        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button buttonSender = sender as Button;
            calculator.ProcessInput(buttonSender.Text[0]);
            textBox1.Text = calculator.GetExpresiion();
        }

        private void textBox1_Resize(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Font = new Font(tb.Font.FontFamily, tb.Height / 2);
        }
    }
}
