using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Alert)]
	[KnownCondition(ConditionHash.InsideAlertedArea)]
	public class InsideAlertedAreaCondition : P1Condition
	{
		public bool Inside { get; set; }

		public bool PlayerOnly { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Inside, endianess);
			output.WriteValueB32(PlayerOnly, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Inside = input.ReadValueB32(endianess);
			PlayerOnly = input.ReadValueB32(endianess);
		}
	}
}
