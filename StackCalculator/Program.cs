Console.Write("Enter the expression: ");
string expression = Console.ReadLine() ?? string.Empty;

Console.WriteLine($"\nThe result: {StackCalculator.Calculate(expression, new StackOnList<float>())}");
