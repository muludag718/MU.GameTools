using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.TargetHasLoFDistance)]
	public class TargetHasLoFDistanceCondition : P1Condition
	{
		public float TimeTolerance { get; set; }

		public float DistanceTolerance { get; set; }

		public CollisionFlagsType CollisionFlags { get; set; }

		public ColliderType CollideWithTypeLessThanDist { get; set; }

		public ColliderType CollideWithTypeAnyDist { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public CompareOperator Compare { get; set; }

		public float DistanceFromTargetSqr { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeTolerance, endianess);
			output.WriteValueF32(DistanceTolerance, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CollisionFlags);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWithTypeLessThanDist);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWithTypeAnyDist);
			Offset.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(DistanceFromTargetSqr, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeTolerance = input.ReadValueF32(endianess);
			DistanceTolerance = input.ReadValueF32(endianess);
			CollisionFlags = BaseProperty.DeserializePropertyEnum<CollisionFlagsType>(input, endianess);
			CollideWithTypeLessThanDist = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
			CollideWithTypeAnyDist = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
			Offset.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			DistanceFromTargetSqr = input.ReadValueF32(endianess);
		}
	}
}
