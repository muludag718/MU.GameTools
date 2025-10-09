using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.JointAnchorToAnimation)]
	public class JointAnchorToAnimationTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Joint { get; set; }

		public ulong Animation { get; set; }

		public float Frame { get; set; }

		public int Priority { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Joint, endianess);
			output.WriteValueU64(Animation, endianess);
			output.WriteValueF32(Frame, endianess);
			output.WriteValueS32(Priority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Joint = input.ReadValueU64(endianess);
			Animation = input.ReadValueU64(endianess);
			Frame = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
		}
	}
}
