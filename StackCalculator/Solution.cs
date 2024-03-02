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
        if (!StackCalculatorTests.Test())
        {
            Console.WriteLine("Tests didn't passed.");
            return;
        }

        Console.Write("Enter the expression: ");
        string expression = Console.ReadLine() ?? string.Empty;

        Console.WriteLine($"\nThe result: {StackCalculator.Calculate(expression)}");
    }
}
