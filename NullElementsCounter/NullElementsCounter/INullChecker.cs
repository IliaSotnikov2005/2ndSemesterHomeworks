// <copyright file="INullChecker.cs" company="IlyaSotnikov">
// Copyright (c) IlyaSotnikov. All rights reserved.
// </copyright>

namespace NullElementsCounter;

/// <summary>
/// An interface for objects that specifies "null".
/// </summary>
/// <typeparam name="T">Type of object.</typeparam>
public interface INullChecker<T>
{
    /// <summary>
    /// Determines if element is "null".
    /// </summary>
    /// <param name="element">Element.</param>
    /// <returns>True if element is "null" else false.</returns>
    public bool IsNull(T element);
}