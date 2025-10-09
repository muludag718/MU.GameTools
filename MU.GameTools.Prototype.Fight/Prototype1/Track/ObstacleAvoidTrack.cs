using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ObstacleAvoid)]
	public class ObstacleAvoidTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float HeightMin { get; set; }

		public float UpVelocityMax { get; set; }

		public float ForwardVelocityMin { get; set; }

		public float ForwardVelocityMax { get; set; }

		public float TurnVelocityMin { get; set; }

		public float TurnVelocityMax { get; set; }

		public float TurnAccelerationMin { get; set; }

		public float TurnAccelerationMax { get; set; }

		public float PoleAvoidVelocity { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(HeightMin, endianess);
			output.WriteValueF32(UpVelocityMax, endianess);
			output.WriteValueF32(ForwardVelocityMin, endianess);
			output.WriteValueF32(ForwardVelocityMax, endianess);
			output.WriteValueF32(TurnVelocityMin, endianess);
			output.WriteValueF32(TurnVelocityMax, endianess);
			output.WriteValueF32(TurnAccelerationMin, endianess);
			output.WriteValueF32(TurnAccelerationMax, endianess);
			output.WriteValueF32(PoleAvoidVelocity, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			HeightMin = input.ReadValueF32(endianess);
			UpVelocityMax = input.ReadValueF32(endianess);
			ForwardVelocityMin = input.ReadValueF32(endianess);
			ForwardVelocityMax = input.ReadValueF32(endianess);
			TurnVelocityMin = input.ReadValueF32(endianess);
			TurnVelocityMax = input.ReadValueF32(endianess);
			TurnAccelerationMin = input.ReadValueF32(endianess);
			TurnAccelerationMax = input.ReadValueF32(endianess);
			PoleAvoidVelocity = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
