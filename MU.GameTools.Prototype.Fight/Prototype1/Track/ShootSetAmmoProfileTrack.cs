using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ShootSetAmmoProfile)]
	public class ShootSetAmmoProfileTrack : P1Track
	{
		public bool ApplyOnParent { get; set; }

		public ulong GrabSlot { get; set; }

		public ulong WeaponEntry { get; set; }

		public ulong ProfileName { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(ApplyOnParent, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueU64(WeaponEntry, endianess);
			output.WriteValueU64(ProfileName, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ApplyOnParent = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			WeaponEntry = input.ReadValueU64(endianess);
			ProfileName = input.ReadValueU64(endianess);
		}
	}
}
