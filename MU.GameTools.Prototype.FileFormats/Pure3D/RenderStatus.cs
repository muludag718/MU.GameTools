using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(65559u)]
	public class RenderStatus : BaseNode
	{
		public uint CastShadow { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(CastShadow, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			CastShadow = input.ReadValueU32(endian);
		}
	}
}
