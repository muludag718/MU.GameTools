using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ShootSelectWeaponConfiguration)]
	public class ShootSelectWeaponConfigurationTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool ApplyOnParent { get; set; }

		public ulong WeaponConfiguration { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(ApplyOnParent, endianess);
			output.WriteValueU64(WeaponConfiguration, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			ApplyOnParent = input.ReadValueB32(endianess);
			WeaponConfiguration = input.ReadValueU64(endianess);
		}
	}
}
