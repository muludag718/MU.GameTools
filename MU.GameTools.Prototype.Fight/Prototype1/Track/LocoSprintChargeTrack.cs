using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.LocoSprintCharge)]
	public class LocoSprintChargeTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float VelocityMin { get; set; }

		public float VelocityMid { get; set; }

		public float VelocityMax { get; set; }

		public float AccelerationMin { get; set; }

		public float AccelerationMid { get; set; }

		public float AccelerationMax { get; set; }

		public float Deceleration { get; set; }

		public float TurnVelocityMin { get; set; }

		public float TurnVelocityMax { get; set; }

		public float TurnAccelerationMin { get; set; }

		public float TurnAccelerationMax { get; set; }

		public float TurnDeceleration { get; set; }

		public float LeanRate { get; set; }

		public float Phase { get; set; }

		public ulong Locomotion { get; set; }

		public ulong AnimChargeMin { get; set; }

		public ulong AnimChargeMax { get; set; }

		public ulong AnimLeanEast { get; set; }

		public ulong AnimLeanWest { get; set; }

		public bool ForceAnimationVelocities { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(VelocityMin, endianess);
			output.WriteValueF32(VelocityMid, endianess);
			output.WriteValueF32(VelocityMax, endianess);
			output.WriteValueF32(AccelerationMin, endianess);
			output.WriteValueF32(AccelerationMid, endianess);
			output.WriteValueF32(AccelerationMax, endianess);
			output.WriteValueF32(Deceleration, endianess);
			output.WriteValueF32(TurnVelocityMin, endianess);
			output.WriteValueF32(TurnVelocityMax, endianess);
			output.WriteValueF32(TurnAccelerationMin, endianess);
			output.WriteValueF32(TurnAccelerationMax, endianess);
			output.WriteValueF32(TurnDeceleration, endianess);
			output.WriteValueF32(LeanRate, endianess);
			output.WriteValueF32(Phase, endianess);
			output.WriteValueU64(Locomotion, endianess);
			output.WriteValueU64(AnimChargeMin, endianess);
			output.WriteValueU64(AnimChargeMax, endianess);
			output.WriteValueU64(AnimLeanEast, endianess);
			output.WriteValueU64(AnimLeanWest, endianess);
			output.WriteValueB32(ForceAnimationVelocities, endianess);
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
			VelocityMin = input.ReadValueF32(endianess);
			VelocityMid = input.ReadValueF32(endianess);
			VelocityMax = input.ReadValueF32(endianess);
			AccelerationMin = input.ReadValueF32(endianess);
			AccelerationMid = input.ReadValueF32(endianess);
			AccelerationMax = input.ReadValueF32(endianess);
			Deceleration = input.ReadValueF32(endianess);
			TurnVelocityMin = input.ReadValueF32(endianess);
			TurnVelocityMax = input.ReadValueF32(endianess);
			TurnAccelerationMin = input.ReadValueF32(endianess);
			TurnAccelerationMax = input.ReadValueF32(endianess);
			TurnDeceleration = input.ReadValueF32(endianess);
			LeanRate = input.ReadValueF32(endianess);
			Phase = input.ReadValueF32(endianess);
			Locomotion = input.ReadValueU64(endianess);
			AnimChargeMin = input.ReadValueU64(endianess);
			AnimChargeMax = input.ReadValueU64(endianess);
			AnimLeanEast = input.ReadValueU64(endianess);
			AnimLeanWest = input.ReadValueU64(endianess);
			ForceAnimationVelocities = input.ReadValueB32(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
