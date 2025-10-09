using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.PowerRagdollByPose)]
	public class PowerRagdollByPoseTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong PoseAnimName { get; set; }

		public float AnimFrame { get; set; }

		public ulong ConstraintPropertiesName { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(PoseAnimName, endianess);
			output.WriteValueF32(AnimFrame, endianess);
			output.WriteValueU64(ConstraintPropertiesName, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			PoseAnimName = input.ReadValueU64(endianess);
			AnimFrame = input.ReadValueF32(endianess);
			ConstraintPropertiesName = input.ReadValueU64(endianess);
		}
	}
}
