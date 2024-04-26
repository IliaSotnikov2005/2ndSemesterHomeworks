// <copyright file="PriorityQueue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// Initializes a new instance of the <see cref="PriorityQueueHeap"/> class.
/// </summary>
/// <typeparam name="T">Type of queue's items.</typeparam>
public class PriorityQueueHeap<T>
{
    private readonly List<Tuple<T, int>> heap = [];

    /// <summary>
    /// Gets a value indicating whether the queue is empty.
    /// </summary> <summary>
    public bool Empty => this.heap.Count == 0;

    /// <summary>
    /// Adds a value with the specified priority to the queue.
    /// </summary>
    /// <param name="item">Item to be added to the queue.</param>
    /// <param name="priority">Priority of the item.</param>
    public void Enqueue(T item, int priority)
    {
        this.heap.Add(new Tuple<T, int>(item, priority));
        int i = this.heap.Count - 1;

        while (i > 0)
        {
            int j = (i - 1) / 2;
            if (this.heap[j].Item2.CompareTo(this.heap[i].Item2) > 0)
            {
                break;
            }

            this.Swap(i, j);
            i = j;
        }
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

        T item = this.heap[0].Item1;
        this.heap.RemoveAt(0);
        this.UpdateHeap(0);

        return item;
    }

    private void Swap(int i, int j)
    {
        var temp = this.heap[i];
        this.heap[i] = this.heap[j];
        this.heap[j] = temp;
    }

    private void UpdateHeap(int i)
    {
        int leftChild = 2 * i;
        int rightChild = (2 * i) + 1;
        int elementWithHighestPriority = i;

        if (leftChild < this.heap.Count && this.heap[leftChild].Item2.CompareTo(this.heap[elementWithHighestPriority].Item2) > 0)
        {
            elementWithHighestPriority = leftChild;
        }

        if (rightChild < this.heap.Count && this.heap[rightChild].Item2.CompareTo(this.heap[elementWithHighestPriority].Item2) > 0)
        {
            elementWithHighestPriority = rightChild;
        }

        if (elementWithHighestPriority != i)
        {
            this.Swap(i, elementWithHighestPriority);
            this.UpdateHeap(elementWithHighestPriority);
        }
    }
}
