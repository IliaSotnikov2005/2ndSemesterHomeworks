using Compressor;

if (args.Length == 2)
{
    if (!File.Exists(args[0]))
    {
        Console.WriteLine("File with this pass doesn't exist");
        return;
    }

    switch (args[1])
    {
        case "-c":
            {
                var compressor = new LZWCompressor();
                compressor.Compress(args[0]);
                break;
            }

        case "-u":
            {
                if (args[0][^7..] != ".zipped")
                {
                    Console.WriteLine($"{args[0]} must be .zipped!");
                    break;
                }

                var compressor = new LZWCompressor();
                compressor.Decompress(args[0]);
                break;
            }

        default:
            {
                Console.WriteLine("Invalid input. Use -c to compress and -u to uncompress.");
                break;
            }
    }
}
else
{
    Console.WriteLine("Invalid count of arguments.");
}