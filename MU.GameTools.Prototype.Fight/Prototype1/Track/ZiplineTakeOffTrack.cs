using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ZiplineTakeOff)]
	public class ZiplineTakeOffTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public Vector ZiplineSpeed { get; set; } = new Vector();

		public float ZiplineTime { get; set; }

		public Vector CharacterSpeed { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			ZiplineSpeed.Serialize(output, endianess);
			output.WriteValueF32(ZiplineTime, endianess);
			CharacterSpeed.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			ZiplineSpeed.Deserialize(input, endianess);
			ZiplineTime = input.ReadValueF32(endianess);
			CharacterSpeed.Deserialize(input, endianess);
		}
	}
}
