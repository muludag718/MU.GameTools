using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.DetectedObjectAngle)]
	public class DetectedObjectAngleCondition : P1Condition
	{
		public enum DetectedObjectAngleType : ulong
		{
			Facing = 10328104250444425114uL,
			Input = 5158950104358209040uL
		}

		public DetectedObjectAngleType Type { get; set; }

		public float Angle { get; set; }

		public float Arc { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			output.WriteValueF32(Angle, endianess);
			output.WriteValueF32(Arc, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = BaseProperty.DeserializePropertyEnum<DetectedObjectAngleType>(input, endianess);
			Angle = input.ReadValueF32(endianess);
			Arc = input.ReadValueF32(endianess);
		}
	}
}
