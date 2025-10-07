using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Tod;


public class BoolAttribute : MetaAttribute
{
    public bool Value { get; set; }

    public override void Serialize(Stream output, Endian endian)
    {
        base.Serialize(output, endian);
        output.WriteValueB32(Value, endian);
    }

    public override void Deserialize(Stream input, Endian endian)
    {
        base.Deserialize(input, endian);
        Value = input.ReadValueB32(endian);
    }
}
