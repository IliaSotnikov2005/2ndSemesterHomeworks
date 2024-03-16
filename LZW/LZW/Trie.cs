namespace TrieClass
{
    /// <summary>
    /// Trie class.
    /// </summary>
    public class Trie
    {
        private readonly Dictionary<char, Trie> children;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trie"/> class.
        /// </summary>
        public Trie()
        {
            this.children = [];
            this.Value = 0;
            this.IsTerminal = false;
            this.CountOfTerminalsFarther = 0;
        }

        /// <summary>
        /// Gets a value indicating whether the edge is terminal.
        /// </summary>
        public bool IsTerminal { get; private set; }

        /// <summary>
        /// Gets vertex value.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Gets the trie size.
        /// </summary>
        public int Size => this.CountOfTerminalsFarther;

        private int CountOfTerminalsFarther { get; set; }

        /// <summary>
        /// Adds given string to trie.
        /// </summary>
        /// <param name="element">String to add to the trie.</param>
        /// <param name="value">The value that will be available by the element.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public bool Add(string element, int value)
        {
            if (element.Length == 0)
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

            if (!this.children.TryGetValue(element[0], out Trie? child))
            {
                child = new Trie();
                this.children.Add(element[0], child);
            }

            if (child.Add(element[1..], value))
            {
                this.CountOfTerminalsFarther++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks whether the element is contained in the trie.
        /// </summary>
        /// <param name="element">The element that needs to be checked if it is in the trie.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public bool Contains(string element)
        {
            Trie? result = this.FindEdgeWithKey(element);

            return result != null && result.IsTerminal;
        }

        /// <summary>
        /// Removes an element from the trie.
        /// </summary>
        /// <param name="element">The element to be removed from the trie.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public bool Remove(string element)
        {
            if (element.Length == 0)
            {
                if (!this.IsTerminal)
                {
                    return false;
                }

                this.CountOfTerminalsFarther--;
                this.IsTerminal = false;
                return true;
            }

            if (!this.children.TryGetValue(element[0], out Trie? value))
            {
                return false;
            }

            if (value.Remove(element[1..]))
            {
                this.CountOfTerminalsFarther--;
                if (value.CountOfTerminalsFarther == 0)
                {
                    this.children.Remove(element[0]);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Searches for how many trie elements start with a given prefix.
        /// </summary>
        /// <param name="prefix">The prefix for the search.</param>
        /// <returns>The number of elements starting with this prefix.</returns>
        public int HowManyStartsWithPrefix(string prefix)
        {
            if (prefix.Length == 0)
            {
                return this.CountOfTerminalsFarther;
            }

            if (!this.children.TryGetValue(prefix[0], out Trie? edge))
            {
                return 0;
            }

            return edge.HowManyStartsWithPrefix(prefix[1..]);
        }

        /// <summary>
        /// Tries to get the value of the element.
        /// </summary>
        /// <param name="element">The element whose value needs to be found in the trie.</param>
        /// <param name="value">Element's value to be given.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public bool TryGetValue(string element, out int value)
        {
            value = 0;

            Trie? result = this.FindEdgeWithKey(element);
            if (result == null)
            {
                return false;
            }

            value = result.Value;

            return true;
        }

        private Trie? FindEdgeWithKey(string key)
        {
            if (key.Length == 0)
            {
                return this;
            }

            if (!this.children.TryGetValue(key[0], out Trie? child))
            {
                return null;
            }

            return child.FindEdgeWithKey(key[1..]);
        }
    }
}
