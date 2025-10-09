using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.AI)]
	[KnownTrack(TrackHash.Speed)]
	public class SpeedTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Speed { get; set; }

		public bool Sprint { get; set; }

		public bool UseMaxSpeed { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Speed, endianess);
			output.WriteValueB32(Sprint, endianess);
			output.WriteValueB32(UseMaxSpeed, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Speed = input.ReadValueF32(endianess);
			Sprint = input.ReadValueB32(endianess);
			UseMaxSpeed = input.ReadValueB32(endianess);
		}
	}
}
