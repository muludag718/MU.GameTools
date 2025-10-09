using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SetPoisonCloudParameters)]
	public class SetPoisonCloudParametersTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool GrowFacingDir { get; set; }

		public bool GrowDownDir { get; set; }

		public bool InheritFacingDir { get; set; }

		public float FallToGroundSpeed { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(GrowFacingDir, endianess);
			output.WriteValueB32(GrowDownDir, endianess);
			output.WriteValueB32(InheritFacingDir, endianess);
			output.WriteValueF32(FallToGroundSpeed, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			GrowFacingDir = input.ReadValueB32(endianess);
			GrowDownDir = input.ReadValueB32(endianess);
			InheritFacingDir = input.ReadValueB32(endianess);
			FallToGroundSpeed = input.ReadValueF32(endianess);
		}
	}
}
