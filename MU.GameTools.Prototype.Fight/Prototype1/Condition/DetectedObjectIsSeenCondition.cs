using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.DetectedObjectIsSeen)]
	public class DetectedObjectIsSeenCondition : P1Condition
	{
		public bool Seen { get; set; }

		public float MaxDistanceFactor { get; set; }

		public float MaxAngle { get; set; }

		public bool OnlyMilitary { get; set; }

		public bool ExcludeIfCantReport { get; set; }

		public float MaxDistance { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Seen, endianess);
			output.WriteValueF32(MaxDistanceFactor, endianess);
			output.WriteValueF32(MaxAngle, endianess);
			output.WriteValueB32(OnlyMilitary, endianess);
			output.WriteValueB32(ExcludeIfCantReport, endianess);
			output.WriteValueF32(MaxDistance, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Seen = input.ReadValueB32(endianess);
			MaxDistanceFactor = input.ReadValueF32(endianess);
			MaxAngle = input.ReadValueF32(endianess);
			OnlyMilitary = input.ReadValueB32(endianess);
			ExcludeIfCantReport = input.ReadValueB32(endianess);
			MaxDistance = input.ReadValueF32(endianess);
		}
	}
}
