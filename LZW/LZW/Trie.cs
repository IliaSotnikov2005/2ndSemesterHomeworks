namespace TrieClass;

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
    /// Gets the trie size.
    /// </summary>
    public int Size => this.CountOfTerminalsFarther;

    /// <summary>
    /// Adds element to trie.
    /// </summary>
    /// <param name="element">Element to add to the trie.</param>
    /// <param name="value">Value of the element.</param>
    /// <returns>True if success, else false.</returns>
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
    /// Checks if element is contained in trie.
    /// </summary>
    /// <param name="key">Element to be checked if it is in trie.</param>
    /// <returns>True if yes, false if not.</returns>
    public bool Contains(string key)
    {
        Trie? result = this.FindVertexWithKey(key);

        return result != null && result.IsTerminal;
    }



    /// <summary>
    /// Removes element from trie.
    /// </summary>
    /// <param name="key">Element to remove from trie.</param>
    /// <returns>True if success, else false.</returns>
    public bool Remove(string key)
    {
        if (key.Length == 0)
        {
            if (!this.IsTerminal)
            {
                return false;
            }

            this.CountOfTerminalsFarther--;
            this.IsTerminal = false;
            return true;
        }

        if (!this.children.TryGetValue(key[0], out Trie? value))
        {
            return false;
        }

        if (value.Remove(key[1..]))
        {
            this.CountOfTerminalsFarther--;
            if (value.CountOfTerminalsFarther == 0)
            {
                this.children.Remove(key[0]);
            }

            return true;
        }

        return false;
    }

    public int HowManyStartsWithPrefix(string prefix)
    {
        if (prefix.Length == 0)
        {
            return this.CountOfTerminalsFarther;
        }

        if (!this.children.TryGetValue(prefix[0], out Trie? vertex))
        {
            return 0;
        }

        return vertex.HowManyStartsWithPrefix(prefix[1..]);
    }

    /// <summary>
    /// Tries to get value by key.
    /// </summary>
    /// <param name="key">Element to find in the trie.</param>
    /// <param name="value">Key value to be given.</param>
    /// <returns>True if key in trie, else  false.</returns>
    public bool TryGetValue(string key, out int value)
    {
        value = 0;

        Trie? result = this.FindVertexWithKey(key);
        if (result == null)
        {
            return false;
        }

        value = result.Value;

        return true;
    }

    private Trie? FindVertexWithKey(string key)
    {
        if (key.Length == 0)
        {
            return this;
        }

        if (!this.children.TryGetValue(key[0], out Trie? child))
        {
            return null;
        }

        return child.FindVertexWithKey(key[1..]);
    }
}
