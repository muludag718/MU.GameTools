namespace MU.GameTools.IO;

internal static class SmallWorkBuffer
{
    public const int BufferSize = 8;

    private static readonly ThreadLocal<byte[]> _SmallWorkBuffer = new ThreadLocal<byte[]>(() => new byte[8]);

    public static byte[] Get(int count)
    {
        if (count < 0 || count > 8)
        {
            throw new ArgumentOutOfRangeException("count");
        }
        return _SmallWorkBuffer.Value;
    }

    public static byte[] ReadBytes(Stream stream, int count)
    {
        if (count < 0 || count > 8)
        {
            throw new ArgumentOutOfRangeException("count");
        }
        byte[] value = _SmallWorkBuffer.Value;
        if (stream.Read(value, 0, count) != count)
        {
            throw new EndOfStreamException();
        }
        return value;
    }
}
