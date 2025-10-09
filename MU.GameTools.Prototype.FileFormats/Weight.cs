using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats
{
	[TypeConverter(typeof(VectorTypeConverter))]
	[DataContract(Namespace = "http://datacontract.gib.me/prototype")]
	public class Weight
	{
		[DataMember(Name = "x", Order = 1)]
		public float X { get; set; }

		[DataMember(Name = "y", Order = 1)]
		public float Y { get; set; }

		[DataMember(Name = "z", Order = 1)]
		public float Z { get; set; }

		[DataMember(Name = "Data?", Order = 1)]
		public byte[] Data { get; set; }

		public Weight()
		{
		}

		public Weight(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueF32(X, endian);
			output.WriteValueF32(Y, endian);
			output.WriteValueF32(Z, endian);
			output.WriteBytes(Data);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			X = input.ReadValueF32(endian);
			Y = input.ReadValueF32(endian);
			Z = input.ReadValueF32(endian);
			Data = input.ReadBytes(4);
		}
	}
}
