using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WallSlide)]
	public class WallSlideTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float VelocityMin { get; set; }

		public float VelocityMax { get; set; }

		public float FrictionMin { get; set; }

		public float FrictionMax { get; set; }

		public bool Continuous { get; set; }

		public float ContinuousGravity { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(VelocityMin, endianess);
			output.WriteValueF32(VelocityMax, endianess);
			output.WriteValueF32(FrictionMin, endianess);
			output.WriteValueF32(FrictionMax, endianess);
			output.WriteValueB32(Continuous, endianess);
			output.WriteValueF32(ContinuousGravity, endianess);
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
			VelocityMax = input.ReadValueF32(endianess);
			FrictionMin = input.ReadValueF32(endianess);
			FrictionMax = input.ReadValueF32(endianess);
			Continuous = input.ReadValueB32(endianess);
			ContinuousGravity = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
