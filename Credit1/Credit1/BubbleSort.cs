// <copyright file="BubbleSort.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// Class of bubble sort algorithm.
/// </summary>
public static class BubbleSort
{
    /// <summary>
    /// Sorts the list according to the specified rule.
    /// </summary>
    /// <param name="list">List to be sorted.</param>
    /// <param name="comparer">Comparator.</param>
    /// <typeparam name="T">Type of elements in list.</typeparam>
    public static void Sort<T>(IList<T> list, IComparer<T> comparer)
    where T : IComparable<T>
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "List cannot be null.");
        }

        if (comparer == null)
        {
            throw new ArgumentNullException(nameof(comparer), "Comparator cannot be null.");
        }

        for (int i = 0; i < list.Count - 1; ++i)
        {
            for (int j = 0; j < list.Count - 1 - i; ++j)
            {
                if (comparer.Compare(list[j], list[j + 1]) > 0)
                {
                    (list[j + 1], list[j]) = (list[j], list[j + 1]);
                }
            }
        }
    }
}