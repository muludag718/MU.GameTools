using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats
{
	[TypeConverter(typeof(VectorTypeConverter))]
	public class Vector4Int
	{
		public ushort X { get; set; }

		public ushort Y { get; set; }

		public ushort Z { get; set; }

		public ushort W { get; set; }

		public Vector4Int()
		{
		}

		public Vector4Int(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU16(X, endian);
			output.WriteValueU16(Y, endian);
			output.WriteValueU16(Z, endian);
			output.WriteValueU16(W, endian);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			X = input.ReadValueU16(endian);
			Y = input.ReadValueU16(endian);
			Z = input.ReadValueU16(endian);
			W = input.ReadValueU16(endian);
		}
	}
}
