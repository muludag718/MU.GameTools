using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats
{
	[TypeConverter(typeof(MyTypeConverter))]
	public class Vector2 : ISerializable
	{
		[Descriptable]
		public float X { get; set; }

		[Descriptable]
		public float Y { get; set; }

		public override string ToString()
		{
			return $"Vector2: X = {X} | Y = {Y}";
		}

		public Vector2()
		{
		}

		public Vector2(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueF32(X, endian);
			output.WriteValueF32(Y, endian);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			X = input.ReadValueF32(endian);
			Y = input.ReadValueF32(endian);
		}
	}
}
