// <copyright file="Functions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FunctionsSpace;

/// <summary>
/// Provides a set of static methods for manipulating a list of items.
/// </summary>
public static class Functions
{
    /// <summary>
    /// Applies a function to each item in a list and returns a new list with the results.
    /// </summary>
    /// <typeparam name="T">The type of the items in the list.</typeparam>
    /// <param name="source">The list of items to operate on.</param>
    /// <param name="function">The function to apply to each item.</param>
    /// <returns>A new list with the results of applying the function to each item.</returns>
    public static List<T> Map<T>(List<T> source, Func<T, T> function)
    {
        var result = new List<T>();
        foreach (var item in source)
        {
            result.Add(function(item));
        }

        return result;
    }

    /// <summary>
    /// Filters a list based on a predicate and returns a new list with the filtered items.
    /// </summary>
    /// <typeparam name="T">The type of the items in the list.</typeparam>
    /// <param name="source">The list of items to operate on.</param>
    /// <param name="function">The predicate function to use for filtering.</param>
    /// <returns>A new list with the filtered items.</returns>
    public static List<T> Filter<T>(List<T> source, Func<T, bool> function)
    {
        var result = new List<T>();
        foreach (var item in source)
        {
            if (function(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    /// <summary>
    /// Folds a list from left to right, applying a function to each item and combining the results.
    /// </summary>
    /// <typeparam name="T">The type of the items in the list.</typeparam>
    /// <param name="source">The list of items to operate on.</param>
    /// <param name="seed">The initial value for the fold operation.</param>
    /// <param name="function">The function to apply to each item for the fold operation.</param>
    /// <returns>The result of the fold operation.</returns>
    public static T Fold<T>(List<T> source, T seed, Func<T, T, T> function)
    {
        T result = seed;
        foreach (var item in source)
        {
            result = function(result, item);
        }

        return result;
    }
}