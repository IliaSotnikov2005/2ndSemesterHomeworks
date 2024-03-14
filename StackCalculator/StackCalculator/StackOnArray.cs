/// <summary>
/// Implementation of a stack using an array.
/// </summary>
/// <typeparam name="T">The type of object that the stack will contain.</typeparam>
public class StackOnArray<T> : IStack<T>
{
    private T[] array;

    /// <summary>
    /// Initializes a new instance of the <see cref="StackOnArray{T}"/> class.
    /// </summary>
    public StackOnArray()
    {
        this.Size = 0;
        this.array = new T[32];
    }

    /// <inheritdoc/>
    public int Size { get; private set; }

    /// <inheritdoc/>
    public void Push(T value)
    {
        if (this.Size >= this.array.Length)
        {
            Array.Resize(ref this.array, this.Size * 2);
        }

        this.array[this.Size] = value;
        this.Size++;
    }

    /// <inheritdoc/>
    public T Pop()
    {
        if (this.Size == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        this.Size--;
        T returningValue = this.array[this.Size];
        return returningValue;
    }
}
