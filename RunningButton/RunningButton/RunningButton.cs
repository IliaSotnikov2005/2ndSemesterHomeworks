// <copyright file="RunningButton.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RunningButton
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Running button class.
    /// </summary>
    public partial class RunningButton : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RunningButton"/> class.
        /// </summary>
        public RunningButton()
        {
            this.InitializeComponent();
        }

        private void RunningButton_Load(object sender, EventArgs e)
        {
            this.button.Location = new Point(this.Width / 2, this.Height / 2);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Random random = new Random();
            int newX, newY;

            Point relativeCursorPosition = this.PointToClient(Cursor.Position);

            do
            {
                newX = random.Next(0, this.ClientSize.Width - button.Width);
                newY = random.Next(0, this.ClientSize.Height - button.Height);
            }
            while (this.CursorIsInsideNeighborhood(newX, newY, relativeCursorPosition, 5));

            this.button.Location = new Point(newX, newY);
        }

        private bool CursorIsInsideNeighborhood(int x, int y, Point cursorPosition, int epsilon)
        {
            return x - epsilon < cursorPosition.X
                && cursorPosition.X < x + this.button.Width + epsilon
            && y - epsilon < cursorPosition.Y
            && cursorPosition.Y < y + this.button.Height + epsilon;
        }

        private void RunningButton_Resize(object sender, EventArgs e)
        {
            int newButtonX = Math.Min(this.ClientSize.Width - this.button.Width, this.button.Location.X);
            int newButtonY = Math.Min(this.ClientSize.Height - this.button.Height, this.button.Location.Y);

            this.button.Location = new Point(newButtonX, newButtonY);
        }
    }
}
