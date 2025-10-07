using MU.GameTools.IO;

namespace MU.GameTools.Squish.DDS;

public class PixelFormat
{
    public uint Size;

    public PixelFormatFlags Flags;

    public uint FourCC;

    public uint RGBBitCount;

    public uint RedBitMask;

    public uint GreenBitMask;

    public uint BlueBitMask;

    public uint AlphaBitMask;

    public uint GetSize()
    {
        return 32u;
    }

    public void Initialise(FileFormat fileFormat)
    {
        Size = GetSize();
        switch (fileFormat)
        {
            case FileFormat.DXT1:
                Flags = PixelFormatFlags.FourCC;
                RGBBitCount = 0u;
                RedBitMask = 0u;
                GreenBitMask = 0u;
                BlueBitMask = 0u;
                AlphaBitMask = 0u;
                FourCC = 827611204u;
                break;
            case FileFormat.DXT3:
                Flags = PixelFormatFlags.FourCC;
                RGBBitCount = 0u;
                RedBitMask = 0u;
                GreenBitMask = 0u;
                BlueBitMask = 0u;
                AlphaBitMask = 0u;
                FourCC = 861165636u;
                break;
            case FileFormat.DXT5:
                Flags = PixelFormatFlags.FourCC;
                RGBBitCount = 0u;
                RedBitMask = 0u;
                GreenBitMask = 0u;
                BlueBitMask = 0u;
                AlphaBitMask = 0u;
                FourCC = 894720068u;
                break;
            case FileFormat.A8R8G8B8:
                Flags = PixelFormatFlags.RGBA;
                RGBBitCount = 32u;
                FourCC = 0u;
                RedBitMask = 16711680u;
                GreenBitMask = 65280u;
                BlueBitMask = 255u;
                AlphaBitMask = 4278190080u;
                break;
            case FileFormat.X8R8G8B8:
                Flags = PixelFormatFlags.RGB;
                RGBBitCount = 32u;
                FourCC = 0u;
                RedBitMask = 16711680u;
                GreenBitMask = 65280u;
                BlueBitMask = 255u;
                AlphaBitMask = 0u;
                break;
            case FileFormat.A8B8G8R8:
                Flags = PixelFormatFlags.RGBA;
                RGBBitCount = 32u;
                FourCC = 0u;
                RedBitMask = 255u;
                GreenBitMask = 65280u;
                BlueBitMask = 16711680u;
                AlphaBitMask = 4278190080u;
                break;
            case FileFormat.X8B8G8R8:
                Flags = PixelFormatFlags.RGB;
                RGBBitCount = 32u;
                FourCC = 0u;
                RedBitMask = 255u;
                GreenBitMask = 65280u;
                BlueBitMask = 16711680u;
                AlphaBitMask = 0u;
                break;
            case FileFormat.A1R5G5B5:
                Flags = PixelFormatFlags.RGBA;
                RGBBitCount = 16u;
                FourCC = 0u;
                RedBitMask = 31744u;
                GreenBitMask = 992u;
                BlueBitMask = 31u;
                AlphaBitMask = 32768u;
                break;
            case FileFormat.A4R4G4B4:
                Flags = PixelFormatFlags.RGBA;
                RGBBitCount = 16u;
                FourCC = 0u;
                RedBitMask = 3840u;
                GreenBitMask = 240u;
                BlueBitMask = 15u;
                AlphaBitMask = 61440u;
                break;
            case FileFormat.R8G8B8:
                Flags = PixelFormatFlags.RGB;
                FourCC = 0u;
                RGBBitCount = 24u;
                RedBitMask = 16711680u;
                GreenBitMask = 65280u;
                BlueBitMask = 255u;
                AlphaBitMask = 0u;
                break;
            case FileFormat.R5G6B5:
                Flags = PixelFormatFlags.RGB;
                FourCC = 0u;
                RGBBitCount = 16u;
                RedBitMask = 63488u;
                GreenBitMask = 2016u;
                BlueBitMask = 31u;
                AlphaBitMask = 0u;
                break;
            default:
                throw new NotSupportedException();
        }
    }

    [Obsolete]
    public void Serialize(Stream output, bool littleEndian)
    {
        Serialize(output, (!littleEndian) ? Endian.Big : Endian.Little);
    }

    public void Serialize(Stream output, Endian endian)
    {
        output.WriteValueU32(Size, endian);
        output.WriteValueEnum<PixelFormatFlags>(Flags, endian);
        output.WriteValueU32(FourCC, endian);
        output.WriteValueU32(RGBBitCount, endian);
        output.WriteValueU32(RedBitMask, endian);
        output.WriteValueU32(GreenBitMask, endian);
        output.WriteValueU32(BlueBitMask, endian);
        output.WriteValueU32(AlphaBitMask, endian);
    }

    [Obsolete]
    public void Deserialize(Stream input, bool littleEndian)
    {
        Deserialize(input, (!littleEndian) ? Endian.Big : Endian.Little);
    }

    public void Deserialize(Stream input, Endian endian)
    {
        Size = input.ReadValueU32(endian);
        Flags = input.ReadValueEnum<PixelFormatFlags>(endian);
        FourCC = input.ReadValueU32(endian);
        RGBBitCount = input.ReadValueU32(endian);
        RedBitMask = input.ReadValueU32(endian);
        GreenBitMask = input.ReadValueU32(endian);
        BlueBitMask = input.ReadValueU32(endian);
        AlphaBitMask = input.ReadValueU32(endian);
    }
}
