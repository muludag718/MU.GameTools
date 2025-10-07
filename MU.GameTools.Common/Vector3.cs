using MU.GameTools.IO;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MU.GameTools.Common;

[TypeConverter(typeof(MyTypeConverter))]
[DataContract(Namespace = "http://datacontract.gib.me/prototype")]
public class Vector3 : MU.GameTools.Common.ISerializable
{
    [DataMember(Name = "x", Order = 1)]
    [Descriptable]
    public float X { get; set; }

    [DataMember(Name = "y", Order = 1)]
    [Descriptable]
    public float Y { get; set; }

    [DataMember(Name = "z", Order = 1)]
    [Descriptable]
    public float Z { get; set; }

    public override string ToString()
    {
        return $"Vector3: X = {X} | Y = {Y} | Y = {Z}";
    }

    public Vector3()
    {
    }

    public Vector3(Stream input, Endian endian)
    {
        Deserialize(input, endian);
    }

    public void Serialize(Stream output, Endian endian)
    {
        output.WriteValueF32(X, endian);
        output.WriteValueF32(Y, endian);
        output.WriteValueF32(Z, endian);
    }

    public void Deserialize(Stream input, Endian endian)
    {
        X = input.ReadValueF32(endian);
        Y = input.ReadValueF32(endian);
        Z = input.ReadValueF32(endian);
    }
}
