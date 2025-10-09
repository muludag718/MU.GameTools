using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Deform)]
	public class DeformTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong Joint { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public Vector Direction { get; set; } = new Vector();

		public float Radius { get; set; }

		public float BlendTime { get; set; }

		public float DeformDirStr { get; set; }

		public float Strength { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(Joint, endianess);
			Offset.Serialize(output, endianess);
			Direction.Serialize(output, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueF32(BlendTime, endianess);
			output.WriteValueF32(DeformDirStr, endianess);
			output.WriteValueF32(Strength, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Joint = input.ReadValueU64(endianess);
			Offset.Deserialize(input, endianess);
			Direction.Deserialize(input, endianess);
			Radius = input.ReadValueF32(endianess);
			BlendTime = input.ReadValueF32(endianess);
			DeformDirStr = input.ReadValueF32(endianess);
			Strength = input.ReadValueF32(endianess);
		}
	}
}
