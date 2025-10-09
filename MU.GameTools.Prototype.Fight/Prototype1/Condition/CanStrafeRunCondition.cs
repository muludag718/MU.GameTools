using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.CanStrafeRun)]
	public class CanStrafeRunCondition : P1Condition
	{
		public float TimeTolerance { get; set; }

		public float DistanceTolerance { get; set; }

		public int MinDelta { get; set; }

		public int MaxDelta { get; set; }

		public bool FarthestPossible { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeTolerance, endianess);
			output.WriteValueF32(DistanceTolerance, endianess);
			output.WriteValueS32(MinDelta, endianess);
			output.WriteValueS32(MaxDelta, endianess);
			output.WriteValueB32(FarthestPossible, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeTolerance = input.ReadValueF32(endianess);
			DistanceTolerance = input.ReadValueF32(endianess);
			MinDelta = input.ReadValueS32(endianess);
			MaxDelta = input.ReadValueS32(endianess);
			FarthestPossible = input.ReadValueB32(endianess);
		}
	}
}
