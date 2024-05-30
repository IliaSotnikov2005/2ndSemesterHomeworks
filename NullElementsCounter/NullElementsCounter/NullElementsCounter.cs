// <copyright file="NullElementsCounter.cs" company="IlyaSotnikov">
// Copyright (c) IlyaSotnikov. All rights reserved.
// </copyright>

namespace NullElementsCounter;

/// <summary>
/// Counter for null elements in a list with given with a given "null" element.
/// </summary>
public static class NullElementsCounter
{
    /// <summary>
    /// Method to count the number of "null" elements.
    /// </summary>
    /// <param name="list">List of elements.</param>
    /// <param name="isNuller">An object that defines which elements are "null".</param>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <returns>The count of "null" elements.</returns>
    public static int CountNullElements<T>(List<T> list, INullChecker<T> isNuller)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(isNuller);

        int count = 0;

        foreach (var element in list)
        {
            if (isNuller.IsNull(element))
            {
                ++count;
            }
        }

        return count;
    }
}