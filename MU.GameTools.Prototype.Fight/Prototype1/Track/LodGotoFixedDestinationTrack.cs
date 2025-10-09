using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.LODGotoFixedDestination)]
	public class LodGotoFixedDestinationTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Speed { get; set; }

		public float VerticalSpeed { get; set; }

		public float Tolerance { get; set; }

		public float FreeArea { get; set; }

		public float MinHeight { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Speed, endianess);
			output.WriteValueF32(VerticalSpeed, endianess);
			output.WriteValueF32(Tolerance, endianess);
			output.WriteValueF32(FreeArea, endianess);
			output.WriteValueF32(MinHeight, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Speed = input.ReadValueF32(endianess);
			VerticalSpeed = input.ReadValueF32(endianess);
			Tolerance = input.ReadValueF32(endianess);
			FreeArea = input.ReadValueF32(endianess);
			MinHeight = input.ReadValueF32(endianess);
		}
	}
}
