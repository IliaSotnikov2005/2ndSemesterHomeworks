// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using FunctionsSpace;

/// <summary>
/// Program class.
/// </summary>
public static class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    public static void Main()
    {
        List<float> list = [1, 2, 3];

        WriteLineItems(Functions.Map(list, x => x * 2));
        WriteLineItems(Functions.Filter(list, x => x % 2 == 0));
        Console.WriteLine(Functions.Fold(list, 1, (x, y) => x * y));
    }

    private static void WriteLineItems<T>(List<T> list)
    {
        foreach (var item in list)
        {
            Console.Write($"{item}, ");
        }

        Console.WriteLine("\n");
    }
}