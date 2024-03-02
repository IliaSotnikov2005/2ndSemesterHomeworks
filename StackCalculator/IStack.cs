/// <summary>
/// Interface for the classic stack.
/// </summary>
/// <typeparam name="T">The type of object that the stack will contain.</typeparam>
public interface IStack<T>
{
    /// <summary>
    /// Gets size of stack.
    /// </summary>
    int Size { get; }

    /// <summary>
    /// Pushes a value onto the stack.
    /// </summary>
    /// <param name="value">The value to push onto the stack.</param>
    public void Push(T value);

    /// <summary>
    /// Pops the top value off the stack and returns it.
    /// </summary>
    /// <returns>The top value of the stack.</returns>
    /// <exception cref="InvalidOperationException">If stack is empty.</exception>
    public T Pop();
}
