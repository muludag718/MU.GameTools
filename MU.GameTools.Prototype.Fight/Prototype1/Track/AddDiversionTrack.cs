using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.AddDiversion)]
	public class AddDiversionTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Intensity { get; set; }

		public float MinDistance { get; set; }

		public float MaxDistance { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Intensity, endianess);
			output.WriteValueF32(MinDistance, endianess);
			output.WriteValueF32(MaxDistance, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Intensity = input.ReadValueF32(endianess);
			MinDistance = input.ReadValueF32(endianess);
			MaxDistance = input.ReadValueF32(endianess);
		}
	}
}
