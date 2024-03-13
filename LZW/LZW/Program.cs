using ZLWCompressor;

if (args.Length != 0)
{
    if (args.Length != 2)
    {
        throw new ArgumentException("Invalid input.");
    }

    switch (args[1])
    {
        case "-c":
            {
                Compressor.Compress(args[0]);
                break;
            }

        case "-u":
            {
                Compressor.Decompress(args[0]);
                break;
            }

        default:
            {
                throw new ArgumentException("Invalid action. Please use -c to compress or -u to decompress.");
            }
    }
}

Compressor.Compress("banan.txt");
Compressor.Decompress("banan.txt.zipped");