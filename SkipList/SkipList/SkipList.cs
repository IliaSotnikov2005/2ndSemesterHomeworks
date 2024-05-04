using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;
using System.Xml.Serialization;

public class SkipList<T> : IList<T> where T : IComparable<T>
{
    public SkipList()
    {
        header = new SkipListElement(default);
        header.Next = new List<SkipListElement>();
        for (int i = 0; i < maxLevel; ++i)
        {
            header.Next.Add(nil);
        }
    }

    private const int maxLevel = 4;

    private SkipListElement header;

    private SkipListElement? nil = null;

    private readonly Random random = new();

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            var current = header;

            for (int i = 0; i < index + 1; ++i)
            {
                current = current.Next[0];
            }

            return current.Item;
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
            if (current.Next[level] is null)
            {
                update.Push(current);
                --level;
            }
            else if (current.Next[level].Item.CompareTo(item) >= 0)
            {
                update.Push(current);
                --level;
            }
            else if (current.Next[level].Item.CompareTo(item) < 0)
            {
                current = current.Next[level];
            }
        }

        SkipListElement newElement = new(item);
        int levelOfElement = random.Next(1, maxLevel + 1);

        for (int i = 0; i < levelOfElement; ++i)
        {
            SkipListElement toUpdate = update.Pop();
            newElement.Next.Add(toUpdate.Next[i]);
            toUpdate.Next[i] = newElement;
        }

        Count++;
    }

    public void Clear()
    {
        header = new SkipListElement(default);
        header.Next = new List<SkipListElement>();
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
            if (current.Next[level] is null)
            {
                --level;
            }
            else if (current.Next[level].Item.CompareTo(item) > 0)
            {
                --level;
            }
            else if (current.Next[level].Item.CompareTo(item) < 0)
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
        if (array is null)
        {
            throw new ArgumentNullException("Array is null");
        }

        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException("Array index out of range");
        }

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException("Skip List larger than the interval for copying");
        }

        var current = header.Next[0];

        while (current != null)
        {
            array[arrayIndex] = current.Item;
            ++arrayIndex;
            current = current.Next[0];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var array = new T[Count];
        this.CopyTo(array, 0);
        return ((IEnumerable<T>)array).GetEnumerator();
    }

    public int IndexOf(T item)
    {
        var current = header.Next[0];
        var index = 0;

        while (current != null)
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
            if (current.Next[level] is null)
            {
                update.Push(current);
                --level;
            }
            else if (current.Next[level].Item.CompareTo(item) > 0)
            {
                update.Push(current);
                --level;
            }
            else if (current.Next[level].Item.CompareTo(item) < 0)
            {
                current = current.Next[level];
            }
            else if (current.Next[level].Item.CompareTo(item) == 0)
            {
                while (update.Count != maxLevel)
                {
                    update.Push(current);
                }

                current = current.Next[level];
                break;
            }
        }

        if (current.Item.CompareTo(item) != 0)
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

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    private record SkipListElement(T value)
    {
        public T Item { get; set; } = value;

        public List<SkipListElement> Next { get; set; } = [];
    }
}