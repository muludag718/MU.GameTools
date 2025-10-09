using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.CameraClippingPlanes)]
	public class CameraClippingPlanesTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float NearPlane { get; set; }

		public float FarPlane { get; set; }

		public bool RestoreAtEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(NearPlane, endianess);
			output.WriteValueF32(FarPlane, endianess);
			output.WriteValueB32(RestoreAtEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			NearPlane = input.ReadValueF32(endianess);
			FarPlane = input.ReadValueF32(endianess);
			RestoreAtEnd = input.ReadValueB32(endianess);
		}
	}
}
