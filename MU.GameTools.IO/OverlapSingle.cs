using System.Runtime.InteropServices;

namespace MU.GameTools.IO;

[StructLayout(LayoutKind.Explicit)]
internal struct OverlapSingle
{
    [FieldOffset(0)]
    private float F;

    [FieldOffset(0)]
    private uint U;

    public float AsF
    {
        get
        {
            return F;
        }
        set
        {
            F = value;
        }
    }

    public uint AsU
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

    public OverlapSingle(float f)
    {
        U = 0u;
        F = f;
    }

    public OverlapSingle(uint u)
    {
        F = 0f;
        U = u;
    }
}
