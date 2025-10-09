using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.DetectedObjectFacing)]
	public class DetectedObjectFacingCondition : P1Condition
	{
		public float Angle { get; set; }

		public float Arc { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(Angle, endianess);
			output.WriteValueF32(Arc, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Angle = input.ReadValueF32(endianess);
			Arc = input.ReadValueF32(endianess);
		}
	}
}
