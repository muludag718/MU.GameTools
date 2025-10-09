using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.ShootCheckOverheating)]
	public class ShootCheckOverheatingCondition : P1Condition
	{
		public bool TestOnParent { get; set; }

		public ulong GrabSlot { get; set; }

		public ulong WeaponEntry { get; set; }

		public bool Match { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(TestOnParent, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueU64(WeaponEntry, endianess);
			output.WriteValueB32(Match, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TestOnParent = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			WeaponEntry = input.ReadValueU64(endianess);
			Match = input.ReadValueB32(endianess);
		}
	}
}
