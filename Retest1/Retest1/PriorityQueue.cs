// <copyright file="PriorityQueue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// Initializes a new instance of the <see cref="PriorityQueue"/> class.
/// </summary>
/// <typeparam name="T">Type of queue's items.</typeparam>
public class PriorityQueue<T>
{
    private readonly List<Tuple<T, int>> queue = [];

    /// <summary>
    /// Gets a value indicating whether the queue is empty.
    /// </summary> <summary>
    public bool Empty => this.queue.Count == 0;

    /// <summary>
    /// Adds a value with the specified priority to the queue.
    /// </summary>
    /// <param name="item">Item to be added to the queue.</param>
    /// <param name="priority">Priority of the item.</param>
    public void Enqueue(T item, int priority)
    {
        this.queue.Add(new Tuple<T, int>(item, priority));
        this.queue.Sort((element1, element2) => element2.Item2.CompareTo(element1.Item2));
    }

    /// <summary>
    /// Retrieves the value with the highest priority from the queue.
    /// </summary>
    /// <returns>Item with the highest priority.</returns>
    public T Dequeue()
    {
        if (this.Empty)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T item = this.queue[0].Item1;
        this.queue.RemoveAt(0);

        return item;
    }
}
