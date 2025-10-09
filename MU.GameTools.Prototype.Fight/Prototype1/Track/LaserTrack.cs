using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Laser)]
	public class LaserTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Shader { get; set; }

		public float Thickness { get; set; }

		public Color Colour { get; set; } = new Color();

		public ulong MyJoint { get; set; }

		public Vector MyOffset { get; set; } = new Vector();

		public ulong TargetJoint { get; set; }

		public Vector TargetOffset { get; set; } = new Vector();

		public float TrackingSpeed { get; set; }

		public float LongitudinalOffset { get; set; }

		public float PerpendicularOffset { get; set; }

		public float PerpendicularFinalOffset { get; set; }

		public float PerpendicularFinalTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Shader, endianess);
			output.WriteValueF32(Thickness, endianess);
			Colour.Serialize(output, endianess);
			output.WriteValueU64(MyJoint, endianess);
			MyOffset.Serialize(output, endianess);
			output.WriteValueU64(TargetJoint, endianess);
			TargetOffset.Serialize(output, endianess);
			output.WriteValueF32(TrackingSpeed, endianess);
			output.WriteValueF32(LongitudinalOffset, endianess);
			output.WriteValueF32(PerpendicularOffset, endianess);
			output.WriteValueF32(PerpendicularFinalOffset, endianess);
			output.WriteValueF32(PerpendicularFinalTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Shader = input.ReadValueU64(endianess);
			Thickness = input.ReadValueF32(endianess);
			Colour.Deserialize(input, endianess);
			MyJoint = input.ReadValueU64(endianess);
			MyOffset.Deserialize(input, endianess);
			TargetJoint = input.ReadValueU64(endianess);
			TargetOffset.Deserialize(input, endianess);
			TrackingSpeed = input.ReadValueF32(endianess);
			LongitudinalOffset = input.ReadValueF32(endianess);
			PerpendicularOffset = input.ReadValueF32(endianess);
			PerpendicularFinalOffset = input.ReadValueF32(endianess);
			PerpendicularFinalTime = input.ReadValueF32(endianess);
		}
	}
}
