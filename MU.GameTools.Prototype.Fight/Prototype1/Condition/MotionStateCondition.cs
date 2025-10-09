using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.MotionState)]
	public class MotionStateCondition : P1Condition
	{
		public MovementMotionState State { get; set; }

		public ulong Name { get; set; }

		public bool Match { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, State);
			output.WriteValueU64(Name, endianess);
			output.WriteValueB32(Match, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			State = BaseProperty.DeserializePropertyEnum<MovementMotionState>(input, endianess);
			Name = input.ReadValueU64(endianess);
			Match = input.ReadValueB32(endianess);
		}
	}
}
