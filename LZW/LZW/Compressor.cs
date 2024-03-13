namespace Compressor
{
    using System.Text;
    using LZWAlgorithm;

    /// <summary>
    /// Class of LZW compressor.
    /// </summary>
    public static class LZWCompressor
    {
        /// <summary>
        /// Method for compressing the given file with LZW.
        /// </summary>
        /// <param name="inputPath">File path.</param>
        public static void Compress(string inputPath)
        {
            string input = File.ReadAllText(inputPath);

            List<int> codes = LZW.Encode(input);

            int minBits = CalculateMinBits(codes);
            string binaryCodes = GenerateBinaryCodes(codes, minBits);

            var output = new FileStream(inputPath + ".zipped", FileMode.Create);

            using (var binaryWriter = new BinaryWriter(output))
            {
                binaryWriter.Write(Convert.ToByte(minBits));

                int i = 0;
                for (i = 0; i + 8 < binaryCodes.Length; i += 8)
                {
                    binaryWriter.Write(Convert.ToByte(binaryCodes.Substring(i, 8), 2));
                }

                if (i < binaryCodes.Length)
                {
                    binaryCodes = binaryCodes.PadRight(binaryCodes.Length + 8 - (binaryCodes.Length % 8), '0');
                    binaryWriter.Write(Convert.ToByte(binaryCodes.Substring(i, 8), 2));
                }
            }

            output.Close();

            Console.WriteLine($"Compression ratio is {CalculateCompressionRatio(inputPath)}");
        }

        /// <summary>
        /// Method for decompressing the given file compredded with <see cref="LZWCompressor.Compress(string)"/>.
        /// </summary>
        /// <param name="inputPath">.zipped file path.</param>
        public static void Decompress(string inputPath)
        {
            List<int> codes = ReadCodesFromFile(inputPath);

            string result = LZW.Decode(codes);

            File.WriteAllText(inputPath[..^7], result);

            Console.WriteLine("Successfully decompressed");
        }

        private static List<int> ReadCodesFromFile(string fileName)
        {
            byte[] bytes = File.ReadAllBytes(fileName);
            int codeLength = bytes[0];
            var codes = new List<int>();

            int currentCode = 0;
            int currentCodeLength = 0;

            foreach (byte byteValue in bytes[1..])
            {
                for (int i = 0; i < 8; i++)
                {
                    if (currentCodeLength == codeLength)
                    {
                        codes.Add(currentCode);
                        currentCode = 0;
                        currentCodeLength = 0;
                    }

                    currentCode = (currentCode << 1) | ((byteValue >> (7 - i)) & 1);
                    currentCodeLength++;
                }
            }

            return codes;
        }

        private static float CalculateCompressionRatio(string inputPath)
        {
            FileInfo originalFile = new FileInfo(inputPath);
            FileInfo compressedFile = new FileInfo(inputPath + ".zipped");

            return (float)compressedFile.Length / originalFile.Length;
        }

        private static int CalculateMinBits(List<int> codes)
        {
            int maxNumber = codes.Max();
            int minBits = (int)Math.Ceiling(Math.Log2(maxNumber + 1));

            return minBits;
        }

        private static string GenerateBinaryCodes(List<int> codes, int minBits)
        {
            var binaryCodes = new StringBuilder();

            for (int i = 0; i < codes.Count; ++i)
            {
                binaryCodes.Append(Convert.ToString(codes[i], 2).PadLeft(minBits, '0'));
            }

            return binaryCodes.ToString();
        }
    }
}