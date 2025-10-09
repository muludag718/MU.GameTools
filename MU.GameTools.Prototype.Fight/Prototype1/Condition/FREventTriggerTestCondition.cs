using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.FREventTriggerTest)]
	public class FREventTriggerTestCondition : P1Condition
	{
		public string Name { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteStringAlignedU32(Name, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Name = input.ReadStringAlignedU32(endianess);
		}
	}
}
