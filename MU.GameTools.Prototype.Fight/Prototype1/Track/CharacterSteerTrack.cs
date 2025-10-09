using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.CharacterSteer)]
	public class CharacterSteerTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Acceleration { get; set; }

		public float TurningVelocity { get; set; }

		public float VelocityWalk { get; set; }

		public float VelocityRun { get; set; }

		public float Gravity { get; set; }

		public float Phase { get; set; }

		public ulong Locomotion { get; set; }

		public ulong AnimIdle { get; set; }

		public ulong AnimWalk { get; set; }

		public ulong AnimRun { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public bool DisableRootMotion { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Acceleration, endianess);
			output.WriteValueF32(TurningVelocity, endianess);
			output.WriteValueF32(VelocityWalk, endianess);
			output.WriteValueF32(VelocityRun, endianess);
			output.WriteValueF32(Gravity, endianess);
			output.WriteValueF32(Phase, endianess);
			output.WriteValueU64(Locomotion, endianess);
			output.WriteValueU64(AnimIdle, endianess);
			output.WriteValueU64(AnimWalk, endianess);
			output.WriteValueU64(AnimRun, endianess);
			output.WriteValueU64(Partition, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
			output.WriteValueB32(DisableRootMotion, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Acceleration = input.ReadValueF32(endianess);
			TurningVelocity = input.ReadValueF32(endianess);
			VelocityWalk = input.ReadValueF32(endianess);
			VelocityRun = input.ReadValueF32(endianess);
			Gravity = input.ReadValueF32(endianess);
			Phase = input.ReadValueF32(endianess);
			Locomotion = input.ReadValueU64(endianess);
			AnimIdle = input.ReadValueU64(endianess);
			AnimWalk = input.ReadValueU64(endianess);
			AnimRun = input.ReadValueU64(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
			DisableRootMotion = input.ReadValueB32(endianess);
		}
	}
}
