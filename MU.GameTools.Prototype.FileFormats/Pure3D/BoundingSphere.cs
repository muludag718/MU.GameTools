using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(65540u)]
	public class BoundingSphere : BaseNode
	{
		public float CenterX { get; set; }

		public float CenterY { get; set; }

		public float CenterZ { get; set; }

		public float Radius { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueF32(CenterX, endian);
			output.WriteValueF32(CenterY, endian);
			output.WriteValueF32(CenterZ, endian);
			output.WriteValueF32(Radius, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			CenterX = input.ReadValueF32(endian);
			CenterY = input.ReadValueF32(endian);
			CenterZ = input.ReadValueF32(endian);
			Radius = input.ReadValueF32(endian);
		}
	}
}
