using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod;

public class FloatAttribute : MetaAttribute
{
    public float Value { get; set; }

    public override void Serialize(Stream output, Endian endian)
    {
        base.Serialize(output, endian);
        output.WriteValueF32(Value, endian);
    }

    public override void Deserialize(Stream input, Endian endian)
    {
        base.Deserialize(input, endian);
        Value = input.ReadValueF32(endian);
    }
}
