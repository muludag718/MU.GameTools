using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.TargetHasLoF)]
	public class TargetHasLoFCondition : P1Condition
	{
		public float TimeTolerance { get; set; }

		public float DistanceTolerance { get; set; }

		public CollisionFlagsType CollisionFlags { get; set; }

		public ColliderType CollideWithType { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public float Radius { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeTolerance, endianess);
			output.WriteValueF32(DistanceTolerance, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CollisionFlags);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWithType);
			Offset.Serialize(output, endianess);
			output.WriteValueF32(Radius, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeTolerance = input.ReadValueF32(endianess);
			DistanceTolerance = input.ReadValueF32(endianess);
			CollisionFlags = BaseProperty.DeserializePropertyEnum<CollisionFlagsType>(input, endianess);
			CollideWithType = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
			Offset = new Vector(input, endianess);
			Radius = input.ReadValueF32(endianess);
		}
	}
}
