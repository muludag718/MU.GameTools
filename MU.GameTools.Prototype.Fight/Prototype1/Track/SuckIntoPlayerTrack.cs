using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SuckIntoPlayer)]
	public class SuckIntoPlayerTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float InitialVelocity { get; set; }

		public float MaxVelocity { get; set; }

		public float Acceleration { get; set; }

		public float FadeDistStart { get; set; }

		public float ScaleDistStart { get; set; }

		public float ScaleEnd { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public BranchReference WhenFinished { get; set; } = new BranchReference();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(InitialVelocity, endianess);
			output.WriteValueF32(MaxVelocity, endianess);
			output.WriteValueF32(Acceleration, endianess);
			output.WriteValueF32(FadeDistStart, endianess);
			output.WriteValueF32(ScaleDistStart, endianess);
			output.WriteValueF32(ScaleEnd, endianess);
			Offset.Serialize(output, endianess);
			WhenFinished.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			InitialVelocity = input.ReadValueF32(endianess);
			MaxVelocity = input.ReadValueF32(endianess);
			Acceleration = input.ReadValueF32(endianess);
			FadeDistStart = input.ReadValueF32(endianess);
			ScaleDistStart = input.ReadValueF32(endianess);
			ScaleEnd = input.ReadValueF32(endianess);
			Offset.Deserialize(input, endianess);
			WhenFinished.Deserialize(input, endianess);
		}
	}
}
