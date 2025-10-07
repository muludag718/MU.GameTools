using System.Runtime.InteropServices;

namespace MU.GameTools.Squish;

public sealed class Native
{
    public enum Flags
    {
        None = 0,
        DXT1 = 1,
        DXT3 = 2,
        DXT5 = 4,
        ColourClusterFit = 8,
        ColourRangeFit = 0x10,
        ColourMetricPerceptual = 0x20,
        ColourMetricUniform = 0x40,
        WeightColourByAlpha = 0x80,
        ColourIterativeClusterFit = 0x100
    }

    private sealed class Native32
    {
        [DllImport("squish_32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SquishCompressImage")]
        internal static extern void CompressImage([MarshalAs(UnmanagedType.LPArray)] byte[] rgba, int width, int height, [MarshalAs(UnmanagedType.LPArray)] byte[] blocks, int flags);

        [DllImport("squish_32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SquishDecompressImage")]
        internal static extern void DecompressImage([MarshalAs(UnmanagedType.LPArray)] byte[] rgba, int width, int height, [MarshalAs(UnmanagedType.LPArray)] byte[] blocks, int flags);
    }

    private sealed class Native64
    {
        [DllImport("squish_64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SquishCompressImage")]
        internal static extern void CompressImage([MarshalAs(UnmanagedType.LPArray)] byte[] rgba, int width, int height, [MarshalAs(UnmanagedType.LPArray)] byte[] blocks, int flags);

        [DllImport("squish_64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SquishDecompressImage")]
        internal static extern void DecompressImage([MarshalAs(UnmanagedType.LPArray)] byte[] rgba, int width, int height, [MarshalAs(UnmanagedType.LPArray)] byte[] blocks, int flags);
    }

    private static bool Is64Bit()
    {
        return Marshal.SizeOf((object)(long)IntPtr.Zero) == 8;
    }

    private static void CallDecompressImage(byte[] rgba, int width, int height, byte[] blocks, int flags)
    {
        if (Is64Bit())
        {
            Native64.DecompressImage(rgba, width, height, blocks, flags);
        }
        else
        {
            Native32.DecompressImage(rgba, width, height, blocks, flags);
        }
    }

    public static byte[] DecompressImage(byte[] blocks, int width, int height, Flags flags)
    {
        byte[] array = new byte[width * height * 4];
        CallDecompressImage(array, width, height, blocks, (int)flags);
        return array;
    }
}

