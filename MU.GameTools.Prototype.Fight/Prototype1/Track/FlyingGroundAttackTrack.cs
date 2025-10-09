using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.FlyingGroundAttack)]
	public class FlyingGroundAttackTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float VelocityXZMin { get; set; }

		public float VelocityXZMax { get; set; }

		public float AccelerationXZ { get; set; }

		public float Gravity { get; set; }

		public float TurningVelocity { get; set; }

		public float TargetOffset { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(VelocityXZMin, endianess);
			output.WriteValueF32(VelocityXZMax, endianess);
			output.WriteValueF32(AccelerationXZ, endianess);
			output.WriteValueF32(Gravity, endianess);
			output.WriteValueF32(TurningVelocity, endianess);
			output.WriteValueF32(TargetOffset, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			VelocityXZMin = input.ReadValueF32(endianess);
			VelocityXZMax = input.ReadValueF32(endianess);
			AccelerationXZ = input.ReadValueF32(endianess);
			Gravity = input.ReadValueF32(endianess);
			TurningVelocity = input.ReadValueF32(endianess);
			TargetOffset = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
