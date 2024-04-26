// <copyright file="PriorityQueueTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PriorityQueueTests;

/// <summary>
/// Tests for priority queue.
/// </summary>
public class Tests
{
    /// <summary>
    /// Checks for priority matching.
    /// </summary>
    [Test]
    public void Enqueue_WithPriority_PriorityMathes()
    {
        var priorityQueue = new PriorityQueue<int>();
        int[] items = [5, 3, 1, 4, 2];
        int[] expected = [5, 4, 3, 2, 1];

        foreach (var item in items)
        {
            priorityQueue.Enqueue(item, item);
        }

        for (int i = 0; i < items.Length; ++i)
        {
            Assert.That(priorityQueue.Dequeue(), Is.EqualTo(expected[i]));
        }
    }

    /// <summary>
    /// Checks work with other types.
    /// </summary>
    [Test]
    public void Enqueue_Strings_EnqueueCorrect()
    {
        var priorityQueue = new PriorityQueue<string>();
        string[] items = ["bbb", "a", "ewb", "aaa", "odd"];
        int[] priorities = [10, 14, 2, 10, 0];
        string[] expected = ["a", "bbb", "aaa", "ewb", "odd"];

        for (int i = 0; i < items.Length; ++i)
        {
            priorityQueue.Enqueue(items[i], priorities[i]);
        }

        for (int i = 0; i < items.Length; ++i)
        {
            Assert.That(priorityQueue.Dequeue(), Is.EqualTo(expected[i]));
        }
    }

    /// <summary>
    /// Сhecks that an exception is thrown.
    /// </summary>
    [Test]
    public void Dequeue_WhenEmpty_ThrowsException()
    {
        var priorityQueue = new PriorityQueue<int>();

        Assert.Throws<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    /// <summary>
    /// Checks empty property.
    /// </summary>
    [Test]
    public void Enqueue_Empty_WorksCorrect()
    {
        var priorityQueue = new PriorityQueue<int>();
        int[] items = [5, 3, 1, 4, 2];

        foreach (var item in items)
        {
            priorityQueue.Enqueue(item, item);
        }

        for (int i = 0; i < items.Length; ++i)
        {
            Assert.That(priorityQueue.Empty, Is.False);
            priorityQueue.Dequeue();
        }

        Assert.That(priorityQueue.Empty, Is.True);
    }
}