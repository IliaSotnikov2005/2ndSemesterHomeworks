namespace LZWAlgorithm
{
    using System.Collections.Generic;
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
        public static List<int> Encode(byte[] input)
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

        // В общем, нужно либо хранить байтовые последовательности в словаре, либо как то конвертировать строки в байты 255 разрядности

        /// <summary>
        /// The method of decoding a string encoded with LZW.
        /// </summary>
        /// <param name="codes">Encoded string, an array of codes.</param>
        /// <returns>A decoded string.</returns>
        public static byte[] Decode(List<int> codes)
        {
            var dictionary = new List<List<byte>>();
            for (int i = 0; i < 256; ++i)
            {
                dictionary.Add([(byte)i]);
            }

            var bytes = new List<byte>();

            for (int i = 0; i < codes.Count - 1; ++i)
            {
                for (int j = 0; j < dictionary[codes[i]].Count; ++j)
                {
                    bytes.Add(dictionary[codes[i]][j]);
                }

                List<byte> entry = new List<byte> (dictionary[codes[i]]);

                if (codes[i + 1] < dictionary.Count)
                {
                    entry.Add(dictionary[codes[i + 1]][0]);
                    dictionary.Add(entry);
                }
                else
                {
                    entry.Add(entry[0]);
                    dictionary.Add(entry);
                }
            }

            bytes.AddRange(dictionary[codes.Last()]);

            return bytes.ToArray();
        }
    }
}