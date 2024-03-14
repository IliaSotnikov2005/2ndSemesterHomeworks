namespace Compressor
{
    using System.Collections;
    using System.Text;
    using LZWAlgorithm;
    using BurrowsWheelerTransform;
    using System.Globalization;

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
            byte[] bytes = File.ReadAllBytes(inputPath);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append((char)b);
            }

            (string bwtTransformed, int indexOfStart) = BWT.Transform(sb.ToString());

            byte[] res = new byte[bwtTransformed.Length];
            for (int i = 0; i < res.Length; ++i)
            {
                res[i] = (byte)bwtTransformed[i];
            }

            List<int> codes = LZW.Encode(res);

            int minBits = CalculateMinBits(codes);
            string binaryCodes = GenerateBinaryCodes(codes, minBits);

            var output = new FileStream(inputPath + ".zipped", FileMode.Create);

            using (var binaryWriter = new BinaryWriter(output))
            {
                binaryWriter.Write(Convert.ToByte(minBits));
                binaryWriter.Write(BitConverter.GetBytes(indexOfStart));

                int i = 0;
                for (i = 0; i + 8 <= binaryCodes.Length; i += 8)
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
            (List<int> codes, int indexOfStart) = ReadCodesFromFile(inputPath);

            byte[] bytes = LZW.Decode(codes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append((char)b);
            }

            string bwtTransformedBack = BWT.TransformBack(sb.ToString(), indexOfStart);

            byte[] res = new byte[bwtTransformedBack.Length];
            for (int i = 0; i < res.Length; ++i)
            {
                res[i] = (byte)bwtTransformedBack[i];
            }

            File.WriteAllBytes(inputPath + ".unzipped", res);

            Console.WriteLine("Successfully decompressed");
        }

        private static (List<int>, int) ReadCodesFromFile(string fileName)
        {
            byte[] bytes = File.ReadAllBytes(fileName);
            int codeLength = bytes[0];
            int indexOfStart = BitConverter.ToInt32(bytes[1..5]);
            var codes = new List<int>();

            int currentCode = 0;
            int currentCodeLength = 0;

            foreach (byte byteValue in bytes[5..])
            {
                Console.WriteLine(byteValue);
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

            if (currentCodeLength == codeLength)
            {
                codes.Add(currentCode);
            }


            return (codes, indexOfStart);
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