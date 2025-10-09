using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.DumbGotoLOD)]
	public class DumbGotoLODTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Tolerance { get; set; }

		public float BrakingDistance { get; set; }

		public bool ClearDestination { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Tolerance, endianess);
			output.WriteValueF32(BrakingDistance, endianess);
			output.WriteValueB32(ClearDestination, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Tolerance = input.ReadValueF32(endianess);
			BrakingDistance = input.ReadValueF32(endianess);
			ClearDestination = input.ReadValueB32(endianess);
		}
	}
}
