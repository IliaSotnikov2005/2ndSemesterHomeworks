/// <summary>
/// Class <c>BurrowWheelerTransform</c> contains methods for direct and reverse BWT string conversion.
/// </summary>
public static class BurrowWheelerTransform
{
    private static int CompareShifts(string inputString, int shift1, int shift2)
    {
        for (int i = 0; i < inputString.Length; ++i)
        {
            if (inputString[(shift1 + i) % inputString.Length] > inputString[(shift2 + i) % inputString.Length])
            {
                return 1;
            }
            if (inputString[(shift1 + i) % inputString.Length] < inputString[(shift2 + i) % inputString.Length])
            {
                return -1;
            }
        }

        return 0;
    }

    /// <summary>
    /// This method transforms given string using BWT.
    /// </summary>
    /// <param name="text"></param>
    /// <returns>The converted string and the index of the position from which the original string begins.</returns>
    public static (string, int) Transform(string text)
    {
        int[] shifts = Enumerable.Range(0, text.Length).ToArray();
        Array.Sort(shifts, (shift1, shift2) => CompareShifts(text, shift1, shift2));

        string result = "";
        int indexOfStart = -1;
        for (int i = 0; i < text.Length; ++i)
        {
            if (shifts[i] == 0)
            {
                indexOfStart = i;
            }
            result += text[(shifts[i] + text.Length - 1) % text.Length];
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
