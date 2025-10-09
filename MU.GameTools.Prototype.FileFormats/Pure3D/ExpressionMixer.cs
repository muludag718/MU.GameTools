using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(135170u)]
	public class ExpressionMixer : BaseNode
	{
		public uint Unknown1 { get; set; }

		public string Name { get; set; }

		public uint Unknown3 { get; set; }

		public string CompositeDrawableName { get; set; }

		public string ExpressionGroupName { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Name + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			output.WriteStringAlignedU8(Name);
			output.WriteValueU32(Unknown3, endian);
			output.WriteStringAlignedU8(CompositeDrawableName);
			output.WriteStringAlignedU8(ExpressionGroupName);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32(endian);
			Name = input.ReadStringAlignedU8();
			Unknown3 = input.ReadValueU32(endian);
			CompositeDrawableName = input.ReadStringAlignedU8();
			ExpressionGroupName = input.ReadStringAlignedU8();
		}
	}
}
