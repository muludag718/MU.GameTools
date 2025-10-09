using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.HitWeapon)]
	public class HitWeaponTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong GrabSlot { get; set; }

		public int CollisionCountMax { get; set; }

		public float Damage { get; set; }

		public DamageType DamageType { get; set; }

		public Vector Impulse { get; set; } = new Vector();

		public BranchReference ReceiverBranch { get; set; } = new BranchReference();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueS32(CollisionCountMax, endianess);
			output.WriteValueF32(Damage, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
			Impulse.Serialize(output, endianess);
			ReceiverBranch.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			CollisionCountMax = input.ReadValueS32(endianess);
			Damage = input.ReadValueF32(endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
			Impulse.Deserialize(input, endianess);
			ReceiverBranch.Deserialize(input, endianess);
		}
	}
}
