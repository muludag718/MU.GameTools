using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.CameraReset)]
	public class CameraResetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public Vector Direction { get; set; } = new Vector();

		public float BlendTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			Direction.Serialize(output, endianess);
			output.WriteValueF32(BlendTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Direction = new Vector(input, endianess);
			BlendTime = input.ReadValueF32(endianess);
		}
	}
}
