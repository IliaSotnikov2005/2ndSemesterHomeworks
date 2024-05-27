// <copyright file="SkipList.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList;

using System.Collections;

/// <summary>
/// Skip list class.
/// </summary>
/// <typeparam name="T">Type of elements in skip list.</typeparam>
public class SkipList<T> : IList<T>
    where T : IComparable<T>
{
    private const int MaxLevel = 4;

    private readonly Random random = new ();
    private readonly SkipListElement nil = new (default)
    {
        Next = new List<SkipListElement>(MaxLevel),
    };

    private SkipListElement header;

    private bool invalidateEnumerator = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
    /// </summary>
    public SkipList()
    {
        this.header = new (default)
        {
            Next = [],
        };

        for (int i = 0; i < MaxLevel; ++i)
        {
            this.header.Next.Add(this.nil);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
    /// </summary>
    /// <param name="items">An array of items to be added to the SkipList.</param>
    public SkipList(T[] items)
        : this()
    {
        foreach (var item in items)
        {
            this.Add(item);
        }
    }

    /// <inheritdoc/>
    public int Count { get; private set; } = 0;

    /// <inheritdoc/>
    public bool IsReadOnly => false;

    /// <inheritdoc/>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var current = this.header.Next[0];

            foreach (var item in this)
            {
                if (index == 0)
                {
                    return item;
                }

                --index;
            }

            throw new ArgumentOutOfRangeException(nameof(index));
        }

        set => throw new NotSupportedException();
    }

    /// <inheritdoc/>
    public void Add(T item)
    {
        Stack<SkipListElement> update = new ();

        SkipListElement current = this.header;
        int level = MaxLevel - 1;

        while (level >= 0)
        {
            if (current.Next[level] == this.nil)
            {
                update.Push(current);
                --level;
            }
            else if (current.Next[level].Item!.CompareTo(item) >= 0)
            {
                update.Push(current);
                --level;
            }
            else if (current.Next[level].Item!.CompareTo(item) < 0)
            {
                current = current.Next[level];
            }
        }

        SkipListElement newElement = new (item);

        int levelOfElement = 1;
        for (int i = 1; i < MaxLevel && this.CoinFlip(); ++i)
        {
            ++levelOfElement;
        }

        for (int i = 0; i < levelOfElement; ++i)
        {
            SkipListElement toUpdate = update.Pop();
            newElement.Next.Add(toUpdate.Next[i]);
            toUpdate.Next[i] = newElement;
        }

        this.Count++;
        this.invalidateEnumerator = true;
    }

    /// <inheritdoc/>
    public void Clear()
    {
        this.header = new (default)
        {
            Next = [],
        };

        for (int i = 0; i < MaxLevel; ++i)
        {
            this.header.Next.Add(this.nil);
        }
    }

    /// <inheritdoc/>
    public bool Contains(T item)
    {
        SkipListElement current = this.header;
        int level = MaxLevel - 1;

        while (level >= 0)
        {
            if (current.Next[level] == this.nil)
            {
                --level;
            }
            else if (current.Next[level].Item!.CompareTo(item) > 0)
            {
                --level;
            }
            else if (current.Next[level].Item!.CompareTo(item) < 0)
            {
                current = current.Next[level];
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }

        if (array.Length - arrayIndex < this.Count)
        {
            throw new ArgumentException("Skip List larger than the interval for copying");
        }

        var current = this.header.Next[0];

        while (current != this.nil)
        {
            array[arrayIndex] = current.Item!;
            ++arrayIndex;
            current = current.Next[0];
        }
    }

/// <inheritdoc/>
    public IEnumerator<T> GetEnumerator() => new Enumerator(this);

/// <inheritdoc/>
    public int IndexOf(T item)
    {
        var current = this.header.Next[0];
        var index = 0;

        while (current != this.nil)
        {
            if (item.CompareTo(current.Item) == 0)
            {
                return index;
            }

            current = current.Next[0];

            ++index;
        }

        return -1;
    }

/// <inheritdoc/>
    public void Insert(int index, T item) => throw new NotSupportedException();

/// <inheritdoc/>
    public bool Remove(T item)
    {
        Stack<SkipListElement> update = new ();

        SkipListElement current = this.header;
        int level = MaxLevel - 1;

        while (level >= 0)
        {
            if (current.Next[level] == this.nil)
            {
                update.Push(current);
                --level;
            }
            else if (current.Next[level].Item!.CompareTo(item) > 0)
            {
                update.Push(current);
                --level;
            }
            else if (current.Next[level].Item!.CompareTo(item) < 0)
            {
                current = current.Next[level];
            }
            else if (current.Next[level].Item!.CompareTo(item) == 0)
            {
                while (update.Count != MaxLevel)
                {
                    update.Push(current);
                }

                current = current.Next[level];
                break;
            }
        }

        if (current.Item!.CompareTo(item) != 0)
        {
            return false;
        }

        for (int i = 0; i < current.Next.Count; ++i)
        {
            SkipListElement toUpdate = update.Pop();
            toUpdate.Next[i] = current.Next[i];
        }

        this.Count--;
        return true;
    }

/// <inheritdoc/>
    public void RemoveAt(int index) => this.Remove(this[index]);

/// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

/// <inheritdoc/>
    private record SkipListElement(T? value)
    {
        /// <summary>
        /// Gets or sets item of the element.
        /// </summary>
        /// <value>The value to assign to the item.</value>
        public T? Item { get; set; } = value;

        /// <summary>
        /// Gets or sets the skip list of items further down the list.
        /// </summary>
        /// <value>List of skip list elements.</value>
        public List<SkipListElement> Next { get; set; } = [];
    }

    private bool CoinFlip() => this.random.Next() % 2 == 0;

    private class Enumerator : IEnumerator<T>
    {
        private readonly SkipList<T> skiplist;

        private readonly SkipListElement nil;

        private SkipListElement current;

        public Enumerator(SkipList<T> skiplist)
        {
            this.skiplist = skiplist;
            this.nil = this.skiplist.nil;
            this.skiplist.invalidateEnumerator = false;
            this.current = this.skiplist.header;
        }

        public T Current
        {
            get
            {
                return this.current.Item!;
            }
        }

        object IEnumerator.Current => this.Current;

        public bool MoveNext()
        {
            this.CheckIteratorValidity();

            this.current = this.current.Next[0];
            return this.current != this.nil;
        }

        public void Reset()
        {
            this.CheckIteratorValidity();
            this.current = this.skiplist.header;
        }

        public void Dispose() => GC.SuppressFinalize(this);

        private void CheckIteratorValidity()
        {
            if (this.skiplist.invalidateEnumerator)
            {
                throw new InvalidOperationException("Collection was changed during iteration");
            }
        }
    }
}
