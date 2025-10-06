namespace MU.GameTools.IO;

public static class NumberHelpers
{

    public static int Align(this int value, int align)
    {
        if (value != 0)
        {
            return value + value.Padding(align);
        }
        return 0;
    }

    public static uint Align(this uint value, uint align)
    {
        if (value != 0)
        {
            return value + value.Padding(align);
        }
        return 0u;
    }

    public static long Align(this long value, long align)
    {
        if (value != 0L)
        {
            return value + value.Padding(align);
        }
        return 0L;
    }

    public static ulong Align(this ulong value, ulong align)
    {
        if (value != 0L)
        {
            return value + value.Padding(align);
        }
        return 0uL;
    }

    public static short BigEndian(this short value)
    {
        if (BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static ushort BigEndian(this ushort value)
    {
        if (BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static int BigEndian(this int value)
    {
        if (BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static uint BigEndian(this uint value)
    {
        if (BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static long BigEndian(this long value)
    {
        if (BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static ulong BigEndian(this ulong value)
    {
        if (BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static float BigEndian(this float value)
    {
        if (BitConverter.IsLittleEndian)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(BitConverter.GetBytes(value), 0).Swap()), 0);
        }
        return value;
    }

    public static double BigEndian(this double value)
    {
        if (BitConverter.IsLittleEndian)
        {
            return BitConverter.ToDouble(BitConverter.GetBytes(BitConverter.ToUInt64(BitConverter.GetBytes(value), 0).Swap()), 0);
        }
        return value;
    }

    public static short LittleEndian(this short value)
    {
        if (!BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static ushort LittleEndian(this ushort value)
    {
        if (!BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static int LittleEndian(this int value)
    {
        if (!BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static uint LittleEndian(this uint value)
    {
        if (!BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static long LittleEndian(this long value)
    {
        if (!BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static ulong LittleEndian(this ulong value)
    {
        if (!BitConverter.IsLittleEndian)
        {
            return value.Swap();
        }
        return value;
    }

    public static float LittleEndian(this float value)
    {
        if (BitConverter.IsLittleEndian)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(BitConverter.GetBytes(value), 0).Swap()), 0);
        }
        return value;
    }

    public static double LittleEndian(this double value)
    {
        if (BitConverter.IsLittleEndian)
        {
            return BitConverter.ToDouble(BitConverter.GetBytes(BitConverter.ToUInt64(BitConverter.GetBytes(value), 0).Swap()), 0);
        }
        return value;
    }

    public static int Padding(this int value, int align)
    {
        return (align - value % align) % align;
    }

    public static uint Padding(this uint value, uint align)
    {
        return (align - value % align) % align;
    }

    public static long Padding(this long value, long align)
    {
        return (align - value % align) % align;
    }

    public static ulong Padding(this ulong value, ulong align)
    {
        return (align - value % align) % align;
    }

    public static sbyte RotateLeft(this sbyte value, int count)
    {
        return (sbyte)((byte)value).RotateLeft(count);
    }

    public static byte RotateLeft(this byte value, int count)
    {
        return (byte)((value << count) | (value >> 8 - count));
    }

    public static short RotateLeft(this short value, int count)
    {
        return (short)((ushort)value).RotateLeft(count);
    }

    public static ushort RotateLeft(this ushort value, int count)
    {
        return (ushort)((value << count) | (value >> 16 - count));
    }

    public static int RotateLeft(this int value, int count)
    {
        return (int)((uint)value).RotateLeft(count);
    }

    public static uint RotateLeft(this uint value, int count)
    {
        return (value << count) | (value >> 32 - count);
    }

    public static long RotateLeft(this long value, int count)
    {
        return (long)((ulong)value).RotateLeft(count);
    }

    public static ulong RotateLeft(this ulong value, int count)
    {
        return (value << count) | (value >> 64 - count);
    }

    public static sbyte RotateRight(this sbyte value, int count)
    {
        return (sbyte)((byte)value).RotateRight(count);
    }

    public static byte RotateRight(this byte value, int count)
    {
        return (byte)((value >> count) | (value << 8 - count));
    }

    public static short RotateRight(this short value, int count)
    {
        return (short)((ushort)value).RotateRight(count);
    }

    public static ushort RotateRight(this ushort value, int count)
    {
        return (ushort)((value >> count) | (value << 16 - count));
    }

    public static int RotateRight(this int value, int count)
    {
        return (int)((uint)value).RotateRight(count);
    }

    public static uint RotateRight(this uint value, int count)
    {
        return (value >> count) | (value << 32 - count);
    }

    public static long RotateRight(this long value, int count)
    {
        return (long)((ulong)value).RotateRight(count);
    }

    public static ulong RotateRight(this ulong value, int count)
    {
        return (value >> count) | (value << 64 - count);
    }

    public static short Swap(this short value)
    {
        return (short)((ushort)value).Swap();
    }

    public static ushort Swap(this ushort value)
    {
        return (ushort)((0xFFuL & (ulong)(value >> 8)) | (0xFF00uL & (ulong)(value << 8)));
    }

    public static int Swap(this int value)
    {
        return (int)((uint)value).Swap();
    }

    public static uint Swap(this uint value)
    {
        return (0xFF & (value >> 24)) | (0xFF00 & (value >> 8)) | (0xFF0000 & (value << 8)) | (0xFF000000u & (value << 24));
    }

    public static long Swap(this long value)
    {
        return (long)((ulong)value).Swap();
    }

    public static ulong Swap(this ulong value)
    {
        return (0xFF & (value >> 56)) | (0xFF00 & (value >> 40)) | (0xFF0000 & (value >> 24)) | (0xFF000000u & (value >> 8)) | (0xFF00000000L & (value << 8)) | (0xFF0000000000L & (value << 24)) | (0xFF000000000000L & (value << 40)) | (0xFF00000000000000uL & (value << 56));
    }

    public static float Swap(this float value)
    {
        OverlapSingle overlapSingle = new OverlapSingle(value);
        overlapSingle.AsU = overlapSingle.AsU.Swap();
        return overlapSingle.AsF;
    }

    public static double Swap(this double value)
    {
        OverlapDouble overlapDouble = new OverlapDouble(value);
        overlapDouble.AsU = overlapDouble.AsU.Swap();
        return overlapDouble.AsD;
    }
}

