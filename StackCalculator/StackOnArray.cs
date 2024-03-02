/// <summary>
/// Implementation of a stack using an array.
/// </summary>
/// <typeparam name="T">The type of object that the stack will contain.</typeparam>
public class StackOnArray<T> : IStack<T>
{
    private int size;
    private T[] array;

    /// <summary>
    /// Initializes a new instance of the <see cref="StackOnArray{T}"/> class.
    /// </summary>
    public StackOnArray()
    {
        this.size = 0;
        this.array = new T[32];
    }

    /// <inheritdoc/>
    public int Size { get; private set; }

    /// <inheritdoc/>
    public void Push(T value)
    {
        if (this.size >= this.array.Length)
        {
            Array.Resize(ref this.array, this.size * 2);
        }

        this.array[this.size] = value;
        this.size++;
    }

    /// <inheritdoc/>
    public T Pop()
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        this.size--;
        T returningValue = this.array[this.size];
        return returningValue;
    }
}
