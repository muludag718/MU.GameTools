using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.ChangedTargetSince)]
	public class ChangedTargetSinceCondition : P1Condition
	{
		public ulong Timer { get; set; }

		public float Time { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Timer, endianess);
			output.WriteValueF32(Time, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Timer = input.ReadValueU64(endianess);
			Time = input.ReadValueF32(endianess);
		}
	}
}
