namespace Calculator
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            output = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            buttonPlus = new Button();
            buttonMinus = new Button();
            buttonClear = new Button();
            buttonDivision = new Button();
            buttonMultiplication = new Button();
            buttonPoint = new Button();
            button0 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonEquals = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // output
            // 
            output.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            output.BackColor = SystemColors.ActiveBorder;
            output.BorderStyle = BorderStyle.FixedSingle;
            output.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            output.Location = new Point(4, 3);
            output.Margin = new Padding(4, 3, 4, 3);
            output.MinimumSize = new Size(233, 57);
            output.Multiline = true;
            output.Name = "output";
            output.ReadOnly = true;
            output.Size = new Size(520, 127);
            output.TabIndex = 0;
            output.Resize += TextBox1_Resize;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.AutoEllipsis = true;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(4, 390);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.MinimumSize = new Size(58, 58);
            button1.Name = "button1";
            button1.Size = new Size(122, 123);
            button1.TabIndex = 1;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonClick;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.AutoEllipsis = true;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(134, 390);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.MinimumSize = new Size(58, 58);
            button2.Name = "button2";
            button2.Size = new Size(122, 123);
            button2.TabIndex = 2;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ButtonClick;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.AutoEllipsis = true;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(264, 390);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.MinimumSize = new Size(58, 58);
            button3.Name = "button3";
            button3.Size = new Size(122, 123);
            button3.TabIndex = 3;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ButtonClick;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.AutoEllipsis = true;
            button4.Cursor = Cursors.Hand;
            button4.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Location = new Point(4, 261);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.MinimumSize = new Size(58, 58);
            button4.Name = "button4";
            button4.Size = new Size(122, 123);
            button4.TabIndex = 4;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ButtonClick;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button5.AutoEllipsis = true;
            button5.Cursor = Cursors.Hand;
            button5.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button5.Location = new Point(134, 261);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.MinimumSize = new Size(58, 58);
            button5.Name = "button5";
            button5.Size = new Size(122, 123);
            button5.TabIndex = 5;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += ButtonClick;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button6.AutoEllipsis = true;
            button6.Cursor = Cursors.Hand;
            button6.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button6.Location = new Point(264, 261);
            button6.Margin = new Padding(4, 3, 4, 3);
            button6.MinimumSize = new Size(58, 58);
            button6.Name = "button6";
            button6.Size = new Size(122, 123);
            button6.TabIndex = 6;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += ButtonClick;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button7.AutoEllipsis = true;
            button7.Cursor = Cursors.Hand;
            button7.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button7.Location = new Point(4, 132);
            button7.Margin = new Padding(4, 3, 4, 3);
            button7.MinimumSize = new Size(58, 58);
            button7.Name = "button7";
            button7.Size = new Size(122, 123);
            button7.TabIndex = 7;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += ButtonClick;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button8.AutoEllipsis = true;
            button8.Cursor = Cursors.Hand;
            button8.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button8.Location = new Point(134, 132);
            button8.Margin = new Padding(4, 3, 4, 3);
            button8.MinimumSize = new Size(58, 58);
            button8.Name = "button8";
            button8.Size = new Size(122, 123);
            button8.TabIndex = 8;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += ButtonClick;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button9.AutoEllipsis = true;
            button9.Cursor = Cursors.Hand;
            button9.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button9.Location = new Point(264, 132);
            button9.Margin = new Padding(4, 3, 4, 3);
            button9.MinimumSize = new Size(58, 58);
            button9.Name = "button9";
            button9.Size = new Size(122, 123);
            button9.TabIndex = 9;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += ButtonClick;
            // 
            // buttonPlus
            // 
            buttonPlus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonPlus.AutoEllipsis = true;
            buttonPlus.Cursor = Cursors.Hand;
            buttonPlus.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonPlus.Location = new Point(394, 132);
            buttonPlus.Margin = new Padding(4, 3, 4, 3);
            buttonPlus.MinimumSize = new Size(58, 58);
            buttonPlus.Name = "buttonPlus";
            buttonPlus.Size = new Size(122, 123);
            buttonPlus.TabIndex = 13;
            buttonPlus.Text = "+";
            buttonPlus.UseVisualStyleBackColor = true;
            buttonPlus.Click += ButtonClick;
            // 
            // buttonMinus
            // 
            buttonMinus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonMinus.AutoEllipsis = true;
            buttonMinus.Cursor = Cursors.Hand;
            buttonMinus.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonMinus.Location = new Point(394, 261);
            buttonMinus.Margin = new Padding(4, 3, 4, 3);
            buttonMinus.MinimumSize = new Size(58, 58);
            buttonMinus.Name = "buttonMinus";
            buttonMinus.Size = new Size(122, 123);
            buttonMinus.TabIndex = 14;
            buttonMinus.Text = "-";
            buttonMinus.UseVisualStyleBackColor = true;
            buttonMinus.Click += ButtonClick;
            // 
            // buttonClear
            // 
            buttonClear.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonClear.AutoEllipsis = true;
            buttonClear.BackColor = Color.DarkGray;
            buttonClear.Cursor = Cursors.Hand;
            buttonClear.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonClear.ForeColor = Color.Black;
            buttonClear.Location = new Point(4, 3);
            buttonClear.Margin = new Padding(4, 3, 4, 3);
            buttonClear.MinimumSize = new Size(58, 58);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(122, 123);
            buttonClear.TabIndex = 10;
            buttonClear.Text = "C";
            buttonClear.UseVisualStyleBackColor = false;
            buttonClear.Click += ButtonClick;
            // 
            // buttonDivision
            // 
            buttonDivision.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonDivision.AutoEllipsis = true;
            buttonDivision.Cursor = Cursors.Hand;
            buttonDivision.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonDivision.Location = new Point(134, 3);
            buttonDivision.Margin = new Padding(4, 3, 4, 3);
            buttonDivision.MinimumSize = new Size(58, 58);
            buttonDivision.Name = "buttonDivision";
            buttonDivision.Size = new Size(122, 123);
            buttonDivision.TabIndex = 11;
            buttonDivision.Text = "/";
            buttonDivision.UseVisualStyleBackColor = true;
            buttonDivision.Click += ButtonClick;
            // 
            // buttonMultiplication
            // 
            buttonMultiplication.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonMultiplication.AutoEllipsis = true;
            buttonMultiplication.Cursor = Cursors.Hand;
            buttonMultiplication.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonMultiplication.Location = new Point(264, 3);
            buttonMultiplication.Margin = new Padding(4, 3, 4, 3);
            buttonMultiplication.MinimumSize = new Size(58, 58);
            buttonMultiplication.Name = "buttonMultiplication";
            buttonMultiplication.Size = new Size(122, 123);
            buttonMultiplication.TabIndex = 12;
            buttonMultiplication.Text = "*";
            buttonMultiplication.UseVisualStyleBackColor = true;
            buttonMultiplication.Click += ButtonClick;
            // 
            // buttonPoint
            // 
            buttonPoint.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonPoint.AutoEllipsis = true;
            buttonPoint.Cursor = Cursors.Hand;
            buttonPoint.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonPoint.Location = new Point(394, 390);
            buttonPoint.Margin = new Padding(4, 3, 4, 3);
            buttonPoint.MinimumSize = new Size(58, 58);
            buttonPoint.Name = "buttonPoint";
            buttonPoint.Size = new Size(122, 123);
            buttonPoint.TabIndex = 15;
            buttonPoint.Text = ".";
            buttonPoint.UseVisualStyleBackColor = true;
            buttonPoint.Click += ButtonClick;
            // 
            // button0
            // 
            button0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button0.AutoEllipsis = true;
            button0.Cursor = Cursors.Hand;
            button0.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button0.Location = new Point(134, 519);
            button0.Margin = new Padding(4, 3, 4, 3);
            button0.MinimumSize = new Size(58, 58);
            button0.Name = "button0";
            button0.Size = new Size(122, 125);
            button0.TabIndex = 0;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            button0.Click += ButtonClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(buttonClear, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonPoint, 3, 3);
            tableLayoutPanel1.Controls.Add(button0, 1, 4);
            tableLayoutPanel1.Controls.Add(buttonDivision, 1, 0);
            tableLayoutPanel1.Controls.Add(button3, 2, 3);
            tableLayoutPanel1.Controls.Add(button6, 2, 2);
            tableLayoutPanel1.Controls.Add(button2, 1, 3);
            tableLayoutPanel1.Controls.Add(buttonMinus, 3, 2);
            tableLayoutPanel1.Controls.Add(button5, 1, 2);
            tableLayoutPanel1.Controls.Add(button7, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonPlus, 3, 1);
            tableLayoutPanel1.Controls.Add(button8, 1, 1);
            tableLayoutPanel1.Controls.Add(button9, 2, 1);
            tableLayoutPanel1.Controls.Add(buttonMultiplication, 2, 0);
            tableLayoutPanel1.Controls.Add(button4, 0, 2);
            tableLayoutPanel1.Controls.Add(button1, 0, 3);
            tableLayoutPanel1.Controls.Add(buttonEquals, 3, 4);
            tableLayoutPanel1.Location = new Point(4, 136);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.MinimumSize = new Size(58, 58);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(520, 647);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // buttonEquals
            // 
            buttonEquals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonEquals.AutoEllipsis = true;
            buttonEquals.Cursor = Cursors.Hand;
            buttonEquals.Font = new Font("Molot", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonEquals.Location = new Point(394, 519);
            buttonEquals.Margin = new Padding(4, 3, 4, 3);
            buttonEquals.MinimumSize = new Size(58, 58);
            buttonEquals.Name = "buttonEquals";
            buttonEquals.Size = new Size(122, 125);
            buttonEquals.TabIndex = 16;
            buttonEquals.Text = "=";
            buttonEquals.UseVisualStyleBackColor = true;
            buttonEquals.Click += ButtonClick;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(output, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutPanel2.Location = new Point(14, 14);
            tableLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 83F));
            tableLayoutPanel2.Size = new Size(528, 786);
            tableLayoutPanel2.TabIndex = 19;
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(556, 813);
            Controls.Add(tableLayoutPanel2);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(347, 456);
            Name = "CalculatorForm";
            Text = "Calculator";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDivision;
        private System.Windows.Forms.Button buttonMultiplication;
        private System.Windows.Forms.Button buttonPoint;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonEquals;
    }
}

