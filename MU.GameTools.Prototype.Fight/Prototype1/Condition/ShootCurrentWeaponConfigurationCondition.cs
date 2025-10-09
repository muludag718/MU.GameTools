using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.ShootCurrentWeaponConfiguration)]
	public class ShootCurrentWeaponConfigurationCondition : P1Condition
	{
		public ulong WeaponConfiguration { get; set; }

		public bool Match { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(WeaponConfiguration, endianess);
			output.WriteValueB32(Match, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			WeaponConfiguration = input.ReadValueU64(endianess);
			Match = input.ReadValueB32(endianess);
		}
	}
}
