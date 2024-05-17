// <copyright file="BubbleSortTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BubbleSortTests;
using BubbleSort;

/// <summary>
/// Tests for <see cref="BubbleSort"/>.
/// </summary>
public class Tests
{
    /// <summary>
    /// Tests if bubble sort correct sorts custom objects.
    /// </summary>
    [Test]
    public void Sort_WithCustomObjects_SortedCorrectly()
    {
        List<CustomObject> list =
            [
                new CustomObject { Value = 3 },
                new CustomObject { Value = 1 },
                new CustomObject { Value = -2 }
            ];

        var customComparer = new CustomComparer();

        BubbleSort.Sort(list, customComparer);
        Assert.Multiple(() =>
        {
            Assert.That(list[0].Value, Is.EqualTo(-2));
            Assert.That(list[1].Value, Is.EqualTo(1));
            Assert.That(list[2].Value, Is.EqualTo(3));
        });
    }

    /// <summary>
    /// Tests if bubble sort correct sorts custom objects with another comparator.
    /// </summary>
    [Test]
    public void Sort_WithCustomObjectsAnotherComparator_SortedCorrectly()
    {
        List<CustomObject> list =
            [
                new CustomObject { Value = 3 },
                new CustomObject { Value = 1 },
                new CustomObject { Value = -2 }
            ];

        var customComparer = new CustomComparer2();

        BubbleSort.Sort(list, customComparer);
        Assert.Multiple(() =>
        {
            Assert.That(list[0].Value, Is.EqualTo(1));
            Assert.That(list[1].Value, Is.EqualTo(-2));
            Assert.That(list[2].Value, Is.EqualTo(3));
        });
    }

    /// <summary>
    /// Сhecking that sorting throws an exception when list is null.
    /// </summary>
    [Test]
    public void Sort_WithNullList_ThrowsArgumentNullException()
    {
        List<CustomObject>? nullList = null;

        Assert.Throws<ArgumentNullException>(() => BubbleSort.Sort(nullList!, new CustomComparer()));
    }

    /// <summary>
    /// Сhecking that sorting throws an exception when comparator is null.
    /// </summary>
    [Test]
    public void Sort_WithNullComparer_ThrowsArgumentNullException()
    {
        List<CustomObject> list =
        [
                new CustomObject { Value = 3 },
                new CustomObject { Value = 1 },
                new CustomObject { Value = 2 },
        ];

        CustomComparer? nullComparer = null;

        Assert.Throws<ArgumentNullException>(() => BubbleSort.Sort(list, nullComparer!));
    }

    /// <summary>
    /// Check that sort doesn't throw exception when list is empty.
    /// </summary>
    [Test]
    public void Sort_WithEmptyList_DoesNotThrowException()
    {
        List<CustomObject> emptyList = [];

        Assert.DoesNotThrow(() => BubbleSort.Sort(emptyList, new CustomComparer()));
    }

    /// <summary>
    /// Checks that sort doesn't throw exception when list consists of one element.
    /// </summary>
    [Test]
    public void Sort_WithListOfOneElement_DoesNotThrowException()
    {
        List<CustomObject> listOfOneElement =
            [
                new CustomObject { Value = 1 }
            ];

        Assert.DoesNotThrow(() => BubbleSort.Sort(listOfOneElement, new CustomComparer()));
    }

    /// <summary>
    /// Checks that sort works with strings.
    /// </summary>
    [Test]
    public void Sort_BasicTypes_WorksCorrectly()
    {
        List<string> list = ["failed credit", "drop out of university", "army", "factory", "drinking beer"];

        var stringComparer = new StringComparer();

        BubbleSort.Sort(list, stringComparer);
        Assert.Multiple(() =>
        {
            Assert.That(list[0], Is.EqualTo("army"));
            Assert.That(list[1], Is.EqualTo("drinking beer"));
            Assert.That(list[2], Is.EqualTo("drop out of university"));
            Assert.That(list[3], Is.EqualTo("factory"));
            Assert.That(list[4], Is.EqualTo("failed credit"));
        });
    }

    /// <summary>
    /// Custom object for the tests.
    /// </summary>
    public class CustomObject : IComparable<CustomObject>
    {
        /// <summary>
        /// Gets or sets value to compare objects.
        /// </summary>
        public int Value { get; set; }

        /// <inheritdoc/>
        public int CompareTo(CustomObject? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "Null value");
            }

            return this.Value.CompareTo(other.Value);
        }
    }

    /// <summary>
    /// Custom comparer for the custom objects.
    /// </summary>
    public class CustomComparer : IComparer<CustomObject>
    {
        /// <inheritdoc/>
        public int Compare(CustomObject? x, CustomObject? y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x), "Null value");
            }

            if (y == null)
            {
                throw new ArgumentNullException(nameof(y), "Null value");
            }

            return x.Value.CompareTo(y.Value);
        }
    }

    /// <summary>
    /// Custom comparer for the custom objects.
    /// </summary>
    public class CustomComparer2 : IComparer<CustomObject>
    {
        /// <inheritdoc/>
        public int Compare(CustomObject? x, CustomObject? y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x), "Null value");
            }

            if (y == null)
            {
                throw new ArgumentNullException(nameof(y), "Null value");
            }

            return Math.Abs(x.Value).CompareTo(Math.Abs(y.Value));
        }
    }

    /// <summary>
    /// Custom comparer for the custom objects.
    /// </summary>
    public class StringComparer : IComparer<string>
    {
        /// <inheritdoc/>
        public int Compare(string? x, string? y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x), "Null value");
            }

            if (y == null)
            {
                throw new ArgumentNullException(nameof(y), "Null value");
            }

            return x.CompareTo(y);
        }
    }
}