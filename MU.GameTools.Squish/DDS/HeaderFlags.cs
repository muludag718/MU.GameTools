namespace MU.GameTools.Squish.DDS;

[Flags]
public enum HeaderFlags : uint
{
    Texture = 0x1007u,
    Mipmap = 0x20000u,
    Volume = 0x800000u,
    Pitch = 8u,
    LinerSize = 0x80000u
}

