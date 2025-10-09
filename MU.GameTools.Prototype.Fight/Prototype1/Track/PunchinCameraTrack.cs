using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownTrack(TrackHash.PunchinCamera)]
	public class PunchinCameraTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float InTime { get; set; }

		public float OutTime { get; set; }

		public float Dolly { get; set; }

		public float Zoom { get; set; }

		public bool ReAim { get; set; }

		public float VectorX { get; set; }

		public float VectorY { get; set; }

		public float VectorZ { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(InTime, endianess);
			output.WriteValueF32(OutTime, endianess);
			output.WriteValueF32(Dolly, endianess);
			output.WriteValueF32(Zoom, endianess);
			output.WriteValueB32(ReAim, endianess);
			output.WriteValueF32(VectorX, endianess);
			output.WriteValueF32(VectorY, endianess);
			output.WriteValueF32(VectorZ, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			InTime = input.ReadValueF32(endianess);
			OutTime = input.ReadValueF32(endianess);
			Dolly = input.ReadValueF32(endianess);
			Zoom = input.ReadValueF32(endianess);
			ReAim = input.ReadValueB32(endianess);
			VectorX = input.ReadValueF32(endianess);
			VectorY = input.ReadValueF32(endianess);
			VectorZ = input.ReadValueF32(endianess);
		}
	}
}
