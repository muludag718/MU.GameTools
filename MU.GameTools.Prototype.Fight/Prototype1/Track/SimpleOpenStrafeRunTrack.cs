using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SimpleOpenStrafeRun)]
	public class SimpleOpenStrafeRunTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float FreeRadiusPath { get; set; }

		public float FreeRadiusPathToStart { get; set; }

		public float MinHeightStartFromTarget { get; set; }

		public float MinHeightGoUpStart { get; set; }

		public float ReserveVolumeMargin { get; set; }

		public float ReserveVolumeSideRadius { get; set; }

		public float ToleranceToStart { get; set; }

		public bool OrientAtEnd { get; set; }

		public Vector SpeedFactor { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(FreeRadiusPath, endianess);
			output.WriteValueF32(FreeRadiusPathToStart, endianess);
			output.WriteValueF32(MinHeightStartFromTarget, endianess);
			output.WriteValueF32(MinHeightGoUpStart, endianess);
			output.WriteValueF32(ReserveVolumeMargin, endianess);
			output.WriteValueF32(ReserveVolumeSideRadius, endianess);
			output.WriteValueF32(ToleranceToStart, endianess);
			output.WriteValueB32(OrientAtEnd, endianess);
			SpeedFactor.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			FreeRadiusPath = input.ReadValueF32(endianess);
			FreeRadiusPathToStart = input.ReadValueF32(endianess);
			MinHeightStartFromTarget = input.ReadValueF32(endianess);
			MinHeightGoUpStart = input.ReadValueF32(endianess);
			ReserveVolumeMargin = input.ReadValueF32(endianess);
			ReserveVolumeSideRadius = input.ReadValueF32(endianess);
			ToleranceToStart = input.ReadValueF32(endianess);
			OrientAtEnd = input.ReadValueB32(endianess);
			SpeedFactor.Deserialize(input, endianess);
		}
	}
}
