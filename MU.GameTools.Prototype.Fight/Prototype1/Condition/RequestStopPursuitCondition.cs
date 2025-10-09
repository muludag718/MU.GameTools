using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.RequestStopPursuit)]
	public class RequestStopPursuitCondition : P1Condition
	{
		public float MinActorAge { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(MinActorAge, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			MinActorAge = input.ReadValueF32(endianess);
		}
	}
}
