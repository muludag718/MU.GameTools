using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.DestinationGoTo)]
	public class DestinationGoToTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Tolerance { get; set; }

		public bool Brake { get; set; }

		public bool IgnoreRestrictions { get; set; }

		public bool StayOnGround { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Tolerance, endianess);
			output.WriteValueB32(Brake, endianess);
			output.WriteValueB32(IgnoreRestrictions, endianess);
			output.WriteValueB32(StayOnGround, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Tolerance = input.ReadValueF32(endianess);
			Brake = input.ReadValueB32(endianess);
			IgnoreRestrictions = input.ReadValueB32(endianess);
			StayOnGround = input.ReadValueB32(endianess);
		}
	}
}
