using System.Reflection.Metadata.Ecma335;

class BurrowWheelerTransform
{
    public static (string, int) Transform(string text)
    {
        List<string> suffixes = new List<string>();
        for (int i = text.Length - 1; i >= 0; --i)
        {
            suffixes.Add(text.Substring(i));
        }
        suffixes.Sort();

        string result = "";
        int index = -1;
        for (int i = 0; i < text.Length; ++i)
        {
            if (suffixes[i].Length == text.Length)
            {
                index = i;
            }

            if (text.Length - suffixes[i].Length == 0)
            {
                result += text[text.Length - 1];
                continue;
            }

            result += text[text.Length - suffixes[i].Length - 1];
        }

        return (result, index);
    }

    public static string TransformBack(string text, int index)
    {
        char[] charArray = text.ToCharArray();

        char[] sortedChars = new char[text.Length];
        Array.Copy(charArray, sortedChars, text.Length);
        Array.Sort(sortedChars);

        int[] counts = new int[256];

        int[] occurences = new int[256];
        for (int i = 0; i < sortedChars.Length; ++i)
        {
            counts[sortedChars[i]]++;
            if (occurences[sortedChars[i]] == 0)
            {
                occurences[sortedChars[i]] = i;
            }
        }

        int[] next = new int[sortedChars.Length];
        next[0] = occurences[text[0]];
        occurences[text[0]]++;

        for (int i = 1; i < text.Length; ++i)
        {
            next[i] = occurences[text[i]];
            occurences[text[i]]++;
        }

        char[] originalString = new char[text.Length];

        for (int i = 0; i < charArray.Length; ++i)
        {
            originalString[i] = charArray[index];
            index = next[index];
        }
        
        Array.Reverse(originalString);

        return new string(originalString);
    }

    static void Main()
    {
        string inputString = Console.ReadLine() + "$";
        (string transformedString, int index) = Transform(inputString);
        string transformedBackString = TransformBack(transformedString, index);
        if (transformedBackString != inputString)
        {
            Console.WriteLine("The input and output didn't match");
        }

        Console.WriteLine($"\nInput: {inputString}");
        Console.WriteLine($"Output: {transformedString}");
    }
}
