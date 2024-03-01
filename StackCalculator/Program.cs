﻿/// <summary>
/// Interface for the classic stack.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IStack<T>
{
    /// <summary>
    /// Pushes a value onto the stack.
    /// </summary>
    /// <param name="value">The value to push onto the stack.</param>
    public void Push(T value);

    /// <summary>
    /// Pops the top value off the stack and returns it.
    /// </summary>
    /// <returns>The top value of the stack.</returns>
    public T Pop();

    /// <summary>
    /// Getter for stack size.
    /// </summary>
    /// <returns>Stack size.</returns>
    public int Size { get; }
}

/// <summary>
/// Implementation of a stack using a list.
/// </summary>
/// <typeparam name="T"></typeparam>
public class StackOnList<T> : IStack<T>
{
    private int size;
    private readonly List<T> list;

    /// <summary>
    /// StackOnList constructor.
    /// </summary>
    public StackOnList()
    {
        size = 0;
        list = new List<T>();
    }
    public void Push(T value)
    {
        list.Add(value);
        size++;
    }
    public T Pop()
    {
        if (size > 0)
        {
            T returningValue = list[^1];
            size--;
            list.RemoveAt(size);

            return returningValue;
        }
        else
        {
            throw new InvalidOperationException("Stack in empty");
        }
    }
    public int Size
    {
        get { return size; }
    }
}

/// <summary>
/// Implementation of a stack using an array.
/// </summary>
/// <typeparam name="T"></typeparam>
public class StackOnArray<T> : IStack<T>
{
    private int size;
    private T[] array;

    /// <summary>
    /// StackOnArray constructor.
    /// </summary>
    /// <param name="capacity">Maximum size of stack.</param>
    public StackOnArray()
    {
        size = 0;
        array = new T[32];
    }

    public void Push(T value)
    {
        if (size >= array.Length)
        {
            T[] tempArray = new T[array.Length * 2];
            Array.Copy(array, tempArray, array.Length);
            array = tempArray;
            array[size] = value;
        }

        array[size] = value;
        size++;
    }

    public T Pop()
    {
        if (size > 0)
        {
            size--;
            T returningValue = array[size];
            array[size] = default;
            return returningValue;
        }
        else
        {
            throw new InvalidOperationException("Stack is empty");
        }
    }

    public int Size
    {
        get { return size; }
    }
}

/// <summary>
/// Static class for performing calculations using a stack.
/// </summary>
public static class StackCalculator
{
    /// <summary>
    /// A method for calculating the value of an expression in Polish notation.
    /// </summary>
    /// <param name="expression">Expression in polish notation.</param>
    /// <param name="stackType">Type of stack to be used. Default is StackOnList</param>
    /// <returns>Value of expression.</returns>
    /// <exception cref="ArgumentException">If invalid input.</exception>
    /// <exception cref="DivideByZeroException">If division by zero.</exception>
    public static float Calculate(string expression, string stackType = "list")
    {
        IStack<float> stack;
        if (stackType == "list")
        {
            stack = new StackOnList<float>();
        }
        else if (stackType == "array")
        {
            stack = new StackOnArray<float>();
        }
        else
        {
            throw new ArgumentException("Unsupported stack type");
        }

        List<string> elements = new(expression.Split(' '));
        foreach (string element in elements)
        {
            if (int.TryParse(element, out int number))
            {
                stack.Push(number);
            }
            else
            {
                switch (element)
                {
                    case "+":
                        {
                            stack.Push(stack.Pop() + stack.Pop());
                            break;
                        }
                    case "-":
                        {
                            float operand1 = stack.Pop();
                            float operand2 = stack.Pop();
                            stack.Push(operand2 - operand1);
                            break;
                        }
                    case "*":
                        {
                            stack.Push(stack.Pop() * stack.Pop());
                            break;
                        }
                    case "/":
                        {
                            float operand1 = stack.Pop();
                            float operand2 = stack.Pop();
                            if (Math.Abs(operand1) < float.Epsilon)
                            {
                                throw new DivideByZeroException("Division by zero");
                            }
                            stack.Push(operand2 / operand1);
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException("Invalid operator");
                        }
                }
            }
        }

        if (stack.Size != 1)
        {
            throw new ArgumentException("Invalid expresion");
        }

        return stack.Pop();
    }

    /// <summary>
    /// Entry point of the program.
    /// </summary>
    public static void Main()
    {
        Console.Write("Enter the expression: ");
        string expression = Console.ReadLine() ?? string.Empty;

        Console.WriteLine($"\nThe result: {Calculate(expression)}");
    }

    private static bool Test()
    {
        string[] inputs = { "1 2 3 4 + + -", "216 6 3 8 4 + * / -", "1 0 /" };
        float[] expected = { -8, 0, 0 };
        bool[] results = new bool[inputs.Length];
        for (int i = 0; i < inputs.Length; ++i)
        {
            try
            {
                float result = Calculate(inputs[i]);

                results[i] = Math.Abs(result - expected[i]) <= float.Epsilon;
            }
            catch (DivideByZeroException)
            {
                results[i] = i == 2;
            }
        }
        return results.All(x => x);
    }
}