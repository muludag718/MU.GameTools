using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ShootCheckCooldownTime)]
	public class ShootCheckCooldownTimeCondition : P1Condition
	{
		public bool TestOnParent { get; set; }

		public ulong GrabSlot { get; set; }

		public ulong WeaponEntry { get; set; }

		public CompareOperator Compare { get; set; }

		public float RequiredTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(TestOnParent, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueU64(WeaponEntry, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(RequiredTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TestOnParent = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			WeaponEntry = input.ReadValueU64(endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			RequiredTime = input.ReadValueF32(endianess);
		}
	}
}
