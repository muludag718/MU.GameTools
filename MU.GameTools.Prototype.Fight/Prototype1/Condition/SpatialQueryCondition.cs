using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.SpatialQuery)]
	public class SpatialQueryCondition : P1Condition
	{
		public enum WhatType : ulong
		{
			Faction = 1292973792857699032uL,
			FactionMilitary = 15591361829469292792uL,
			FactionInfected = 8190877763150242633uL,
			Allies = 18219311826121095490uL,
			Enemies = 6865748069480709712uL,
			Classname = 15041496124380207515uL
		}

		public enum WhenType : ulong
		{
			MyPosition = 284889925761261031uL,
			TargetPosition = 9047280947883197886uL
		}

		public WhatType What { get; set; }

		public ulong WhatData { get; set; }

		public WhenType Where { get; set; }

		public float MaxDistance { get; set; }

		public bool ExcludeSelf { get; set; }

		public CompareOperator Compare { get; set; }

		public int Inside { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, What);
			output.WriteValueU64(WhatData, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Where);
			output.WriteValueF32(MaxDistance, endianess);
			output.WriteValueB32(ExcludeSelf, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueS32(Inside, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			What = BaseProperty.DeserializePropertyEnum<WhatType>(input, endianess);
			WhatData = input.ReadValueU64(endianess);
			Where = BaseProperty.DeserializePropertyEnum<WhenType>(input, endianess);
			MaxDistance = input.ReadValueF32(endianess);
			ExcludeSelf = input.ReadValueB32(endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Inside = input.ReadValueS32(endianess);
		}
	}
}
