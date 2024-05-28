// <copyright file="CalculatorForm.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Calculator;

using System;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Calculator form class.
/// </summary>
public partial class CalculatorForm : Form
{
    private readonly Calculator calculator = new ();

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorForm"/> class.
    /// </summary>
    public CalculatorForm()
    {
        this.InitializeComponent();
        this.output.DataBindings.Add("Text", this.calculator, "CurrentExpression", false, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void ButtonClick(object sender, EventArgs e)
    {
        if (sender is not Button buttonSender)
        {
            throw new ArgumentException("Sender is not a button");
        }

        this.calculator.ProcessInput(buttonSender.Text[0]);
        this.output.Refresh();
    }

    private void TextBox1_Resize(object sender, EventArgs e)
    {
        if (sender is not TextBox tb)
        {
            throw new ArgumentException("Sender is not a text box");
        }

        tb.Font = new Font(tb.Font.FontFamily, tb.Height / 2);
    }
}
