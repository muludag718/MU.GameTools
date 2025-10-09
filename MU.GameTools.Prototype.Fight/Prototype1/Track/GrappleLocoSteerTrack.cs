using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GrappleLocoSteer)]
	public class GrappleLocoSteerTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Locomotion { get; set; }

		public ulong AnimIdle { get; set; }

		public ulong AnimWalk { get; set; }

		public ulong AnimRun { get; set; }

		public float SyncFrameIdle { get; set; }

		public float SyncFrameWalk { get; set; }

		public float SyncFrameRun { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Locomotion, endianess);
			output.WriteValueU64(AnimIdle, endianess);
			output.WriteValueU64(AnimWalk, endianess);
			output.WriteValueU64(AnimRun, endianess);
			output.WriteValueF32(SyncFrameIdle, endianess);
			output.WriteValueF32(SyncFrameWalk, endianess);
			output.WriteValueF32(SyncFrameRun, endianess);
			output.WriteValueU64(Partition, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Locomotion = input.ReadValueU64(endianess);
			AnimIdle = input.ReadValueU64(endianess);
			AnimWalk = input.ReadValueU64(endianess);
			AnimRun = input.ReadValueU64(endianess);
			SyncFrameIdle = input.ReadValueF32(endianess);
			SyncFrameWalk = input.ReadValueF32(endianess);
			SyncFrameRun = input.ReadValueF32(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
