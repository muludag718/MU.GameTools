using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Shoot)]
	public class ShootTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool ApplyOnParent { get; set; }

		public ulong GrabSlot { get; set; }

		public ulong WeaponEntry { get; set; }

		public ulong Shooter { get; set; }

		public ulong AmmoProfile { get; set; }

		public ulong UserProfile { get; set; }

		public int FixedDirection { get; set; }

		public SpaceType FixedDirectionSpace { get; set; }

		public Vector FixedDirectionDirection { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(ApplyOnParent, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueU64(WeaponEntry, endianess);
			output.WriteValueU64(Shooter, endianess);
			output.WriteValueU64(AmmoProfile, endianess);
			output.WriteValueU64(UserProfile, endianess);
			output.WriteValueS32(FixedDirection, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, FixedDirectionSpace);
			FixedDirectionDirection.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			ApplyOnParent = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			WeaponEntry = input.ReadValueU64(endianess);
			Shooter = input.ReadValueU64(endianess);
			AmmoProfile = input.ReadValueU64(endianess);
			UserProfile = input.ReadValueU64(endianess);
			FixedDirection = input.ReadValueS32(endianess);
			FixedDirectionSpace = BaseProperty.DeserializePropertyEnum<SpaceType>(input, endianess);
			FixedDirectionDirection = new Vector(input, endianess);
		}
	}
}
