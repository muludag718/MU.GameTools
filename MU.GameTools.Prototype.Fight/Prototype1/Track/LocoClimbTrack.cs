using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.LocoClimb)]
	public class LocoClimbTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Acceleration { get; set; }

		public float VelocityNorth { get; set; }

		public float VelocityStrafe { get; set; }

		public float VelocitySouth { get; set; }

		public float Phase { get; set; }

		public ulong Locomotion { get; set; }

		public ulong AnimIdle { get; set; }

		public ulong AnimNorth { get; set; }

		public ulong AnimEast { get; set; }

		public ulong AnimSouth { get; set; }

		public ulong AnimWest { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Acceleration, endianess);
			output.WriteValueF32(VelocityNorth, endianess);
			output.WriteValueF32(VelocityStrafe, endianess);
			output.WriteValueF32(VelocitySouth, endianess);
			output.WriteValueF32(Phase, endianess);
			output.WriteValueU64(Locomotion, endianess);
			output.WriteValueU64(AnimIdle, endianess);
			output.WriteValueU64(AnimNorth, endianess);
			output.WriteValueU64(AnimEast, endianess);
			output.WriteValueU64(AnimSouth, endianess);
			output.WriteValueU64(AnimWest, endianess);
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
			Acceleration = input.ReadValueF32(endianess);
			VelocityNorth = input.ReadValueF32(endianess);
			VelocityStrafe = input.ReadValueF32(endianess);
			VelocitySouth = input.ReadValueF32(endianess);
			Phase = input.ReadValueF32(endianess);
			Locomotion = input.ReadValueU64(endianess);
			AnimIdle = input.ReadValueU64(endianess);
			AnimNorth = input.ReadValueU64(endianess);
			AnimEast = input.ReadValueU64(endianess);
			AnimSouth = input.ReadValueU64(endianess);
			AnimWest = input.ReadValueU64(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
