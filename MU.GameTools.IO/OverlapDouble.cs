using System.Runtime.InteropServices;

namespace MU.GameTools.IO;

[StructLayout(LayoutKind.Explicit)]
internal struct OverlapDouble
{
    [FieldOffset(0)]
    private double D;

    [FieldOffset(0)]
    private ulong U;

    public double AsD
    {
        get
        {
            return D;
        }
        set
        {
            D = value;
        }
    }

    public ulong AsU
    {
        get
        {
            return U;
        }
        set
        {
            U = value;
        }
    }

    public OverlapDouble(double d)
    {
        U = 0uL;
        D = d;
    }

    public OverlapDouble(ulong u)
    {
        D = 0.0;
        U = u;
    }
}

