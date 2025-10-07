using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Reflection.PortableExecutable;
using MU.GameTools.Squish.DDS;
namespace MU.GameTools.Squish;

public class DDSFile
{
    public Endian Endian;

    public Header Header = new Header();

    private byte[] _PixelData;

    public byte[] PixelData => _PixelData;

    public int Width
    {
        get
        {
            return Header.Width;
        }
        set
        {
            Header.Width = value;
        }
    }

    public int Height
    {
        get
        {
            return Header.Height;
        }
        set
        {
            Header.Height = value;
        }
    }

    public Image Image()
    {
        return Image(red: true, green: true, blue: true, alpha: false);
    }

    public Image Image(bool red)
    {
        return Image(red: true, green: false, blue: false, alpha: false);
    }

    public Image Image(bool red, bool green)
    {
        return Image(red: true, green: true, blue: false, alpha: false);
    }

    public Image Image(bool red, bool green, bool blue)
    {
        return Image(red: true, green: true, blue: true, alpha: false);
    }

    public Image Image(bool red, bool green, bool blue, bool alpha)
    {
        int width = Width;
        int height = Height;
        Bitmap bitmap = new Bitmap(width, height);
        byte[] pixelData = PixelData;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                int num = i * width * 4 + j * 4;
                int red2 = 0;
                int green2 = 0;
                int blue2 = 0;
                int alpha2 = 0;
                if (red)
                {
                    red2 = pixelData[num];
                }
                if (green)
                {
                    green2 = pixelData[num + 1];
                }
                if (blue)
                {
                    blue2 = pixelData[num + 2];
                }
                if (alpha)
                {
                    alpha2 = pixelData[num + 3];
                }
                if (alpha)
                {
                    bitmap.SetPixel(j, i, Color.FromArgb(alpha2, red2, green2, blue2));
                }
                else
                {
                    bitmap.SetPixel(j, i, Color.FromArgb(red2, green2, blue2));
                }
            }
        }
        return bitmap;
    }

    public void Deserialize(Stream input)
    {
        uint num = input.ReadValueU32();
        if (num != 542327876 && num != 1145328416)
        {
            throw new FormatException("not a DDS texture");
        }
        Endian = ((num != 542327876) ? Endian.Big : Endian.Little);
        Header = new Header();
        Header.Deserialize(input, Endian);
        if ((Header.PixelFormat.Flags & PixelFormatFlags.FourCC) != 0)
        {
            Native.Flags flags = Native.Flags.None;
            flags = Header.PixelFormat.FourCC switch
            {
                827611204u => flags | Native.Flags.DXT1,
                861165636u => flags | Native.Flags.DXT3,
                894720068u => flags | Native.Flags.DXT5,
                _ => throw new FormatException("unsupported DDS format"),
            };
            int num2 = (Width + 3) / 4 * ((Height + 3) / 4);
            int num3 = (((flags & Native.Flags.DXT1) != Native.Flags.None) ? 8 : 16);
            byte[] array = new byte[num2 * num3];
            input.Read(array, 0, array.Length);
            _PixelData = Native.DecompressImage(array, Width, Height, flags);
            return;
        }
        FileFormat fileFormat = FileFormat.INVALID;
        if (Header.PixelFormat.Flags == PixelFormatFlags.RGBA && Header.PixelFormat.RGBBitCount == 32 && Header.PixelFormat.RedBitMask == 16711680 && Header.PixelFormat.GreenBitMask == 65280 && Header.PixelFormat.BlueBitMask == 255 && Header.PixelFormat.AlphaBitMask == 4278190080u)
        {
            fileFormat = FileFormat.A8R8G8B8;
        }
        else if (Header.PixelFormat.Flags == PixelFormatFlags.RGB && Header.PixelFormat.RGBBitCount == 32 && Header.PixelFormat.RedBitMask == 16711680 && Header.PixelFormat.GreenBitMask == 65280 && Header.PixelFormat.BlueBitMask == 255 && Header.PixelFormat.AlphaBitMask == 0)
        {
            fileFormat = FileFormat.X8R8G8B8;
        }
        else if (Header.PixelFormat.Flags == PixelFormatFlags.RGBA && Header.PixelFormat.RGBBitCount == 32 && Header.PixelFormat.RedBitMask == 255 && Header.PixelFormat.GreenBitMask == 65280 && Header.PixelFormat.BlueBitMask == 16711680 && Header.PixelFormat.AlphaBitMask == 4278190080u)
        {
            fileFormat = FileFormat.A8B8G8R8;
        }
        else if (Header.PixelFormat.Flags == PixelFormatFlags.RGB && Header.PixelFormat.RGBBitCount == 32 && Header.PixelFormat.RedBitMask == 255 && Header.PixelFormat.GreenBitMask == 65280 && Header.PixelFormat.BlueBitMask == 16711680 && Header.PixelFormat.AlphaBitMask == 0)
        {
            fileFormat = FileFormat.X8B8G8R8;
        }
        else if (Header.PixelFormat.Flags == PixelFormatFlags.RGBA && Header.PixelFormat.RGBBitCount == 16 && Header.PixelFormat.RedBitMask == 31744 && Header.PixelFormat.GreenBitMask == 992 && Header.PixelFormat.BlueBitMask == 31 && Header.PixelFormat.AlphaBitMask == 32768)
        {
            fileFormat = FileFormat.A1R5G5B5;
        }
        else if (Header.PixelFormat.Flags == PixelFormatFlags.RGBA && Header.PixelFormat.RGBBitCount == 16 && Header.PixelFormat.RedBitMask == 3840 && Header.PixelFormat.GreenBitMask == 240 && Header.PixelFormat.BlueBitMask == 15 && Header.PixelFormat.AlphaBitMask == 61440)
        {
            fileFormat = FileFormat.A4R4G4B4;
        }
        else if (Header.PixelFormat.Flags == PixelFormatFlags.RGB && Header.PixelFormat.RGBBitCount == 24 && Header.PixelFormat.RedBitMask == 16711680 && Header.PixelFormat.GreenBitMask == 65280 && Header.PixelFormat.BlueBitMask == 255 && Header.PixelFormat.AlphaBitMask == 0)
        {
            fileFormat = FileFormat.R8G8B8;
        }
        else if (Header.PixelFormat.Flags == PixelFormatFlags.RGB && Header.PixelFormat.RGBBitCount == 16 && Header.PixelFormat.RedBitMask == 63488 && Header.PixelFormat.GreenBitMask == 2016 && Header.PixelFormat.BlueBitMask == 31 && Header.PixelFormat.AlphaBitMask == 0)
        {
            fileFormat = FileFormat.R5G6B5;
        }
        if (fileFormat == FileFormat.INVALID)
        {
            throw new FormatException("unsupported DDS format");
        }
        int num4 = (int)(Header.PixelFormat.RGBBitCount / 8);
        int num5 = 0;
        num5 = (((Header.Flags & HeaderFlags.Pitch) != 0) ? ((int)Header.PitchOrLinearSize) : (((Header.Flags & HeaderFlags.LinerSize) == 0) ? (Header.Width * num4) : ((int)Header.PitchOrLinearSize / Header.Height)));
        byte[] array2 = new byte[num5 * Header.Height];
        if (input.Read(array2, 0, array2.Length) != array2.Length)
        {
            throw new EndOfStreamException();
        }
        _PixelData = new byte[Header.Width * Header.Height * 4];
        for (int i = 0; i < Header.Height; i++)
        {
            int num6 = i * num5;
            int num7 = i * 4;
            int num8 = 0;
            while (num8 < Header.Width)
            {
                uint num9 = 0u;
                byte b = 0;
                byte b2 = 0;
                byte b3 = 0;
                byte b4 = 0;
                int num10 = 0;
                int num11 = 0;
                while (num10 < num4)
                {
                    num9 |= (uint)(array2[num6 + num10] << num11);
                    num10++;
                    num11 += 8;
                }
                switch (fileFormat)
                {
                    case FileFormat.A8R8G8B8:
                        b4 = (byte)((num9 >> 24) & 0xFF);
                        b = (byte)((num9 >> 16) & 0xFF);
                        b2 = (byte)((num9 >> 8) & 0xFF);
                        b3 = (byte)(num9 & 0xFF);
                        break;
                    case FileFormat.X8R8G8B8:
                        b4 = byte.MaxValue;
                        b = (byte)((num9 >> 16) & 0xFF);
                        b2 = (byte)((num9 >> 8) & 0xFF);
                        b3 = (byte)(num9 & 0xFF);
                        break;
                    case FileFormat.A8B8G8R8:
                        b4 = (byte)((num9 >> 24) & 0xFF);
                        b = (byte)(num9 & 0xFF);
                        b2 = (byte)((num9 >> 8) & 0xFF);
                        b3 = (byte)((num9 >> 16) & 0xFF);
                        break;
                    case FileFormat.X8B8G8R8:
                        b4 = byte.MaxValue;
                        b = (byte)(num9 & 0xFF);
                        b2 = (byte)((num9 >> 8) & 0xFF);
                        b3 = (byte)((num9 >> 16) & 0xFF);
                        break;
                    case FileFormat.A1R5G5B5:
                        b4 = (byte)((num9 >> 15) * 255);
                        b = (byte)((num9 >> 10) & 0x1F);
                        b2 = (byte)((num9 >> 5) & 0x1F);
                        b3 = (byte)(num9 & 0x1F);
                        b = (byte)((b << 3) | (b >> 2));
                        b2 = (byte)((b2 << 3) | (b2 >> 2));
                        b3 = (byte)((b3 << 3) | (b3 >> 2));
                        break;
                    case FileFormat.A4R4G4B4:
                        b4 = (byte)((num9 >> 12) & 0xFF);
                        b = (byte)((num9 >> 8) & 0xF);
                        b2 = (byte)((num9 >> 4) & 0xF);
                        b3 = (byte)(num9 & 0xF);
                        b4 = (byte)((b4 << 4) | b4);
                        b = (byte)((b << 4) | b);
                        b2 = (byte)((b2 << 4) | b2);
                        b3 = (byte)((b3 << 4) | b3);
                        break;
                    case FileFormat.R8G8B8:
                        b4 = byte.MaxValue;
                        b = (byte)((num9 >> 16) & 0xFF);
                        b2 = (byte)((num9 >> 8) & 0xFF);
                        b3 = (byte)(num9 & 0xFF);
                        break;
                    case FileFormat.R5G6B5:
                        b4 = byte.MaxValue;
                        b = (byte)((num9 >> 11) & 0x1F);
                        b2 = (byte)((num9 >> 5) & 0x3F);
                        b3 = (byte)(num9 & 0x1F);
                        b = (byte)((b << 3) | (b >> 2));
                        b2 = (byte)((b2 << 2) | (b2 >> 4));
                        b3 = (byte)((b3 << 3) | (b3 >> 2));
                        break;
                    default:
                        throw new NotSupportedException();
                }
                _PixelData[num7] = b;
                _PixelData[num7 + 1] = b2;
                _PixelData[num7 + 2] = b3;
                _PixelData[num7 + 3] = b4;
                num8++;
                num6 += num4;
                num7 += 4;
            }
        }
    }
}
