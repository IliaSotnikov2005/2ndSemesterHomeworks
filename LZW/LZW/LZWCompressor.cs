﻿namespace Compressor
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
        public void Compress(string inputPath)
        {
            byte[] bytes = File.ReadAllBytes(inputPath);

            int indexOfStart = 0;
            if (this.UseBWT)
            {
                StringBuilder sb = new StringBuilder();
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

            int minBits = this.CalculateMinBits(codes);
            string binaryCodes = this.GenerateBinaryCodes(codes, minBits);

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

            Console.WriteLine($"Compression ratio is {this.CalculateCompressionRatio(inputPath)}");
        }

        /// <summary>
        /// Method for decompressing the given file compredded with <see cref="LZWCompressor.Compress(string)"/>.
        /// </summary>
        /// <param name="inputPath">.zipped file path.</param>
        public void Decompress(string inputPath)
        {
            (List<int> codes, int indexOfStart) = this.ReadCodesFromFile(inputPath);

            byte[] bytes = LZW.Decode(codes);

            if (this.UseBWT)
            {
                StringBuilder sb = new StringBuilder();
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

            File.WriteAllBytes(inputPath + ".unzipped", bytes);

            Console.WriteLine("Successfully decompressed");
        }

        private (List<int>, int) ReadCodesFromFile(string fileName)
        {
            byte[] bytes = File.ReadAllBytes(fileName);
            int codeLength = bytes[0];
            int indexOfStart = this.UseBWT ? BitConverter.ToInt32(bytes[1..5]) : 0;

            var codes = new List<int>();

            int currentCode = 0;
            int currentCodeLength = 0;

            int startIndex = this.UseBWT ? 5 : 1;

            foreach (byte b in bytes[startIndex..])
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

        private float CalculateCompressionRatio(string inputPath)
        {
            FileInfo originalFile = new FileInfo(inputPath);
            FileInfo compressedFile = new FileInfo(inputPath + ".zipped");

            return (float)compressedFile.Length / originalFile.Length;
        }

        private int CalculateMinBits(List<int> codes)
        {
            int maxNumber = codes.Max();
            int minBits = (int)Math.Ceiling(Math.Log2(maxNumber + 1));

            return minBits;
        }

        private string GenerateBinaryCodes(List<int> codes, int minBits)
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