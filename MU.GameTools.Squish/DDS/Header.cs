using MU.GameTools.IO;

namespace MU.GameTools.Squish.DDS;


public class Header
{
    public uint Size;

    public HeaderFlags Flags;

    public int Height;

    public int Width;

    public uint PitchOrLinearSize;

    public uint Depth;

    public uint MipMapCount;

    public byte[] Reserved1 = new byte[44];

    public PixelFormat PixelFormat;

    public uint SurfaceFlags;

    public uint CubemapFlags;

    public byte[] Reserved2 = new byte[12];

    public Header()
    {
        PixelFormat = new PixelFormat();
    }

    public uint GetSize()
    {
        return 72 + PixelFormat.GetSize() + 20;
    }

    [Obsolete]
    public void Serialize(Stream output, bool littleEndian)
    {
        Serialize(output, (!littleEndian) ? Endian.Big : Endian.Little);
    }

    public void Serialize(Stream output, Endian endian)
    {
        output.WriteValueU32(Size, endian);
        output.WriteValueEnum<HeaderFlags>(Flags, endian);
        output.WriteValueS32(Height, endian);
        output.WriteValueS32(Width, endian);
        output.WriteValueU32(PitchOrLinearSize, endian);
        output.WriteValueU32(Depth, endian);
        output.WriteValueU32(MipMapCount, endian);
        output.Write(Reserved1, 0, Reserved1.Length);
        PixelFormat.Serialize(output, endian);
        output.WriteValueU32(SurfaceFlags, endian);
        output.WriteValueU32(CubemapFlags, endian);
        output.Write(Reserved2, 0, Reserved2.Length);
    }

    [Obsolete]
    public void Deserialize(Stream input, bool littleEndian)
    {
        Deserialize(input, (!littleEndian) ? Endian.Big : Endian.Little);
    }

    public void Deserialize(Stream input, Endian endian)
    {
        Size = input.ReadValueU32(endian);
        Flags = input.ReadValueEnum<HeaderFlags>(endian);
        Height = input.ReadValueS32(endian);
        Width = input.ReadValueS32(endian);
        PitchOrLinearSize = input.ReadValueU32(endian);
        Depth = input.ReadValueU32(endian);
        MipMapCount = input.ReadValueU32(endian);
        if (input.Read(Reserved1, 0, Reserved1.Length) != Reserved1.Length)
        {
            throw new EndOfStreamException();
        }
        PixelFormat.Deserialize(input, endian);
        SurfaceFlags = input.ReadValueU32(endian);
        CubemapFlags = input.ReadValueU32(endian);
        if (input.Read(Reserved2, 0, Reserved2.Length) != Reserved2.Length)
        {
            throw new EndOfStreamException();
        }
    }
}
