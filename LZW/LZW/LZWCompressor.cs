namespace Compressor
{
    using System.Text;
    using BurrowsWheelerTransform;
    using LZWAlgorithm;

    /// <summary>
    /// Class of LZW compressor.
    /// </summary>
    public class LZWCompressor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LZWCompressor"/> class. Sets <see cref="UseBWT"/> the default value is true.
        /// </summary>
        public LZWCompressor()
        {
            this.UseBWT = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether BWT will be used.
        /// </summary>
        public bool UseBWT { get; set; }

        /// <summary>
        /// Method for compressing the given file with LZW.
        /// </summary>
        /// <param name="inputPath">File path.</param>
        /// <exception cref="FileNotFoundException">If file not found.</exception>
        /// /// <exception cref="ArgumentException">If file is empty.</exception>
        public void Compress(string inputPath)
        {
            if (!File.Exists(inputPath))
            {
                throw new FileNotFoundException();
            }

            byte[] bytes = File.ReadAllBytes(inputPath);

            if (bytes.Length == 0)
            {
                throw new ArgumentException();
            }

            int indexOfStart = 0;
            if (this.UseBWT)
            {
                var sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append((char)b);
                }

                (string bwtTransformed, indexOfStart) = BWT.Transform(sb.ToString());

                bytes = new byte[bwtTransformed.Length];
                for (int i = 0; i < bytes.Length; ++i)
                {
                    bytes[i] = (byte)bwtTransformed[i];
                }
            }

            List<int> codes = LZW.Encode(bytes);

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
        /// <exception cref="FileNotFoundException">If file not found.</exception>
        public void Decompress(string inputPath)
        {
            if (!File.Exists(inputPath))
            {
                throw new FileNotFoundException();
            }

            var codes = new List<int>();
            int indexOfStart = 0;
            try
            {
                (codes, indexOfStart) = this.ReadCodesFromFile(inputPath);
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException();
            }

            byte[] bytes = LZW.Decode(codes);

            if (this.UseBWT)
            {
                var sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append((char)b);
                }

                string bwtTransformedBack = BWT.TransformBack(sb.ToString(), indexOfStart);

                bytes = new byte[bwtTransformedBack.Length];
                for (int i = 0; i < bytes.Length; ++i)
                {
                    bytes[i] = (byte)bwtTransformedBack[i];
                }
            }

            File.WriteAllBytes(inputPath[..^7], bytes);

            Console.WriteLine("Successfully decompressed");
        }

        private static float CalculateCompressionRatio(string inputPath)
        {
            var originalFile = new FileInfo(inputPath);
            var compressedFile = new FileInfo(inputPath + ".zipped");

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

        private (List<int>, int) ReadCodesFromFile(string fileName)
        {
            byte[] bytes = File.ReadAllBytes(fileName);
            int codeLength = bytes[0];
            int indexOfStart = BitConverter.ToInt32(bytes[1..5]);

            var codes = new List<int>();

            int currentCode = 0;
            int currentCodeLength = 0;

            foreach (byte b in bytes[5..])
            {
                for (int i = 0; i < 8; i++)
                {
                    if (currentCodeLength == codeLength)
                    {
                        codes.Add(currentCode);
                        currentCode = 0;
                        currentCodeLength = 0;
                    }

                    currentCode = (currentCode << 1) | ((b >> (7 - i)) & 1);
                    currentCodeLength++;
                }
            }

            if (currentCodeLength == codeLength)
            {
                codes.Add(currentCode);
            }

            return (codes, indexOfStart);
        }
    }
}