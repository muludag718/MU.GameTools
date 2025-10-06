using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace MU.GameTools.IO;
public static class StreamHelpers
{
    private static class EnumTypeCache
    {
        private static TypeCode TranslateType(Type type)
        {
            if (type.IsEnum)
            {
                TypeCode typeCode = Type.GetTypeCode(Enum.GetUnderlyingType(type));
                if ((uint)(typeCode - 5) <= 7u)
                {
                    return typeCode;
                }
            }
            throw new ArgumentException("unknown enum type", "type");
        }

        public static TypeCode Get(Type type)
        {
            return TranslateType(type);
        }
    }

    public static Encoding DefaultEncoding = Encoding.ASCII;

    internal static bool ShouldSwap(Endian endian)
    {
        return endian switch
        {
            Endian.Little => !BitConverter.IsLittleEndian,
            Endian.Big => BitConverter.IsLittleEndian,
            _ => throw new ArgumentException("unsupported endianness", "endian"),
        };
    }

    public static int PeakByte(this Stream stream)
    {
        int result = stream.ReadByte();
        stream.Position--;
        return result;
    }

    public static void MoveToAlign(this Stream stream, int aligment)
    {
        while (stream.Position % aligment != 0L)
        {
            long position = stream.Position + 1;
            stream.Position = position;
        }
    }

    public static MemoryStream ReadToMemoryStream(this Stream stream, int size, bool writeable)
    {
        return new MemoryStream(stream.ReadBytes(size), writeable);
    }

    public static MemoryStream ReadToMemoryStream(this Stream stream, int size)
    {
        return stream.ReadToMemoryStream(size, writeable: true);
    }

    public static void WriteFromStream(this Stream stream, Stream input, long size, int buffer)
    {
        long num = size;
        byte[] buffer2 = new byte[buffer];
        while (num > 0)
        {
            int num2 = (int)Math.Min(num, buffer);
            if (input.Read(buffer2, 0, num2) != num2)
            {
                throw new EndOfStreamException();
            }
            stream.Write(buffer2, 0, num2);
            num -= num2;
        }
    }

    public static void WriteFromStream(this Stream stream, Stream input, long size)
    {
        stream.WriteFromStream(input, size, 262144);
    }

    public static byte[] ReadBytes(this Stream stream, int length)
    {
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException("length");
        }
        byte[] array = new byte[length];
        if (stream.Read(array, 0, length) != length)
        {
            throw new EndOfStreamException();
        }
        return array;
    }

    public static void WriteBytes(this Stream stream, byte[] data)
    {
        stream.Write(data, 0, data.Length);
    }

    public static string ReadStringAlignedU32(this Stream stream, Endian endian)
    {
        uint num = stream.ReadValueU32(endian);
        if (num == 0)
        {
            return "";
        }
        byte[] array = new byte[num];
        stream.ReadAligned(array, 0, array.Length, 4);
        return Encoding.ASCII.GetString(array);
    }

    public static void WriteStringU32(this Stream stream, string value, Endian endian)
    {
        if (string.IsNullOrEmpty(value))
        {
            stream.WriteValueU32(0u, endian);
            return;
        }
        int byteCount = Encoding.ASCII.GetByteCount(value);
        stream.WriteValueS32(byteCount + 1, endian);
        stream.WriteStringZ(value, Encoding.ASCII);
    }

    public static void WriteStringU32NoTerminator(this Stream stream, string value, Endian endian)
    {
        if (string.IsNullOrEmpty(value))
        {
            stream.WriteValueU32(0u, endian);
            return;
        }
        stream.WriteValueS32(value.Length, endian);
        stream.WriteStringInternalStatic(DefaultEncoding, value);
    }

    public static void WriteStringAlignedU32(this Stream stream, string value, Endian endian)
    {
        if (string.IsNullOrEmpty(value))
        {
            stream.WriteValueU32(0u, endian);
            return;
        }
        int byteCount = Encoding.ASCII.GetByteCount(value);
        stream.WriteValueS32(byteCount, endian);
        stream.WriteAligned(Encoding.ASCII.GetBytes(value), 0, value.Length, 4);
    }

    public static string ReadStringAlignedU8(this Stream stream)
    {
        byte b = stream.ReadValueU8();
        if (b == 0)
        {
            return "";
        }
        return stream.ReadString(b, trailingNull: false, Encoding.ASCII);
    }

    public static void WriteStringAlignedU8(this Stream stream, string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            stream.WriteValueU8(0);
            return;
        }
        int byteCount = Encoding.ASCII.GetByteCount(value);
        if (byteCount > 255)
        {
            throw new ArgumentException("value is too long", "value");
        }
        stream.WriteValueU8((byte)byteCount);
        byte[] array = Encoding.ASCII.GetBytes(value);
        Array.Resize(ref array, byteCount);
        stream.Write(array, 0, array.Length);
    }

    public static int ReadAligned(this Stream stream, byte[] buffer, int offset, int size, int align)
    {
        if (size == 0)
        {
            return 0;
        }
        int result = stream.Read(buffer, offset, size);
        int num = size % align;
        if (num > 0)
        {
            stream.Seek(align - num, SeekOrigin.Current);
        }
        return result;
    }

    public static void WriteAligned(this Stream stream, byte[] buffer, int offset, int size, int align)
    {
        if (size != 0)
        {
            stream.Write(buffer, offset, size);
            int num = size % align;
            if (num > 0)
            {
                byte[] buffer2 = new byte[align - num];
                stream.Write(buffer2, 0, align - num);
            }
        }
    }

    public static bool ReadValueBoolean(this Stream stream)
    {
        return stream.ReadValueB8();
    }

    public static void WriteValueBoolean(this Stream stream, bool value)
    {
        stream.WriteValueB8(value);
    }

    public static bool ReadValueB8(this Stream stream)
    {
        return stream.ReadValueU8() > 0;
    }

    public static void WriteValueB8(this Stream stream, bool value)
    {
        stream.WriteValueU8((byte)(value ? 1u : 0u));
    }

    public static bool ReadValueB32(this Stream stream, Endian endian)
    {
        return stream.ReadValueU32(endian) != 0;
    }

    public static bool ReadValueB32(this Stream stream)
    {
        return stream.ReadValueB32(Endian.Little);
    }

    public static void WriteValueB32(this Stream stream, bool value, Endian endian)
    {
        stream.WriteValueU32((byte)(value ? 1u : 0u), endian);
    }

    public static void WriteValueB32(this Stream stream, bool value)
    {
        stream.WriteValueB32(value, Endian.Little);
    }

    public static T ReadValueEnum<T>(this Stream stream, Endian endian)
    {
        Type typeFromHandle = typeof(T);
        return (T)Enum.ToObject(typeFromHandle, EnumTypeCache.Get(typeFromHandle) switch
        {
            TypeCode.SByte => stream.ReadValueS8(),
            TypeCode.Byte => stream.ReadValueU8(),
            TypeCode.Int16 => stream.ReadValueS16(endian),
            TypeCode.UInt16 => stream.ReadValueU16(endian),
            TypeCode.Int32 => stream.ReadValueS32(endian),
            TypeCode.UInt32 => stream.ReadValueU32(endian),
            TypeCode.Int64 => stream.ReadValueS64(endian),
            TypeCode.UInt64 => stream.ReadValueU64(endian),
            _ => throw new NotSupportedException(),
        });
    }

    public static T ReadValueEnum<T>(this Stream stream)
    {
        return stream.ReadValueEnum<T>(Endian.Little);
    }

    public static void WriteValueEnum<T>(this Stream stream, object value, Endian endian)
    {
        switch (EnumTypeCache.Get(typeof(T)))
        {
            case TypeCode.SByte:
                stream.WriteValueS8((sbyte)value);
                break;
            case TypeCode.Byte:
                stream.WriteValueU8((byte)value);
                break;
            case TypeCode.Int16:
                stream.WriteValueS16((short)value, endian);
                break;
            case TypeCode.UInt16:
                stream.WriteValueU16((ushort)value, endian);
                break;
            case TypeCode.Int32:
                stream.WriteValueS32((int)value, endian);
                break;
            case TypeCode.UInt32:
                stream.WriteValueU32((uint)value, endian);
                break;
            case TypeCode.Int64:
                stream.WriteValueS64((long)value, endian);
                break;
            case TypeCode.UInt64:
                stream.WriteValueU64((ulong)value, endian);
                break;
            default:
                throw new NotSupportedException();
        }
    }

    public static void WriteValueEnum<T>(this Stream stream, object value)
    {
        stream.WriteValueEnum<T>(value, Endian.Little);
    }

    public static Guid ReadValueGuid(this Stream stream, Endian endian)
    {
        int a = stream.ReadValueS32(endian);
        short b = stream.ReadValueS16(endian);
        short c = stream.ReadValueS16(endian);
        byte[] d = SmallWorkBuffer.ReadBytes(stream, 8);
        return new Guid(a, b, c, d);
    }

    public static Guid ReadValueGuid(this Stream stream)
    {
        return stream.ReadValueGuid(Endian.Little);
    }

    public static void WriteValueGuid(this Stream stream, Guid value, Endian endian)
    {
        byte[] array = value.ToByteArray();
        stream.WriteValueS32(BitConverter.ToInt32(array, 0), endian);
        stream.WriteValueS16(BitConverter.ToInt16(array, 4), endian);
        stream.WriteValueS16(BitConverter.ToInt16(array, 6), endian);
        stream.Write(array, 8, 8);
    }

    public static void WriteValueGuid(this Stream stream, Guid value)
    {
        stream.WriteValueGuid(value, Endian.Little);
    }

    public static float ReadValueF32(this Stream stream, Endian endian)
    {
        return new OverlapSingle(stream.ReadValueU32(endian)).AsF;
    }

    public static float ReadValueF32(this Stream stream)
    {
        return stream.ReadValueF32(Endian.Little);
    }

    public static void WriteValueF32(this Stream stream, float value, Endian endian)
    {
        uint asU = new OverlapSingle(value).AsU;
        stream.WriteValueU32(asU, endian);
    }

    public static void WriteValueF32(this Stream stream, float value)
    {
        stream.WriteValueF32(value, Endian.Little);
    }

    public static double ReadValueF64(this Stream stream, Endian endian)
    {
        return new OverlapDouble(stream.ReadValueU64(endian)).AsD;
    }

    public static double ReadValueF64(this Stream stream)
    {
        return stream.ReadValueF64(Endian.Little);
    }

    public static void WriteValueF64(this Stream stream, double value, Endian endian)
    {
        ulong asU = new OverlapDouble(value).AsU;
        stream.WriteValueU64(asU, endian);
    }

    public static void WriteValueF64(this Stream stream, double value)
    {
        stream.WriteValueF64(value, Endian.Little);
    }

    public static sbyte ReadValueS8(this Stream stream)
    {
        return (sbyte)stream.ReadValueU8();
    }

    public static void WriteValueS8(this Stream stream, sbyte value)
    {
        stream.WriteValueU8((byte)value);
    }

    public static short ReadValueS16(this Stream stream, Endian endian)
    {
        return (short)stream.ReadValueU16(endian);
    }

    public static short ReadValueS16(this Stream stream)
    {
        return (short)stream.ReadValueU16();
    }

    public static void WriteValueS16(this Stream stream, short value, Endian endian)
    {
        stream.WriteValueU16((ushort)value, endian);
    }

    public static void WriteValueS16(this Stream stream, short value)
    {
        stream.WriteValueU16((ushort)value);
    }

    public static int ReadValueS32(this Stream stream, Endian endian)
    {
        return (int)stream.ReadValueU32(endian);
    }

    public static int ReadValueS32(this Stream stream)
    {
        return (int)stream.ReadValueU32();
    }

    public static void WriteValueS32(this Stream stream, int value, Endian endian)
    {
        stream.WriteValueU32((uint)value, endian);
    }

    public static void WriteValueS32(this Stream stream, int value)
    {
        stream.WriteValueU32((uint)value);
    }

    public static long ReadValueS64(this Stream stream, Endian endian)
    {
        return (long)stream.ReadValueU64(endian);
    }

    public static long ReadValueS64(this Stream stream)
    {
        return (long)stream.ReadValueU64(Endian.Little);
    }

    public static void WriteValueS64(this Stream stream, long value, Endian endian)
    {
        stream.WriteValueU64((ulong)value, endian);
    }

    public static void WriteValueS64(this Stream stream, long value)
    {
        stream.WriteValueU64((ulong)value);
    }

    public static byte ReadValueU8(this Stream stream)
    {
        return SmallWorkBuffer.ReadBytes(stream, 1)[0];
    }

    public static void WriteValueU8(this Stream stream, byte value)
    {
        byte[] array = SmallWorkBuffer.Get(1);
        array[0] = value;
        stream.Write(array, 0, 1);
    }

    public static ushort ReadValueU16(this Stream stream, Endian endian)
    {
        ushort num = BitConverter.ToUInt16(SmallWorkBuffer.ReadBytes(stream, 2), 0);
        if (ShouldSwap(endian))
        {
            num = num.Swap();
        }
        return num;
    }

    public static ushort ReadValueU16(this Stream stream)
    {
        return stream.ReadValueU16(Endian.Little);
    }

    public static void WriteValueU16(this Stream stream, ushort value, Endian endian)
    {
        if (ShouldSwap(endian))
        {
            value = value.Swap();
        }
        byte[] array = SmallWorkBuffer.Get(2);
        array[0] = (byte)(value & 0xFF);
        array[1] = (byte)((uint)(value & 0xFF00) >> 8);
        stream.Write(array, 0, 2);
    }

    public static void WriteValueU16(this Stream stream, ushort value)
    {
        stream.WriteValueU16(value, Endian.Little);
    }

    public static uint ReadValueU32(this Stream stream, Endian endian)
    {
        uint num = BitConverter.ToUInt32(SmallWorkBuffer.ReadBytes(stream, 4), 0);
        if (ShouldSwap(endian))
        {
            num = num.Swap();
        }
        return num;
    }

    public static uint ReadValueU32(this Stream stream)
    {
        return stream.ReadValueU32(Endian.Little);
    }

    public static void WriteValueU32(this Stream stream, uint value, Endian endian)
    {
        if (ShouldSwap(endian))
        {
            value = value.Swap();
        }
        byte[] array = SmallWorkBuffer.Get(4);
        array[0] = (byte)(value & 0xFF);
        array[1] = (byte)((value & 0xFF00) >> 8);
        array[2] = (byte)((value & 0xFF0000) >> 16);
        array[3] = (byte)((value & 0xFF000000u) >> 24);
        stream.Write(array, 0, 4);
    }

    public static void WriteValueU32(this Stream stream, uint value)
    {
        stream.WriteValueU32(value, Endian.Little);
    }

    public static ulong ReadValueU64(this Stream stream, Endian endian)
    {
        ulong num = BitConverter.ToUInt64(SmallWorkBuffer.ReadBytes(stream, 8), 0);
        if (ShouldSwap(endian))
        {
            num = num.Swap();
        }
        return num;
    }

    public static ulong ReadValueU64(this Stream stream)
    {
        return stream.ReadValueU64(Endian.Little);
    }

    public static void WriteValueU64(this Stream stream, ulong value, Endian endian)
    {
        if (ShouldSwap(endian))
        {
            value = value.Swap();
        }
        byte[] array = SmallWorkBuffer.Get(8);
        uint num = (uint)value;
        uint num2 = (uint)(value >> 32);
        array[0] = (byte)(num & 0xFF);
        array[1] = (byte)((num & 0xFF00) >> 8);
        array[2] = (byte)((num & 0xFF0000) >> 16);
        array[3] = (byte)((num & 0xFF000000u) >> 24);
        array[4] = (byte)(num2 & 0xFF);
        array[5] = (byte)((num2 & 0xFF00) >> 8);
        array[6] = (byte)((num2 & 0xFF0000) >> 16);
        array[7] = (byte)((num2 & 0xFF000000u) >> 24);
        stream.Write(array, 0, 8);
    }

    public static void WriteValueU64(this Stream stream, ulong value)
    {
        stream.WriteValueU64(value, Endian.Little);
    }

    public static string ReadString(this Stream stream, int size)
    {
        return stream.ReadStringInternalStatic(DefaultEncoding, size, trailingNull: false);
    }

    public static string ReadString(this Stream stream, int size, bool trailingNull)
    {
        return stream.ReadStringInternalStatic(DefaultEncoding, size, trailingNull);
    }

    public static string ReadStringZ(this Stream stream)
    {
        return stream.ReadStringInternalDynamic(DefaultEncoding, '\0');
    }

    public static void WriteString(this Stream stream, string value)
    {
        stream.WriteStringInternalStatic(DefaultEncoding, value);
    }

    public static void WriteString(this Stream stream, string value, int size)
    {
        stream.WriteStringInternalStatic(DefaultEncoding, value, size);
    }

    public static void WriteStringZ(this Stream stream, string value)
    {
        stream.WriteStringInternalDynamic(DefaultEncoding, value, '\0');
    }

    internal static string ReadStringInternalStatic(this Stream stream, Encoding encoding, int size, bool trailingNull)
    {
        byte[] array = stream.ReadBytes(size);
        string text = encoding.GetString(array, 0, array.Length);
        if (trailingNull)
        {
            int num = text.IndexOf('\0');
            if (num >= 0)
            {
                text = text[..num];
            }
        }
        return text;
    }

    internal static void WriteStringInternalStatic(this Stream stream, Encoding encoding, string value)
    {
        byte[] bytes = encoding.GetBytes(value);
        stream.Write(bytes, 0, bytes.Length);
    }

    internal static void WriteStringInternalStatic(this Stream stream, Encoding encoding, string value, int size)
    {
        byte[] array = encoding.GetBytes(value);
        Array.Resize(ref array, size);
        stream.Write(array, 0, size);
    }

    internal static string ReadStringInternalDynamic(this Stream stream, Encoding encoding, char end)
    {
        int byteCount = encoding.GetByteCount("e");
        string text = end.ToString(CultureInfo.InvariantCulture);
        int num = 0;
        byte[] array = new byte[128 * byteCount];
        while (true)
        {
            if (num + byteCount > array.Length)
            {
                Array.Resize(ref array, array.Length + 128 * byteCount);
            }
            stream.Read(array, num, byteCount);
            if (encoding.GetString(array, num, byteCount) == text)
            {
                break;
            }
            num += byteCount;
        }
        if (num == 0)
        {
            return "";
        }
        return encoding.GetString(array, 0, num);
    }

    internal static void WriteStringInternalDynamic(this Stream stream, Encoding encoding, string value, char end)
    {
        byte[] bytes = encoding.GetBytes(value);
        stream.Write(bytes, 0, bytes.Length);
        bytes = encoding.GetBytes(end.ToString(CultureInfo.InvariantCulture));
        stream.Write(bytes, 0, bytes.Length);
    }

    public static string ReadString(this Stream stream, int size, Encoding encoding)
    {
        return stream.ReadStringInternalStatic(encoding, size, trailingNull: false);
    }

    public static string ReadString(this Stream stream, int size, bool trailingNull, Encoding encoding)
    {
        return stream.ReadStringInternalStatic(encoding, size, trailingNull);
    }

    public static string ReadStringZ(this Stream stream, Encoding encoding)
    {
        return stream.ReadStringInternalDynamic(encoding, '\0');
    }

    public static void WriteString(this Stream stream, string value, Encoding encoding)
    {
        stream.WriteStringInternalStatic(encoding, value);
    }

    public static void WriteString(this Stream stream, string value, int size, Encoding encoding)
    {
        stream.WriteStringInternalStatic(encoding, value, size);
    }

    public static void WriteStringZ(this Stream stream, string value, Encoding encoding)
    {
        stream.WriteStringInternalDynamic(encoding, value, '\0');
    }

    public static T ReadStructure<T>(this Stream stream)
    {
        int num = Marshal.SizeOf(typeof(T));
        byte[] array = new byte[num];
        if (stream.Read(array, 0, num) != num)
        {
            throw new EndOfStreamException("could not read all of data for structure");
        }
        GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
        T result = (T)Marshal.PtrToStructure(gCHandle.AddrOfPinnedObject(), typeof(T));
        gCHandle.Free();
        return result;
    }

    public static T ReadStructure<T>(this Stream stream, int size)
    {
        byte[] array = new byte[Math.Max(Marshal.SizeOf(typeof(T)), size)];
        if (stream.Read(array, 0, size) != size)
        {
            throw new EndOfStreamException("could not read all of data for structure");
        }
        GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
        T result = (T)Marshal.PtrToStructure(gCHandle.AddrOfPinnedObject(), typeof(T));
        gCHandle.Free();
        return result;
    }

    public static void WriteStructure<T>(this Stream stream, T structure)
    {
        byte[] array = new byte[Marshal.SizeOf(typeof(T))];
        GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
        Marshal.StructureToPtr(structure, gCHandle.AddrOfPinnedObject(), fDeleteOld: false);
        gCHandle.Free();
        stream.Write(array, 0, array.Length);
    }

    public static void WriteStructure<T>(this Stream stream, T structure, int size)
    {
        byte[] array = new byte[Math.Max(Marshal.SizeOf(typeof(T)), size)];
        GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
        Marshal.StructureToPtr(structure, gCHandle.AddrOfPinnedObject(), fDeleteOld: false);
        gCHandle.Free();
        stream.Write(array, 0, array.Length);
    }
}
