using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats
{
	[TypeConverter(typeof(VectorTypeConverter))]
	[DataContract(Namespace = "http://datacontract.gib.me/prototype")]
	public class Vector3Int
	{
		[DataMember(Name = "x", Order = 1)]
		public uint X { get; set; }

		[DataMember(Name = "y", Order = 1)]
		public uint Y { get; set; }

		[DataMember(Name = "z", Order = 1)]
		public uint Z { get; set; }

		public Vector3Int()
		{
		}

		public Vector3Int(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(X, endian);
			output.WriteValueU32(Y, endian);
			output.WriteValueU32(Z, endian);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			X = input.ReadValueU32(endian);
			Y = input.ReadValueU32(endian);
			Z = input.ReadValueU32(endian);
		}
	}
}
