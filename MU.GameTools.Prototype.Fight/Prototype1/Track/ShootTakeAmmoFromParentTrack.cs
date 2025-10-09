using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ShootTakeAmmoFromParent)]
	public class ShootTakeAmmoFromParentTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong WeaponGrabSlot { get; set; }

		public ulong ReceiverGrabSlot { get; set; }

		public ulong ReceiverJoint { get; set; }

		public Vector ReceiverPositionOffset { get; set; } = new Vector();

		public Vector ReceiverRotationOffset { get; set; } = new Vector();

		public ulong ChildJoint { get; set; }

		public Vector ChildPositionOffset { get; set; } = new Vector();

		public Vector ChildRotationOffset { get; set; } = new Vector();

		public float BlendTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(WeaponGrabSlot, endianess);
			output.WriteValueU64(ReceiverGrabSlot, endianess);
			output.WriteValueU64(ReceiverJoint, endianess);
			ReceiverPositionOffset.Serialize(output, endianess);
			ReceiverRotationOffset.Serialize(output, endianess);
			output.WriteValueU64(ChildJoint, endianess);
			ChildPositionOffset.Serialize(output, endianess);
			ChildRotationOffset.Serialize(output, endianess);
			output.WriteValueF32(BlendTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			WeaponGrabSlot = input.ReadValueU64(endianess);
			ReceiverGrabSlot = input.ReadValueU64(endianess);
			ReceiverJoint = input.ReadValueU64(endianess);
			ReceiverPositionOffset.Deserialize(input, endianess);
			ReceiverRotationOffset.Deserialize(input, endianess);
			ChildJoint = input.ReadValueU64(endianess);
			ChildPositionOffset.Deserialize(input, endianess);
			ChildRotationOffset.Deserialize(input, endianess);
			BlendTime = input.ReadValueF32(endianess);
		}
	}
}
