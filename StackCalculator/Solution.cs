/// <summary>
/// Solution class.
/// </summary>
public class Solution
{
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    public static void Main()
    {
        Console.Write("Enter the expression: ");
        string expression = Console.ReadLine() ?? string.Empty;

        Console.WriteLine($"\nThe result: {StackCalculator.Calculate(expression)}");
    }

    private static bool Test()
    {
        string[] inputs = { "1 2 3 4 + + -", "6 216 3 8 4 + * / -", "1 0 /" };
        float[] expected = { -8, 0, 0 };
        bool[] results = new bool[inputs.Length];
        for (int i = 0; i < inputs.Length; ++i)
        {
            try
            {
                float result = StackCalculator.Calculate(inputs[i]);

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