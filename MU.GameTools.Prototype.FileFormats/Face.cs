using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats
{
	[TypeConverter(typeof(VectorTypeConverter))]
	[DataContract(Namespace = "http://datacontract.gib.me/prototype")]
	public class Face
	{
		[DataMember(Name = "Point 1", Order = 1)]
		public ushort Point1 { get; set; }

		[DataMember(Name = "Point 2", Order = 2)]
		public ushort Point2 { get; set; }

		[DataMember(Name = "Point 3", Order = 3)]
		public ushort Point3 { get; set; }

		public Face()
		{
		}

		public Face(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU16(Point1, endian);
			output.WriteValueU16(Point2, endian);
			output.WriteValueU16(Point3, endian);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			Point1 = input.ReadValueU16(endian);
			Point2 = input.ReadValueU16(endian);
			Point3 = input.ReadValueU16(endian);
		}
	}
}
