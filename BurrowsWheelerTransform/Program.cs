/// <summary>
/// Class <c>BurrowWheelerTransform</c> contains methods for direct and reverse BWT string conversion.
/// </summary>
public static class BurrowWheelerTransform
{
    /// <summary>
    /// This method transforms given string using BWT.
    /// </summary>
    /// <param name="text"></param>
    /// <returns>The converted string and the index of the position from which the original string begins.</returns>
    public static (string, int) Transform(string text)
    {
        List<string> suffixes = [];
        for (int i = text.Length - 1; i >= 0; --i)
        {
            suffixes.Add(text[i..]);
        }
        suffixes.Sort();

        string result = "";
        int indexOfStart = -1;
        for (int i = 0; i < text.Length; ++i)
        {
            if (suffixes[i].Length == text.Length)
            {
                indexOfStart = i;
                result += text[^1];
                continue;
            }

            result += text[text.Length - suffixes[i].Length - 1];
        }

        return (result, indexOfStart);
    }

    /// <summary>
    /// This method restores the string from the converted one using BWT.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="indexOfStart"></param>
    /// <returns>Original string.</returns>
    public static string TransformBack(string text, int indexOfStart)
    {
        char[] sortedChars = text.ToCharArray();
        Array.Sort(sortedChars);

        Dictionary<char, int> occurences = [];
        for (int i = 0; i < sortedChars.Length; ++i)
        {
            if (!occurences.ContainsKey(sortedChars[i]))
            {
                occurences[sortedChars[i]] = i + 1;
            }
        }

        int[] next = new int[sortedChars.Length];
        next[0] = occurences[text[0]] - 1;
        occurences[text[0]]++;

        for (int i = 1; i < text.Length; ++i)
        {
            next[i] = occurences[text[i]] - 1;
            occurences[text[i]]++;
        }

        char[] originalString = new char[text.Length];

        for (int i = 0; i < text.Length; ++i)
        {
            originalString[i] = text[indexOfStart];
            indexOfStart = next[indexOfStart];
        }

        Array.Reverse(originalString);

        return new string(originalString);
    }

    /// <summary>
    /// this method performs user interaction through the console.
    /// </summary>
    public static void Main()
    {
        Console.Write("Enter the sting to transform: ");
        string inputString = Console.ReadLine() ?? string.Empty;
        (string transformedString, int index) = Transform(inputString);
        string transformedBackString = TransformBack(transformedString, index);
        if (transformedBackString != inputString)
        {
            Console.WriteLine("The input and output didn't match");
        }

        Console.WriteLine($"\nInput: {inputString}");
        Console.WriteLine($"Output: {transformedString}, {transformedBackString}");
    }
}
