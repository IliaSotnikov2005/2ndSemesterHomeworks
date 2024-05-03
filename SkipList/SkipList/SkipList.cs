using System.Collections;

public class SkipList<T> : IList<T> where T : IComparable<T>
{
    private const int MaxLevel = 4;

    private const float probability = 0.25f;

    private SkipListElement header;

    private SkipListElement nil;

    private readonly Random random = new();

    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        if (header is null)
        {
            nil = new SkipListElement(default);
            header = new SkipListElement(item);
            header.Next = new List<SkipListElement>();
            for (int i = 0; i < MaxLevel; ++i)
            {
                header.Next.Add(nil);
            }
            return;
        }

        List<SkipListElement> update = new();

        SkipListElement current = header;
        int level = MaxLevel;
        while (level > 0)
        {
            if (current.Next[level].Value.CompareTo(item) < 0)
            {
                update.Add(current);
                --level;
                break;
            }
            else if (current.Next[level].Value.CompareTo(item) > 0)
            {
                update.Add(current);
                current = current.Next[level];
                break;
            }
            else
            {
                return;
            }
        }
        return;
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        if (header is null)
        {
            return false;
        }

        SkipListElement current = header;
        int level = MaxLevel;
        while (level > 0)
        {
            if (current.Next[level].Value.CompareTo(item) < 0)
            {
                --level;
                break;
            }
            else if (current.Next[level].Value.CompareTo(item) > 0)
            {
                current = current.Next[level];
                break;
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
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    private record SkipListElement(T? value)
    {
        public T? Value { get; set; } = value;

        public List<SkipListElement>? Next { get; set; } = null;
    }
}