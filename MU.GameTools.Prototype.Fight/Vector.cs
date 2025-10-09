using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight
{
	public class Vector
	{
		public float X { get; set; }

		public float Y { get; set; }

		public float Z { get; set; }

		public Vector()
		{
		}

		public Vector(Stream input, Endian endianess)
		{
			Deserialize(input, endianess);
		}

		public void Deserialize(Stream input, Endian endianess)
		{
			X = input.ReadValueF32(endianess);
			Y = input.ReadValueF32(endianess);
			Z = input.ReadValueF32(endianess);
		}

		public void Serialize(Stream output, Endian endianess)
		{
			output.WriteValueF32(X, endianess);
			output.WriteValueF32(Y, endianess);
			output.WriteValueF32(Z, endianess);
		}
	}
}
