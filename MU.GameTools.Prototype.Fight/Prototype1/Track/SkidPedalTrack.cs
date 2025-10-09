using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.SkidPedal)]
	public class SkidPedalTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEndMin { get; set; }

		public float TimeEnd { get; set; }

		public float Acceleration { get; set; }

		public float VelocityMin { get; set; }

		public float VelocityMax { get; set; }

		public float TurnVelocityMin { get; set; }

		public float TurnVelocityMax { get; set; }

		public float TurnAccelerationMin { get; set; }

		public float TurnAccelerationMax { get; set; }

		public ulong AnimNorth { get; set; }

		public ulong AnimWest { get; set; }

		public ulong AnimSouth { get; set; }

		public ulong AnimEast { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEndMin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Acceleration, endianess);
			output.WriteValueF32(VelocityMin, endianess);
			output.WriteValueF32(VelocityMax, endianess);
			output.WriteValueF32(TurnVelocityMin, endianess);
			output.WriteValueF32(TurnVelocityMax, endianess);
			output.WriteValueF32(TurnAccelerationMin, endianess);
			output.WriteValueF32(TurnAccelerationMax, endianess);
			output.WriteValueU64(AnimNorth, endianess);
			output.WriteValueU64(AnimWest, endianess);
			output.WriteValueU64(AnimSouth, endianess);
			output.WriteValueU64(AnimEast, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEndMin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Acceleration = input.ReadValueF32(endianess);
			VelocityMin = input.ReadValueF32(endianess);
			VelocityMax = input.ReadValueF32(endianess);
			TurnVelocityMin = input.ReadValueF32(endianess);
			TurnVelocityMax = input.ReadValueF32(endianess);
			TurnAccelerationMin = input.ReadValueF32(endianess);
			TurnAccelerationMax = input.ReadValueF32(endianess);
			AnimNorth = input.ReadValueU64(endianess);
			AnimWest = input.ReadValueU64(endianess);
			AnimSouth = input.ReadValueU64(endianess);
			AnimEast = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
