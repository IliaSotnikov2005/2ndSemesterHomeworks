/// <summary>
/// Trie class.
/// </summary>
public class Trie
{
    private readonly Vertex root;

    /// <summary>
    /// Initializes a new instance of the <see cref="Trie"/> class.
    /// </summary>
    public Trie()
    {
        this.root = new Vertex();
    }

    /// <summary>
    /// Gets the trie size.
    /// </summary>
    public int Size => this.root.CountOfTerminalsFarther;

    /// <summary>
    /// Adds element to trie.
    /// </summary>
    /// <param name="element">Element to add to the trie.</param>
    /// <returns>True if success, else false.</returns>
    public bool Add(string element)
    {
        return this.root.BuildNext(element);
    }

    /// <summary>
    /// Checks if element is contained in trie.
    /// </summary>
    /// <param name="element">Element to be checked if it is in trie.</param>
    /// <returns>True if yes, false if not.</returns>
    public bool Contains(string element)
    {
        return this.root.Find(element);
    }

    /// <summary>
    /// Removes element from trie.
    /// </summary>
    /// <param name="element">Element to remove from trie.</param>
    /// <returns>True if success, else false.</returns>
    public bool Remove(string element)
    {
        return this.root.Remove(element);
    }

    /// <summary>
    /// Gives the number of strings in trie starting with given prefix.
    /// </summary>
    /// <param name="prefix">Prefix  to find in trie.</param>
    /// <returns>The number of strings in trie starting with given prefix.</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        return this.root.FindCountStartsWithPrefix(prefix);
    }

    private class Vertex
    {
        private readonly Dictionary<char, Vertex> childs;
        private bool isTerminal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vertex"/> class.
        /// </summary>
        public Vertex()
        {
            this.childs = [];
            this.isTerminal = false;
            this.CountOfTerminalsFarther = 0;
        }

        /// <summary>
        /// Gets count of terminal vertexes farther current.
        /// </summary>
        public int CountOfTerminalsFarther { get; private set; }

        /// <summary>
        /// Builds next vertex.
        /// </summary>
        /// <param name="text">String to add to trie.</param>
        /// <returns>True if vertex is not in trie, else false.</returns>
        public bool BuildNext(string text)
        {
            if (text.Length == 0)
            {
                if (this.isTerminal)
                {
                    return false;
                }

                this.isTerminal = true;
                this.CountOfTerminalsFarther++;
                return true;
            }

            if (!this.childs.TryGetValue(text[0], out Vertex? value))
            {
                value = new Vertex();
                this.childs.Add(text[0], value);
            }

            if (value.BuildNext(text[1..]))
            {
                this.CountOfTerminalsFarther++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds given string in trie.
        /// </summary>
        /// <param name="text">String to find in trie.</param>
        /// <returns>True if string in trie, else false.</returns>
        public bool Find(string text)
        {
            if (text.Length == 0)
            {
                return this.isTerminal;
            }

            if (!this.childs.TryGetValue(text[0], out Vertex? value))
            {
                return false;
            }

            return value.Find(text[1..]);
        }

        /// <summary>
        /// Removes given string from trie.
        /// </summary>
        /// <param name="text">String to remove from trie.</param>
        /// <returns>True if success, else false.</returns>
        public bool Remove(string text)
        {
            if (text.Length == 0)
            {
                if (!this.isTerminal)
                {
                    return false;
                }

                this.CountOfTerminalsFarther--;
                this.isTerminal = false;
                return true;
            }

            if (!this.childs.TryGetValue(text[0], out Vertex? value))
            {
                return false;
            }

            if (value.Remove(text[1..]))
            {
                this.CountOfTerminalsFarther--;
                if (value.CountOfTerminalsFarther == 0)
                {
                    this.childs.Remove(text[0]);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds count of elements starting with given prefix.
        /// </summary>
        /// <param name="prefix">Prefix to find in trie.</param>
        /// <returns>Count of elements starting with given prefix.</returns>
        public int FindCountStartsWithPrefix(string prefix)
        {
            if (prefix.Length == 0)
            {
                return this.CountOfTerminalsFarther;
            }

            if (!this.childs.TryGetValue(prefix[0], out Vertex? value))
            {
                return 0;
            }

            return value.FindCountStartsWithPrefix(prefix[1..]);
        }
    }
}
