using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.FlyingIdle)]
	public class FlyingIdleTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float MinHeight { get; set; }

		public float FreeRadius { get; set; }

		public float Tolerance { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(MinHeight, endianess);
			output.WriteValueF32(FreeRadius, endianess);
			output.WriteValueF32(Tolerance, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			MinHeight = input.ReadValueF32(endianess);
			FreeRadius = input.ReadValueF32(endianess);
			Tolerance = input.ReadValueF32(endianess);
		}
	}
}
