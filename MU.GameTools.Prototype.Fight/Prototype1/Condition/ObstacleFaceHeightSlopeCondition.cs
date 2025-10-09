using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ObstacleFaceHeightSlope)]
	public class ObstacleFaceHeightSlopeCondition : P1Condition
	{
		public float FaceHeightMin { get; set; }

		public float HeightMax { get; set; }

		public float SlopeMax { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(FaceHeightMin, endianess);
			output.WriteValueF32(HeightMax, endianess);
			output.WriteValueF32(SlopeMax, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			FaceHeightMin = input.ReadValueF32(endianess);
			HeightMax = input.ReadValueF32(endianess);
			SlopeMax = input.ReadValueF32(endianess);
		}
	}
}
