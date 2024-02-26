using System.Drawing;
using System.Reflection.PortableExecutable;
public class Trie
{
    private class Vertex
    {
        char tag;
        Dictionary<char, Vertex> childs;
        bool isTerminal;

        public Vertex()
        {
            childs = new Dictionary<char, Vertex>();
            isTerminal = false;
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
                return true;
            }
            if (childs.ContainsKey(text[0]))
            {
                return childs[text[0]].BuildNext(text[1..]);
            }
            else
            {
                childs.Add(text[0], new Vertex());
                return childs[text[0]].BuildNext(text[1..]);
            }
        }
    }

    private int size;
    private Vertex root;

    public Trie()
    {
        size = 0;
        root = new Vertex();
    }
    public bool Add(string element)
    {
        return root.BuildNext(element);
    }
    public bool Contains(string element)
    { return true; }
    public bool Remove(string element) { return true; }
    public int HowManyStartsWithPrefix(string prefix)
    {
        return 0;
    }
    int Size
    { get { return size; } }
}

public static class Program
{
    public static void Main()
    {
        Trie trie = new Trie();
        trie.Add("hui");
    }
}