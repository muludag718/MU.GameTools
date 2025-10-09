using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.DebugSphere)]
	public class DebugSphereTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Radius { get; set; }

		public ulong Joint { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public Color Colour { get; set; } = new Color();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueU64(Joint, endianess);
			Offset.Serialize(output, endianess);
			Colour.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Radius = input.ReadValueF32(endianess);
			Joint = input.ReadValueU64(endianess);
			Offset.Deserialize(input, endianess);
			Colour.Deserialize(input, endianess);
		}
	}
}
