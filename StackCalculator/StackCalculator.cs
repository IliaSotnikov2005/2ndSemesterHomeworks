/// <summary>
/// Static class for performing calculations using a stack.
/// </summary>
public static class StackCalculator
{
    /// <summary>
    /// A method for calculating the value of an expression in Polish notation.
    /// </summary>
    /// <param name="expression">Expression in polish notation.</param>
    /// <param name="stack">Stack to use.</param>
    /// <returns>Value of expression.</returns>
    /// <exception cref="ArgumentException">If invalid input.</exception>
    /// <exception cref="DivideByZeroException">If division by zero.</exception>
    public static float Calculate(string expression, IStack<float> stack)
    {
        List<string> elements = new (expression.Split(' '));
        foreach (string element in elements)
        {
            if (int.TryParse(element, out int number))
            {
                stack.Push(number);
                continue;
            }

            switch (element)
            {
                case "+":
                    {
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    }

                case "-":
                    {
                        float operand2 = stack.Pop();
                        float operand1 = stack.Pop();
                        stack.Push(operand1 - operand2);
                        break;
                    }

                case "*":
                    {
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    }

                case "/":
                    {
                        float operand2 = stack.Pop();
                        float operand1 = stack.Pop();
                        if (Math.Abs(operand2) <= Math.Abs(operand2 * .0001f))
                        {
                            throw new DivideByZeroException("Division by zero");
                        }

                        stack.Push(operand1 / operand2);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("Invalid operator");
                    }
            }
        }

        if (stack.Size != 1)
        {
            throw new ArgumentException("Invalid expresion");
        }

        return stack.Pop();
    }
}
