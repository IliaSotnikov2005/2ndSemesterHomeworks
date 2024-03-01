public static class LZW
{
    private static float CalculateCompressionRatio(string originalFilePath, string compressedFilePath)
    {
        FileInfo originalFile = new FileInfo(originalFilePath);
        FileInfo compressedFile = new FileInfo(compressedFilePath);

        return originalFile.Length / compressedFile.Length;
    }
    public static int Compress(string filePath)
    {
        Trie trie = new Trie();

        string zippedFileName = Path.GetFileName(filePath) + ".zipped";
        float compressionRatio = CalculateCompressionRatio(filePath, zippedFileName);
        Console.WriteLine("Compression ratio: " + compressionRatio);

        return 0;
    }

    public static int Decompress(string filePath)
    {



        string originalFileName = Path.GetFileNameWithoutExtension(filePath.Replace(".zipped", ""));
        float compressionRatio = CalculateCompressionRatio(filePath, originalFileName);
        Console.WriteLine("Compression ratio: " + compressionRatio);
        return 0;
    }
    public static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Invalid input.");
        }

        switch (args[1])
        {
            case "-c":
                {
                    Compress(args[0]);
                    break;
                }
            case "-u":
                {
                    Decompress(args[0]);
                    break;
                }
            default:
                {
                    throw new ArgumentException("Invalid action. Please use -c to compress or -u to decompress.");
                }
        }
    }
}