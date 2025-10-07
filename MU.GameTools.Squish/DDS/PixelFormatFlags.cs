namespace MU.GameTools.Squish.DDS;

[Flags]
public enum PixelFormatFlags : uint
{
    FourCC = 4u,
    RGB = 0x40u,
    RGBA = 0x41u,
    Luminance = 0x20000u
}
