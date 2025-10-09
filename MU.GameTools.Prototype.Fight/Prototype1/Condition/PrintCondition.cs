using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.Print)]
	public class PrintCondition : P1Condition
	{
		public string Channel { get; set; }

		public string Text { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteStringAlignedU32(Channel, endianess);
			output.WriteStringAlignedU32(Text, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Channel = input.ReadStringAlignedU32(endianess);
			Text = input.ReadStringAlignedU32(endianess);
		}
	}
}
