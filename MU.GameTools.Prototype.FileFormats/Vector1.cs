using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats
{
	public class Vector1 : ISerializable
	{
		public float X { get; set; }

		public Vector1()
		{
		}

		public Vector1(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueF32(X, endian);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			X = input.ReadValueF32(endian);
		}
	}
}
