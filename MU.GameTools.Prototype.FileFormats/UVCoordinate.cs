using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats
{
	[TypeConverter(typeof(VectorTypeConverter))]
	[DataContract(Namespace = "http://datacontract.gib.me/prototype")]
	public class UVCoordinate
	{
		[DataMember(Name = "U", Order = 1)]
		public float U { get; set; }

		[DataMember(Name = "V", Order = 2)]
		public float V { get; set; }

		public UVCoordinate()
		{
		}

		public UVCoordinate(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueF32(U, endian);
			output.WriteValueF32(1f - V, endian);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			U = input.ReadValueF32(endian);
			V = 1f - input.ReadValueF32(endian);
		}
	}
}
