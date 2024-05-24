// <copyright file="MoveToFront.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MoveToFront;

/// <summary>
/// Move to front transformation class.
/// </summary>
public static class MoveToFrontAlghoritm
{
    /// <summary>
    /// The method that runs the algorithm.
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <returns>An MTF encoded sequence of numbers.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="input"/> is null or empty.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="input"/> contains not only the letters of the English alphabet.</exception>
    public static List<int> Run(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException("Input string cannot be null or empty");
        }

        List<int> result = [];

        List<char> alphabet = [.. "abcdefghijklmnopqrstuvwxyz"];

        foreach (var i in input.ToLower())
        {
            int index = alphabet.IndexOf(i);
            if (index == -1)
            {
                throw new ArgumentException("Invalid input. Use only english letters");
            }

            result.Add(index);

            alphabet.RemoveAt(index);
            alphabet.Insert(0, i);
        }

        return result;
    }
}