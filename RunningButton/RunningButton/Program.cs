// <copyright file="Program.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RunningButton
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The entry point to the program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RunningButton());
        }
    }
}
