using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Alert)]
	[KnownCondition(ConditionHash.AllyWithMilitary)]
	public class AllyWithMilitaryCondition : P1Condition
	{
		public bool Ally { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Ally, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Ally = input.ReadValueB32(endianess);
		}
	}
}
