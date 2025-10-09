using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.Stuck)]
	public class StuckCondition : P1Condition
	{
		public bool Stuck { get; set; }

		public float TimeStuck { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Stuck, endianess);
			output.WriteValueF32(TimeStuck, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Stuck = input.ReadValueB32(endianess);
			TimeStuck = input.ReadValueF32(endianess);
		}
	}
}
