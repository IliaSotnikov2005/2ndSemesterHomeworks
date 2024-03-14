using BurrowsWheelerTransform;

Console.Write("Enter the sting to transform: ");
string inputString = Console.ReadLine() ?? string.Empty;
(string transformedString, int index) = BWT.Transform(inputString);
string transformedBackString = BWT.TransformBack(transformedString, index);
if (transformedBackString != inputString)
{
    Console.WriteLine("The input and output didn't match");
}

Console.WriteLine($"\nInput: {inputString}");
Console.WriteLine($"Output: {transformedString}, {transformedBackString}");
