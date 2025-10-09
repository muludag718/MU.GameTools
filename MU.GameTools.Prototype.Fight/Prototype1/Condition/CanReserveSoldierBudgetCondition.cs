using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.CanReserveSoldierBudget)]
	public class CanReserveSoldierBudgetCondition : P1Condition
	{
		public int Soldiers { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueS32(Soldiers, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Soldiers = input.ReadValueS32(endianess);
		}
	}
}
