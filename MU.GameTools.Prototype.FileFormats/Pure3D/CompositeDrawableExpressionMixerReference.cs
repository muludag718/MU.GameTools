using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(1191939u)]
	public class CompositeDrawableExpressionMixerReference : BaseNode
	{
		public uint Unknown1 { get; set; }

		public string ExpressionMixerName { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			output.WriteStringAlignedU8(ExpressionMixerName);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32(endian);
			ExpressionMixerName = input.ReadStringAlignedU8();
		}
	}
}
