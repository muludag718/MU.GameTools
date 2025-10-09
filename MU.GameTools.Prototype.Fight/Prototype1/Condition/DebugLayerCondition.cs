using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.DebugLayer)]
	public class DebugLayerCondition : P1Condition
	{
		public string DebugLayer { get; set; }

		public bool Enabled { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteStringAlignedU32(DebugLayer, endianess);
			output.WriteValueB32(Enabled, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			DebugLayer = input.ReadStringAlignedU32(endianess);
			Enabled = input.ReadValueB32(endianess);
		}
	}
}
