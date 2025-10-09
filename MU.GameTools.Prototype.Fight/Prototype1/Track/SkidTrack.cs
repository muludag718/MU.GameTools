using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Skid)]
	public class SkidTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float VelocityInit { get; set; }

		public float VelocityMin { get; set; }

		public float VelocityMax { get; set; }

		public float DecelerationMin { get; set; }

		public float DecelerationMax { get; set; }

		public float SprintVelocityDeceleration { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(VelocityInit, endianess);
			output.WriteValueF32(VelocityMin, endianess);
			output.WriteValueF32(VelocityMax, endianess);
			output.WriteValueF32(DecelerationMin, endianess);
			output.WriteValueF32(DecelerationMax, endianess);
			output.WriteValueF32(SprintVelocityDeceleration, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			VelocityInit = input.ReadValueF32(endianess);
			VelocityMin = input.ReadValueF32(endianess);
			VelocityMax = input.ReadValueF32(endianess);
			DecelerationMin = input.ReadValueF32(endianess);
			DecelerationMax = input.ReadValueF32(endianess);
			SprintVelocityDeceleration = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
