using System.Text;
using TrieClass;

public static class LZW
{
    public static void Encode(string inputPath)
    {
        string input = File.ReadAllText(inputPath);

        var dictionary = new Trie();
        for (int j = 0; j < 256; ++j)
        {
            dictionary.Add(((char)j).ToString(), j);
        }

        var bytes = new List<byte>();

        string current = string.Empty;

        foreach (char ch in input)
        {
            if (!dictionary.Contains(current + ch))
            {
                dictionary.TryGetValue(current, out int value1);
                bytes.AddRange(BitConverter.GetBytes(value1));

                dictionary.Add(current + ch, dictionary.Size);

                current = ch.ToString();
            }
            else
            {
                current += ch;
            }
        }

        dictionary.TryGetValue(current, out int value);
        bytes.AddRange(BitConverter.GetBytes(value));

        File.WriteAllBytes(inputPath + ".zipped", bytes.ToArray());
    }

    public static void Decode(string inputPath)
    {
        byte[] input = File.ReadAllBytes(inputPath);
        var codes = new List<int>();

        for (int i = 0; i < input.Length; i += 4)
        {
            byte[] slice = new byte[4];
            Array.Copy(input, i, slice, 0, 4);

            int code = BitConverter.ToInt32(slice, 0);
            codes.Add(code);
        }

        var dictionary = new List<string>();
        for (int i = 0; i < 256; ++i)
        {
            dictionary.Add(((char)i).ToString());
        }

        var sb = new StringBuilder();

        for (int i = 0; i < codes.Count - 1; ++i)
        {
            sb.Append(dictionary[codes[i]]);

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
        sb.Append(dictionary[codes.Last()]);

        File.WriteAllText(inputPath + ".unzipped", sb.ToString());
    }
}