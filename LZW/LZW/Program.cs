using Compressor;

if (args.Length != 0)
{
    if (args.Length != 2)
    {
        throw new ArgumentException("Invalid input.");
    }

    if (!File.Exists(args[0]))
    {
        Console.WriteLine("File with this pass doesn't exist");
        return;
    }

    switch (args[1])
    {
        case "-c":
            {
                LZWCompressor.Compress(args[0]);
                break;
            }

        case "-u":
            {
                LZWCompressor.Decompress(args[0]);
                break;
            }

        default:
            {
                throw new ArgumentException("Invalid action. Please use -c to compress or -u to decompress.");
            }
    }
}

LZWCompressor.Compress("banan.txt");
LZWCompressor.Decompress("banan.txt.zipped");