using MU.GameTools.IO;
using System.ComponentModel;

namespace MU.GameTools.Prototype.Tod;

[TypeConverter(typeof(MetaAttributeConverter))]
public abstract class MetaAttribute
{
    [Category("\u200bAttribute")]
    [DisplayName("Name")]
    public string AttributeName { get; set; }

    [Category("\u200bAttribute")]
    [ReadOnly(true)]
    public string TypeName { get; set; }

    [Browsable(false)]
    public short Flag { get; set; }

    public override string ToString()
    {
        return AttributeName;
    }

    public virtual void Serialize(Stream output, Endian endian)
    {
        output.WriteStringU32NoTerminator(AttributeName, endian);
        output.WriteStringU32NoTerminator(TypeName, endian);
        output.WriteValueS16(Flag, endian);
    }

    public virtual void Deserialize(Stream input, Endian endian)
    {
        Flag = input.ReadValueS16(endian);
    }
}
