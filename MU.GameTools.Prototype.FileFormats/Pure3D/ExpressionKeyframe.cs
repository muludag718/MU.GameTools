using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(1184518u)]
	public class ExpressionKeyframe : BaseNode
	{
		public uint Unknown1 { get; set; }

		public uint Order { get; set; }

		public uint Unknown3 { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			output.WriteValueU32(Order, endian);
			output.WriteValueU32(Unknown3, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32(endian);
			Order = input.ReadValueU32(endian);
			Unknown3 = input.ReadValueU32(endian);
		}
	}
}
