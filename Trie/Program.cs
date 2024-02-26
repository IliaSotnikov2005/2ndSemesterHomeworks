using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;
public class Trie
{
    private class Vertex
    {
        private Dictionary<char, Vertex> childs;
        private bool isTerminal;
        private int countOfTerminalsFarther;

        public Vertex()
        {
            childs = new Dictionary<char, Vertex>();
            isTerminal = false;
            countOfTerminalsFarther = 0;
        }

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
                    countOfTerminalsFarther--;
                    childs.Remove(text[0]);
                }
                return true;
            }

            return false;
        }
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
        public int CountOfTerminalsFarther
        {
            get { return countOfTerminalsFarther; }
        }
    }

    private readonly Vertex root;

    public Trie()
    {
        root = new Vertex();
    }
    public bool Add(string element)
    {
        return root.BuildNext(element);
    }
    public bool Contains(string element)
    {
        return root.Find(element);
    }
    public bool Remove(string element)
    {
        return root.Remove(element);
    }
    public int HowManyStartsWithPrefix(string prefix)
    {
        return root.FindCountStartsWithPrefix(prefix);
    }
    public int Size
    {
        get { return root.CountOfTerminalsFarther; }
    }
}

public static class Program
{
    public static void Main()
    {
        if (!TrieTest.Test())
        {
            Console.WriteLine("Test failed");
        }

        Trie trie = new Trie();
        Console.WriteLine(trie.Add("huita"));
        Console.WriteLine(trie.Add("hui"));
        Console.WriteLine(trie.Add("uidfdeee"));
        Console.WriteLine(trie.Contains("hui"));
        Console.WriteLine(trie.Contains("hui1"));
        Console.WriteLine(trie.Size);
        Console.WriteLine(trie.HowManyStartsWithPrefix("h"));
        Console.WriteLine(trie.HowManyStartsWithPrefix("u"));
        Console.WriteLine(trie.HowManyStartsWithPrefix("4"));
        Console.WriteLine(trie.Remove("dsde"));
        Console.WriteLine(trie.Remove("hui"));
        Console.WriteLine(trie.Remove("hui"));
        Console.WriteLine(trie.HowManyStartsWithPrefix("h"));
        Console.WriteLine(trie.Size);
    }
}

public static class TrieTest
{
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