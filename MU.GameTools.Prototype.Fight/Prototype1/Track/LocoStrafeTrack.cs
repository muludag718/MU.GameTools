using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.LocoStrafe)]
	public class LocoStrafeTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Acceleration { get; set; }

		public float TurningVelocity { get; set; }

		public bool FixedFacing { get; set; }

		public float VelocityWalkNorth { get; set; }

		public float VelocityWalkStrafe { get; set; }

		public float VelocityWalkSouth { get; set; }

		public float VelocityRunNorth { get; set; }

		public float VelocityRunStrafe { get; set; }

		public float VelocityRunSouth { get; set; }

		public float Phase { get; set; }

		public ulong Locomotion { get; set; }

		public ulong AnimIdle { get; set; }

		public ulong AnimWalkNorth { get; set; }

		public ulong AnimWalkEast { get; set; }

		public ulong AnimWalkSouth { get; set; }

		public ulong AnimWalkWest { get; set; }

		public ulong AnimRunNorth { get; set; }

		public ulong AnimRunEast { get; set; }

		public ulong AnimRunSouth { get; set; }

		public ulong AnimRunWest { get; set; }

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
			output.WriteValueF32(TurningVelocity, endianess);
			output.WriteValueB32(FixedFacing, endianess);
			output.WriteValueF32(VelocityWalkNorth, endianess);
			output.WriteValueF32(VelocityWalkStrafe, endianess);
			output.WriteValueF32(VelocityWalkSouth, endianess);
			output.WriteValueF32(VelocityRunNorth, endianess);
			output.WriteValueF32(VelocityRunStrafe, endianess);
			output.WriteValueF32(VelocityRunSouth, endianess);
			output.WriteValueF32(Phase, endianess);
			output.WriteValueU64(Locomotion, endianess);
			output.WriteValueU64(AnimIdle, endianess);
			output.WriteValueU64(AnimWalkNorth, endianess);
			output.WriteValueU64(AnimWalkEast, endianess);
			output.WriteValueU64(AnimWalkSouth, endianess);
			output.WriteValueU64(AnimWalkWest, endianess);
			output.WriteValueU64(AnimRunNorth, endianess);
			output.WriteValueU64(AnimRunEast, endianess);
			output.WriteValueU64(AnimRunSouth, endianess);
			output.WriteValueU64(AnimRunWest, endianess);
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
			TurningVelocity = input.ReadValueF32(endianess);
			FixedFacing = input.ReadValueB32(endianess);
			VelocityWalkNorth = input.ReadValueF32(endianess);
			VelocityWalkStrafe = input.ReadValueF32(endianess);
			VelocityWalkSouth = input.ReadValueF32(endianess);
			VelocityRunNorth = input.ReadValueF32(endianess);
			VelocityRunStrafe = input.ReadValueF32(endianess);
			VelocityRunSouth = input.ReadValueF32(endianess);
			Phase = input.ReadValueF32(endianess);
			Locomotion = input.ReadValueU64(endianess);
			AnimIdle = input.ReadValueU64(endianess);
			AnimWalkNorth = input.ReadValueU64(endianess);
			AnimWalkEast = input.ReadValueU64(endianess);
			AnimWalkSouth = input.ReadValueU64(endianess);
			AnimWalkWest = input.ReadValueU64(endianess);
			AnimRunNorth = input.ReadValueU64(endianess);
			AnimRunEast = input.ReadValueU64(endianess);
			AnimRunSouth = input.ReadValueU64(endianess);
			AnimRunWest = input.ReadValueU64(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
