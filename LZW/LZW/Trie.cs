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
    /// <param name="value">Value of the element.</param>
    /// <returns>True if success, else false.</returns>
    public bool Add(List<byte> element, int value)
    {
        return this.root.BuildNext(element, value);
    }

    /// <summary>
    /// Checks if element is contained in trie.
    /// </summary>
    /// <param name="element">Element to be checked if it is in trie.</param>
    /// <returns>True if yes, false if not.</returns>
    public bool Contains(List<byte> element)
    {
        Vertex? result = this.root.Find(element);
        if (result == null)
        {
            return false;
        }

        return result.IsTerminal;
    }

    /// <summary>
    /// Removes element from trie.
    /// </summary>
    /// <param name="element">Element to remove from trie.</param>
    /// <returns>True if success, else false.</returns>
    public bool Remove(List<byte> element)
    {
        return this.root.Remove(element);
    }

    /// <summary>
    /// Gives the number of List<byte>s in trie starting with given prefix.
    /// </summary>
    ///<param name="prefix">Prefix to find in trie.</param>
    /// <returns>The number of elements in trie starting with given prefix.</returns>
    public int HowManyStartsWithPrefix(List<byte> prefix)
    {
        return this.root.FindCountStartsWithPrefix(prefix);
    }

    /// <summary>
    /// Tries to get value by key.
    /// </summary>
    /// <param name="key">Element to find in the trie.</param>
    /// <param name="value">Key value to be given.</param>
    /// <returns>True if key in trie, else  false.</returns>
    public bool TryGetValue(List<byte> key, out int value)
    {
        value = 0;

        Vertex? result = this.root.Find(key);
        if (result == null)
        {
            return false;
        }

        value = result.Value;

        return false;
    }

    private class Vertex
    {
        private readonly Dictionary<byte, Vertex> childs;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vertex"/> class.
        /// </summary>
        public Vertex()
        {
            this.childs = [];
            this.IsTerminal = false;
            this.CountOfTerminalsFarther = 0;
        }

        /// <summary>
        /// Gets count of terminal vertexes farther current.
        /// </summary>
        public int CountOfTerminalsFarther { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the vertex is terminal.
        /// </summary>
        public bool IsTerminal { get; private set; }

        /// <summary>
        /// Gets or sets vertex value.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Builds next vertex.
        /// </summary>
        /// <param name="element">Element to add to trie.</param>
        /// <returns>True if vertex is not in trie, else false.</returns>
        public bool BuildNext(List<byte> element, int value)
        {
            if (element.Count == 0)
            {
                if (this.IsTerminal)
                {
                    return false;
                }

                this.IsTerminal = true;
                this.Value = value;
                this.CountOfTerminalsFarther++;
                return true;
            }

            if (!this.childs.TryGetValue(element[0], out Vertex? child))
            {
                child = new Vertex();
                this.childs.Add(element[0], child);
            }

            if (child.BuildNext(element[1..], value))
            {
                this.CountOfTerminalsFarther++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds given element in trie.
        /// </summary>
        /// <param name="element">List<byte> to find in trie.</param>
        /// <returns>True if List<byte> in trie, else false.</returns>
        public Vertex? Find(List<byte> element)
        {
            if (element.Count == 0)
            {
                return this;
            }

            if (!this.childs.TryGetValue(element[0], out Vertex? value))
            {
                return null;
            }

            return value.Find(element[1..]);
        }

        /// <summary>
        /// Removes given element from trie.
        /// </summary>
        /// <param name="element">Element to remove from trie.</param>
        /// <returns>True if success, else false.</returns>
        public bool Remove(List<byte> element)
        {
            if (element.Count == 0)
            {
                if (!this.IsTerminal)
                {
                    return false;
                }

                this.CountOfTerminalsFarther--;
                this.IsTerminal = false;
                return true;
            }

            if (!this.childs.TryGetValue(element[0], out Vertex? value))
            {
                return false;
            }

            if (value.Remove(element[1..]))
            {
                this.CountOfTerminalsFarther--;
                if (value.CountOfTerminalsFarther == 0)
                {
                    this.childs.Remove(element[0]);
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
        public int FindCountStartsWithPrefix(List<byte> prefix)
        {
            if (prefix.Count == 0)
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
