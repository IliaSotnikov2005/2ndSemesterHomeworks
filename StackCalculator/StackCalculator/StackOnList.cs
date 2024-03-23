/// <summary>
/// Implementation of a stack using a list.
/// </summary>
/// <typeparam name="T">The type of object that the stack will contain.</typeparam>
public class StackOnList<T> : IStack<T>
{
    private readonly List<T> list;

    /// <summary>
    /// Initializes a new instance of the <see cref="StackOnList{T}"/> class.
    /// </summary>
    public StackOnList()
    {
        this.Size = 0;
        this.list = [];
    }

    /// <inheritdoc/>
    public int Size { get; private set; }

    /// <inheritdoc/>
    public void Push(T value)
    {
        this.list.Add(value);
        this.Size++;
    }

    /// <inheritdoc/>
    public T Pop()
    {
        if (this.Size == 0)
        {
            throw new InvalidOperationException("Stack in empty");
        }

        T returningValue = this.list.Last();
        this.Size--;
        this.list.RemoveAt(this.Size);

        return returningValue;
    }
}
