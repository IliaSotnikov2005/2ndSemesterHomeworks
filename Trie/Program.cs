/// <summary>
/// Trie class.
/// </summary>
public class Trie
{
    private class Vertex
    {
        private Dictionary<char, Vertex> childs;
        private bool isTerminal;
        private int countOfTerminalsFarther;

        /// <summary>
        /// Vertex constructor.
        /// </summary>
        public Vertex()
        {
            childs = new Dictionary<char, Vertex>();
            isTerminal = false;
            countOfTerminalsFarther = 0;
        }

        /// <summary>
        /// Builds next vertex.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>True if vertex is not in trie, else false.</returns>
        public bool BuildNext(string text)
        {
            if (text.Length == 0)
            {
                if (isTerminal)
                {
                    return false;
                }

                isTerminal = true;
                countOfTerminalsFarther++;
                return true;
            }

            if (!childs.ContainsKey(text[0]))
            {
                childs.Add(text[0], new Vertex());
            }

            if (childs[text[0]].BuildNext(text[1..]))
            {
                countOfTerminalsFarther++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds given string in trie.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>True if string in trie, else false.</returns>
        public bool Find(string text)
        {
            if (text.Length == 0)
            {
                return isTerminal;
            }
            if (!childs.ContainsKey(text[0]))
            {
                return false;
            }

            return childs[text[0]].Find(text[1..]);
        }

        /// <summary>
        /// Removes given string from trie.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>True if success, else false.</returns>
        public bool Remove(string text)
        {
            if (text.Length == 0)
            {
                if (!isTerminal)
                {
                    return false;
                }
                countOfTerminalsFarther--;
                isTerminal = false;
                return true;
            }
            if (!childs.ContainsKey(text[0]))
            {
                return false;
            }

            if (childs[text[0]].Remove(text[1..]))
            {
                countOfTerminalsFarther--;
                if (childs[text[0]].CountOfTerminalsFarther == 0)
                {
                    childs.Remove(text[0]);
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds count of elements starting with given prefix.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns>Count of elements starting with given prefix.</returns>
        public int FindCountStartsWithPrefix(string prefix)
        {
            if (prefix.Length == 0)
            {
                return countOfTerminalsFarther;
            }
            if (!childs.ContainsKey(prefix[0]))
            {
                return 0;
            }

            return childs[prefix[0]].FindCountStartsWithPrefix(prefix[1..]);
        }
        /// <summary>
        /// Getter for count of terminal vertexes farther this vertex.
        /// </summary>
        public int CountOfTerminalsFarther
        {
            get { return countOfTerminalsFarther; }
        }
    }

    private readonly Vertex root;

    /// <summary>
    /// Constructor for trie.
    /// </summary>
    public Trie()
    {
        root = new Vertex();
    }

    /// <summary>
    /// Adds element to trie.
    /// </summary>
    /// <param name="element"></param>
    /// <returns>True if success, else false.</returns>
    public bool Add(string element)
    {
        return root.BuildNext(element);
    }

    /// <summary>
    /// Checks if element is contained in trie.
    /// </summary>
    /// <param name="element"></param>
    /// <returns>True if yes, false if not.</returns>
    public bool Contains(string element)
    {
        return root.Find(element);
    }

    /// <summary>
    /// Removes element from trie.
    /// </summary>
    /// <param name="element"></param>
    /// <returns>True if success, else false.</returns>
    public bool Remove(string element)
    {
        return root.Remove(element);
    }

    /// <summary>
    /// Gives the number of strings in trie starting with given prefix.
    /// </summary>
    /// <param name="prefix"></param>
    /// <returns>The number of strings in trie starting with given prefix.</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        return root.FindCountStartsWithPrefix(prefix);
    }

    /// <summary>
    /// Getter for trie size.
    /// </summary>
    public int Size
    {
        get { return root.CountOfTerminalsFarther; }
    }
}

/// <summary>
/// Main program class.
/// </summary>
public static class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    public static void Main()
    {
        if (!TrieTest.Test())
        {
            Console.WriteLine("Test failed");
        }

        Trie trie = new Trie();
        Console.WriteLine(trie.Add("balda"));
        Console.WriteLine(trie.Add("babolda"));
        Console.WriteLine(trie.Add("kniga"));
        Console.WriteLine(trie.Contains("kniga"));
        Console.WriteLine(trie.Contains("nekniga"));
        Console.WriteLine(trie.Size);
        Console.WriteLine(trie.HowManyStartsWithPrefix("b"));
        Console.WriteLine(trie.HowManyStartsWithPrefix("u"));
        Console.WriteLine(trie.HowManyStartsWithPrefix("k"));
        Console.WriteLine(trie.Remove("nekniga"));
        Console.WriteLine(trie.Remove("balda"));
        Console.WriteLine(trie.Remove("kniga"));
        Console.WriteLine(trie.HowManyStartsWithPrefix("b"));
        Console.WriteLine(trie.Size);
    }
}

/// <summary>
/// Test trie class.
/// </summary>
public static class TrieTest
{
    /// <summary>
    /// Test trie function.
    /// </summary>
    /// <returns></returns>
    public static bool Test()
    {
        Trie trie = new Trie();
        string[] patterns = { "he", "she", "his", "hers" };
        foreach (var pattern in patterns)
        {
            if (!trie.Add(pattern))
            {
                return false;
            }
        }
        foreach (var pattern in patterns)
        {
            if (!trie.Contains(pattern))
            {
                return false;
            }
        }

        int[] expected = { 3, 2, 1, 0 };
        string[] prefixes = { "h", "he", "s", "d" };
        for (int i = 0; i < 4; ++i )
        {
            if (trie.HowManyStartsWithPrefix(prefixes[i]) != expected[i])
            {
                return false;
            }
        }

        trie.Remove("he");
        if (trie.Size != 3)
        {
            return false;
        }

        return true;
    }
}