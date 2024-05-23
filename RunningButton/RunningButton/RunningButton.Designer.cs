// <copyright file="RunningButton.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RunningButton
{
    partial class RunningButton
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
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(259, 150);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(100, 35);
            this.button.TabIndex = 0;
            this.button.Text = "Click me";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.Button_Click);
            this.button.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button.MouseHover += new System.EventHandler(this.Button_MouseEnter);
            // 
            // RunningButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 360);
            this.Controls.Add(this.button);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "RunningButton";
            this.Text = "RunningButton";
            this.Load += new System.EventHandler(this.RunningButton_Load);
            this.Resize += new System.EventHandler(this.RunningButton_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button;
    }
}

