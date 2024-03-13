namespace LZWAlgorithm
{
    using System.Text;
    using TrieClass;

    /// <summary>
    /// LZW algorithm class.
    /// </summary>
    public static class LZW
    {
        /// <summary>
        /// The method of encoding a string using LZW.
        /// </summary>
        /// <param name="input">The string to be encoded.</param>
        /// <returns>An encoded string, an array of codes.</returns>
        public static List<int> Encode(string input)
        {
            var dictionary = new Trie();
            for (int i = 0; i < 256; ++i)
            {
                dictionary.Add(((char)i).ToString(), i);
            }

            var codes = new List<int>();

            string current = string.Empty;
            int currentCode = 0;

            foreach (char ch in input)
            {
                if (!dictionary.Contains(current + ch))
                {
                    dictionary.TryGetValue(current, out currentCode);
                    codes.Add(currentCode);

                    dictionary.Add(current + ch, dictionary.Size);

                    current = ch.ToString();
                }
                else
                {
                    current += ch;
                }
            }

            dictionary.TryGetValue(current, out currentCode);
            codes.Add(currentCode);

            return codes;
        }

        /// <summary>
        /// The method of decoding a string encoded with LZW.
        /// </summary>
        /// <param name="codes">Encoded string, an array of codes.</param>
        /// <returns>A decoded string.</returns>
        public static string Decode(List<int> codes)
        {
            var dictionary = new List<string>();
            for (int i = 0; i < 256; ++i)
            {
                dictionary.Add(((char)i).ToString());
            }

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < codes.Count - 1; ++i)
            {
                stringBuilder.Append(dictionary[codes[i]]);

                string entry = dictionary[codes[i]];

                if (codes[i + 1] < dictionary.Count)
                {
                    entry += dictionary[codes[i + 1]][0];
                    dictionary.Add(entry);
                }
                else
                {
                    entry += entry[0];
                    dictionary.Add(entry);
                }
            }

            stringBuilder.Append(dictionary[codes.Last()]);

            return stringBuilder.ToString();
        }
    }
}