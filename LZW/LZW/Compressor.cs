namespace ZLWCompressor;

public static class Compressor
{
    private static float CalculateCompressionRatio(string originalFilePath, string compressedFilePath)
    {
        FileInfo originalFile = new FileInfo(originalFilePath);
        FileInfo compressedFile = new FileInfo(compressedFilePath);

        return compressedFile.Length / (float)originalFile.Length;
    }

    public static void Compress(string inputPath)
    {
        LZW.Encode(inputPath);

        //Console.WriteLine($"Compression ratio is {(float)outputFile.Length / inputFile.Length}");
    }

    public static void Decompress(string inputPath)
    {
        LZW.Decode(inputPath);

        Console.WriteLine("Decoded");
    }
}