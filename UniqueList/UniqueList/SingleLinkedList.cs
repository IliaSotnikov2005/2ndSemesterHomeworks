// <copyright file="SingleLinkedList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UniqueList;

/// <summary>
/// Single linked list class.
/// </summary>
/// <typeparam name="T">Type of elements.</typeparam>
public class SingleLinkedList<T>
{
    /// <summary>
    /// Gets the size of list.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Gets or sets Head of the list.
    /// </summary>
    private protected Node? Head { get; set; }

    /// <summary>
    /// Gets or sets element of list by index.
    /// </summary>
    /// <param name="index">Index of the element.</param>
    /// <exception cref="IndexOutOfRangeException">If index out of range.</exception>
    public T this[int index]
    {
        get { return this.GetNode(index).Value; }
        set { this.GetNode(index).Value = value; }
    }

    /// <summary>
    /// Adds element to the list.
    /// </summary>
    /// <param name="element">Element to be added.</param>
    public void Add(T element)
    {
        var newNode = new Node(element);
        if (this.Head != null)
        {
            newNode.Next = this.Head;
        }

        this.Head = newNode;
        this.Size++;
    }

    /// <summary>
    /// Removes element from given index.
    /// </summary>
    /// <param name="index">Index of the element to be removed.</param>
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.Size)
        {
            throw new IndexOutOfRangeException("Index out of range.");
        }

        Node? previous = null;
        Node current = this.Head!;
        for (int i = 0; i < index; ++i)
        {
            previous = current;
            current = current.Next!;
        }

        if (previous == null)
        {
            this.Head = current.Next!;
        }
        else
        {
            previous.Next = current.Next!;
        }

        this.Size--;
    }

    /// <summary>
    /// Gets node by index.
    /// </summary>
    /// <param name="index">Index of the element.</param>
    /// <returns>Node with given index.</returns>
    ///<exception cref="IndexOutOfRangeException">If index out of range.</exception>
    private protected Node GetNode(int index)
    {
        if (index < 0 || index >= this.Size)
        {
            throw new IndexOutOfRangeException("Index out of range.");
        }

        Node current = this.Head!;
        for (int i = 0; i < index; ++i)
        {
            current = current.Next!;
        }

        return current;
    }

    /// <summary>
    /// Node class.
    /// </summary>
    private protected class Node(T value)
    {
        /// <summary>
        /// Gets or sets value of the node.
        /// </summary>
        public T Value { get; set; } = value;

        /// <summary>
        /// Gets or sets next node after this.
        /// </summary>
        public Node? Next { get; set; }
    }
}
