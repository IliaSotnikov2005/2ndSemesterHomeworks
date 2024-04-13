// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Calculator
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// Calculator form class.
    /// </summary>
    public partial class CalculatorForm : Form
    {
        private Calculator calculator = new Calculator();

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorForm"/> class.
        /// </summary>
        public CalculatorForm()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ExtraFeatureMouseClick(object sender, MouseEventArgs e)
        {
            string shutdownCommand = string.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                shutdownCommand = "shutdown";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                shutdownCommand = "shutdown -h now";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                shutdownCommand = "poweroff";
            }
            else
            {
                return;
            }

            ProcessStartInfo psi = new ProcessStartInfo(shutdownCommand)
            {
                UseShellExecute = true,
                CreateNoWindow = true,
            };

            Process.Start(psi);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button buttonSender = sender as Button;
            this.calculator.ProcessInput(buttonSender.Text[0]);
            this.output.Text = this.calculator.CurrentExpression;
        }

        private void TextBox1_Resize(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Font = new Font(tb.Font.FontFamily, tb.Height / 2);
        }
    }
}
