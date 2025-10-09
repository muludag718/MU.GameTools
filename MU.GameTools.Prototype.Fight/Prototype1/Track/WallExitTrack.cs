using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WallExit)]
	public class WallExitTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong SupportingLimb { get; set; }

		public float VelocityMin { get; set; }

		public float VelocityMax { get; set; }

		public float Gravity { get; set; }

		public float WallAngleUp { get; set; }

		public float WallAngleLateral { get; set; }

		public float WallAngleDown { get; set; }

		public float TurningVelocity { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(SupportingLimb, endianess);
			output.WriteValueF32(VelocityMin, endianess);
			output.WriteValueF32(VelocityMax, endianess);
			output.WriteValueF32(Gravity, endianess);
			output.WriteValueF32(WallAngleUp, endianess);
			output.WriteValueF32(WallAngleLateral, endianess);
			output.WriteValueF32(WallAngleDown, endianess);
			output.WriteValueF32(TurningVelocity, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			SupportingLimb = input.ReadValueU64(endianess);
			VelocityMin = input.ReadValueF32(endianess);
			VelocityMax = input.ReadValueF32(endianess);
			Gravity = input.ReadValueF32(endianess);
			WallAngleUp = input.ReadValueF32(endianess);
			WallAngleLateral = input.ReadValueF32(endianess);
			WallAngleDown = input.ReadValueF32(endianess);
			TurningVelocity = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
