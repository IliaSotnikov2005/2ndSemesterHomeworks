using Compressor;
namespace LZWTests;

public class Tests
{

    [TestCase("../../../Files/kokos.txt")]
    [TestCase("../../../Files/okno.exe")]
    [TestCase("../../../Files/smileface.png")]
    public void EncodeAndDecodeWithBWT_DontChangeTheFile(string path)
    {
        var expected = File.ReadAllBytes(path);

        var compressor = new LZWCompressor();
        compressor.Compress(path);
        compressor.Decompress(path + ".zipped");

        var result = File.ReadAllBytes(path);

        Assert.That(Enumerable.SequenceEqual(result, expected), Is.True);
    }

    [TestCase("../../../Files/kokos.txt")]
    [TestCase("../../../Files/okno.exe")]
    [TestCase("../../../Files/smileface.png")]
    public void EncodeAndDecodeWithoutBWT_DontChangeTheFile(string path)
    {
        var expected = File.ReadAllBytes(path);

        var compressor = new LZWCompressor();
        compressor.UseBWT = false;

        compressor.Compress(path);
        compressor.Decompress(path + ".zipped");

        var result = File.ReadAllBytes(path);

        Assert.That(Enumerable.SequenceEqual(result, expected), Is.True);
    }

    [TestCase("../../../Files/empty.txt")]
    public void EncodeEmptyFile_ThrowsArgumentException(string path)
    {
        var compressor = new LZWCompressor();
        Assert.Throws<ArgumentException>(() => compressor.Compress(path));
    }

    [TestCase("../../../Files/empty.txt")]
    public void DecodeEmptyFile_ThrowsArgumentException(string path)
    {
        var compressor = new LZWCompressor();
        Assert.Throws<ArgumentException>(() => compressor.Decompress(path));
    }

    [TestCase("../../../Files/notexistingfile.txt")]
    public void EncodeNotExistingFile_ThrowsFileNotFoundException(string path)
    {
        var compressor = new LZWCompressor();
        Assert.Throws<FileNotFoundException>(() => compressor.Compress(path));
    }

    [TestCase("../../../Files/notexistingfile.txt")]
    public void DecodeNotExistingFile_ThrowsFileNotFoundException(string path)
    {
        var compressor = new LZWCompressor();
        Assert.Throws<FileNotFoundException>(() => compressor.Decompress(path));
    }
}