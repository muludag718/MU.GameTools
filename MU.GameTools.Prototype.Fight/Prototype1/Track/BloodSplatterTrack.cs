using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.BloodSplatter)]
	public class BloodSplatterTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Shader { get; set; }

		public float Wait { get; set; }

		public float Duration { get; set; }

		public float FadeDuration { get; set; }

		public float WaitRand { get; set; }

		public float DurationRand { get; set; }

		public float FadeDurationRand { get; set; }

		public float PositionX { get; set; }

		public float PositionY { get; set; }

		public float PositionXRand { get; set; }

		public float PositionYRand { get; set; }

		public float ScaleX { get; set; }

		public float ScaleY { get; set; }

		public float ScaleXYRand { get; set; }

		public float ScaleXRand { get; set; }

		public float ScaleYRand { get; set; }

		public float Angle { get; set; }

		public float AngleRand { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Shader, endianess);
			output.WriteValueF32(Wait, endianess);
			output.WriteValueF32(Duration, endianess);
			output.WriteValueF32(FadeDuration, endianess);
			output.WriteValueF32(WaitRand, endianess);
			output.WriteValueF32(DurationRand, endianess);
			output.WriteValueF32(FadeDurationRand, endianess);
			output.WriteValueF32(PositionX, endianess);
			output.WriteValueF32(PositionY, endianess);
			output.WriteValueF32(PositionXRand, endianess);
			output.WriteValueF32(PositionYRand, endianess);
			output.WriteValueF32(ScaleX, endianess);
			output.WriteValueF32(ScaleY, endianess);
			output.WriteValueF32(ScaleXYRand, endianess);
			output.WriteValueF32(ScaleXRand, endianess);
			output.WriteValueF32(ScaleYRand, endianess);
			output.WriteValueF32(Angle, endianess);
			output.WriteValueF32(AngleRand, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Shader = input.ReadValueU64(endianess);
			Wait = input.ReadValueF32(endianess);
			Duration = input.ReadValueF32(endianess);
			FadeDuration = input.ReadValueF32(endianess);
			WaitRand = input.ReadValueF32(endianess);
			DurationRand = input.ReadValueF32(endianess);
			FadeDurationRand = input.ReadValueF32(endianess);
			PositionX = input.ReadValueF32(endianess);
			PositionY = input.ReadValueF32(endianess);
			PositionXRand = input.ReadValueF32(endianess);
			PositionYRand = input.ReadValueF32(endianess);
			ScaleX = input.ReadValueF32(endianess);
			ScaleY = input.ReadValueF32(endianess);
			ScaleXYRand = input.ReadValueF32(endianess);
			ScaleXRand = input.ReadValueF32(endianess);
			ScaleYRand = input.ReadValueF32(endianess);
			Angle = input.ReadValueF32(endianess);
			AngleRand = input.ReadValueF32(endianess);
		}
	}
}
