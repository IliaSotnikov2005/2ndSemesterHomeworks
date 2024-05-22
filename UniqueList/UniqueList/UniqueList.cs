// <copyright file="UniqueList.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UniqueList;

/// <summary>
/// Unique list class.
/// </summary>
/// <typeparam name="T">Type of elements in list.</typeparam>
public class UniqueList<T> : SingleLinkedList<T>
{
    /// <summary>
    /// Gets or sets element of list by index.
    /// </summary>
    /// <param name="index">Index of the element.</param>
    /// <exception cref="ArgumentException">Throws when invalid index.</exception>
    /// <exception cref="ElementIsAlreadyInsideException">Throws when element is already inside.</exception>
    public new T this[int index]
    {
        get { return this.GetNode(index).Value; }
        set { this.TrySet(this.GetNode(index), value); }
    }

    /// <summary>
    /// Adds element to the list.
    /// </summary>
    /// <param name="element">Element to be added.</param>
    /// <exception cref="ElementIsAlreadyInsideException">Throws when element is already inside.</exception>
    public new void Add(T element)
    {
        if (this.Contains(element))
        {
            throw new ElementIsAlreadyInsideException("Element is already inside");
        }

        base.Add(element);
    }

    private void TrySet(Node element, T value)
    {
        ArgumentNullException.ThrowIfNull(element.Value);

        if (this.Contains(value) && !element.Value.Equals(value))
        {
            throw new ElementIsAlreadyInsideException("Element is already inside");
        }

        element.Value = value;
    }

    private bool Contains(T element)
    {
        Node? current = this.Head;
        while (current != null)
        {
            ArgumentNullException.ThrowIfNull(current.Value);

            if (current.Value.Equals(element))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }
}
