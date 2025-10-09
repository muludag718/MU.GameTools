using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.FlyingBrake)]
	public class FlyingBrakeTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float VelocityXZ { get; set; }

		public float Gravity { get; set; }

		public float GravityUp { get; set; }

		public float TerminalVelocity { get; set; }

		public float VelocityUp { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(VelocityXZ, endianess);
			output.WriteValueF32(Gravity, endianess);
			output.WriteValueF32(GravityUp, endianess);
			output.WriteValueF32(TerminalVelocity, endianess);
			output.WriteValueF32(VelocityUp, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			VelocityXZ = input.ReadValueF32(endianess);
			Gravity = input.ReadValueF32(endianess);
			GravityUp = input.ReadValueF32(endianess);
			TerminalVelocity = input.ReadValueF32(endianess);
			VelocityUp = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
