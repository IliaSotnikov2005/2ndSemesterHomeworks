using System.Collections;

namespace SkipList;

public class SkipList<T> : IList<T> where T : IComparable<T>
{
    private const int maxLevel = 4;

    private SkipListElement header = new(default)
    {
        Next = []
    };

    private protected SkipListElement nil = new(default)
    {
        Next = []
    };

    private readonly Random random = new();

    private bool invalidateEnumerator = false;

    public SkipList()
    {
        for (int i = 0; i < maxLevel; ++i)
        {
            header.Next.Add(nil);
        }
    }

    public SkipList(T[] items)
        : this()
    {
        foreach (var item in items)
        {
            this.Add(item);
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var current = header.Next[0];

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

    public int Count { get; private set; } = 0;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        Stack<SkipListElement> update = new();

        SkipListElement current = header;
        int level = maxLevel - 1;

        while (level >= 0)
        {
            if (current.Next[level] == nil)
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

        SkipListElement newElement = new(item);

        int levelOfElement = 1;
        for (int i = 1; i < maxLevel && CoinFlip(); ++i)
        {
            ++levelOfElement;
        }

        for (int i = 0; i < levelOfElement; ++i)
        {
            SkipListElement toUpdate = update.Pop();
            newElement.Next.Add(toUpdate.Next[i]);
            toUpdate.Next[i] = newElement;
        }

        Count++;
        this.invalidateEnumerator = true;
    }

    public void Clear()
    {
        header = new(default)
        {
            Next = []
        };

        for (int i = 0; i < maxLevel; ++i)
        {
            header.Next.Add(nil);
        }
    }

    public bool Contains(T item)
    {
        SkipListElement current = header;
        int level = maxLevel - 1;

        while (level >= 0)
        {
            if (current.Next[level] == nil)
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

    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException("Skip List larger than the interval for copying");
        }

        var current = header.Next[0];

        while (current != nil)
        {
            array[arrayIndex] = current.Item!;
            ++arrayIndex;
            current = current.Next[0];
        }
    }

    public IEnumerator<T> GetEnumerator() => new Enumerator(this);

    public int IndexOf(T item)
    {
        var current = header.Next[0];
        var index = 0;

        while (current != nil)
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

    public void Insert(int index, T item) => throw new NotSupportedException();

    public bool Remove(T item)
    {
        Stack<SkipListElement> update = new();

        SkipListElement current = header;
        int level = maxLevel - 1;

        while (level >= 0)
        {
            if (current.Next[level] == nil)
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
                while (update.Count != maxLevel)
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

        Count--;
        return true;
    }

    public void RemoveAt(int index) => Remove(this[index]);

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private protected record SkipListElement(T? Value)
    {
        public T? Item { get; set; } = Value;

        public List<SkipListElement> Next { get; set; } = [];
    }

    private bool CoinFlip() => this.random.Next() % 2 == 0;

    private class Enumerator : IEnumerator<T>
    {
        private SkipList<T> skiplist;

        private SkipListElement nil;

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
                return this.current.Value!;
            }
        }

        object IEnumerator.Current => (object)this.Current;

        public bool MoveNext()
        {
            this.CheckIteratorValidity();

            this.current = this.current.Next[0];
            return this.current != nil;
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