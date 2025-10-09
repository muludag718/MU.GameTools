using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight
{
	public class Color
	{
		public float R { get; set; }

		public float G { get; set; }

		public float B { get; set; }

		public float A { get; set; }

		public Color()
		{
		}

		public Color(Stream input, Endian endianess)
		{
			Deserialize(input, endianess);
		}

		public void Deserialize(Stream input, Endian endianess)
		{
			R = input.ReadValueF32(endianess);
			G = input.ReadValueF32(endianess);
			B = input.ReadValueF32(endianess);
			A = input.ReadValueF32(endianess);
		}

		public void Serialize(Stream output, Endian endianess)
		{
			output.WriteValueF32(R, endianess);
			output.WriteValueF32(G, endianess);
			output.WriteValueF32(B, endianess);
			output.WriteValueF32(A, endianess);
		}
	}
}
