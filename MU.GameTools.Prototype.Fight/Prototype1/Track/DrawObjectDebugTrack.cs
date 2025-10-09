using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.DrawObjectDebug)]
	public class DrawObjectDebugTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public Color Colour { get; set; } = new Color();

		public Vector Offset { get; set; } = new Vector();

		public ulong AttachJoint { get; set; }

		public float Radius { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			Colour.Serialize(output, endianess);
			Offset.Serialize(output, endianess);
			output.WriteValueU64(AttachJoint, endianess);
			output.WriteValueF32(Radius, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Colour.Deserialize(input, endianess);
			Offset.Deserialize(input, endianess);
			AttachJoint = input.ReadValueU64(endianess);
			Radius = input.ReadValueF32(endianess);
		}
	}
}
