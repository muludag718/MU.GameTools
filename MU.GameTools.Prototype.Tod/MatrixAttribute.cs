using MU.GameTools.Common;
using MU.GameTools.IO;


namespace MU.GameTools.Prototype.Tod;

public class MatrixAttribute : MetaAttribute
{
    public Vector3 Position { get; set; }

    public Vector3 Rotation { get; set; }

    public float Scale { get; set; }

    public override void Serialize(Stream output, Endian endian)
    {
        base.Serialize(output, endian);
        Position.Serialize(output, endian);
        Rotation.Serialize(output, endian);
        output.WriteValueF32(Scale, endian);
    }

    public override void Deserialize(Stream input, Endian endian)
    {
        base.Deserialize(input, endian);
        Position = new Vector3(input, endian);
        Rotation = new Vector3(input, endian);
        Scale = input.ReadValueF32(endian);
    }
}
