using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.NpcLOD)]
	public class NpcLod : P1Condition
	{
		public enum LODStatus : ulong
		{
			Active = 382516289659353610uL,
			Frozen = 9014025788489785814uL,
			LOD2 = 21454155989660813uL
		}

		public CompareOperator Compare { get; set; }

		public LODStatus Value { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			BaseProperty.SerializePropertyEnum(output, endianess, Value);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Value = BaseProperty.DeserializePropertyEnum<LODStatus>(input, endianess);
		}
	}
}
