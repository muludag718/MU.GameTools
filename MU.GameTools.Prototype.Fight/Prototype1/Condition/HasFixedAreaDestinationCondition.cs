using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.HasFixedAreaDestination)]
	public class HasFixedAreaDestinationCondition : P1Condition
	{
		public bool HasDestination { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(HasDestination, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			HasDestination = input.ReadValueB32(endianess);
		}
	}
}
