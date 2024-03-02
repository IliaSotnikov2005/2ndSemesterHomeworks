if (!StackCalculatorTests.Test())
{
    Console.WriteLine("Tests didn't passed.");
    return;
}

Console.Write("Enter the expression: ");
string expression = Console.ReadLine() ?? string.Empty;

try
{
    Console.WriteLine($"\nThe result: {StackCalculator.Calculate(expression, new StackOnList<float>())}");
}
catch (ArgumentException)
{
    Console.WriteLine("Invalid expresion.\nCheck the correctness of the expression.");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Division by zero appeared.\nYou can't divide by zero.");
}
