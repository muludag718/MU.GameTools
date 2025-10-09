using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(65539u)]
	public class BoundingBox : BaseNode
	{
		public float LowerX { get; set; }

		public float LowerY { get; set; }

		public float LowerZ { get; set; }

		public float UpperX { get; set; }

		public float UpperY { get; set; }

		public float UpperZ { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueF32(LowerX, endian);
			output.WriteValueF32(LowerY, endian);
			output.WriteValueF32(LowerZ, endian);
			output.WriteValueF32(UpperX, endian);
			output.WriteValueF32(UpperY, endian);
			output.WriteValueF32(UpperZ, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			LowerX = input.ReadValueF32(endian);
			LowerY = input.ReadValueF32(endian);
			LowerZ = input.ReadValueF32(endian);
			UpperX = input.ReadValueF32(endian);
			UpperY = input.ReadValueF32(endian);
			UpperZ = input.ReadValueF32(endian);
		}
	}
}
