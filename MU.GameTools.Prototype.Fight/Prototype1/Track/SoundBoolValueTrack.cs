using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SoundBoolValue)]
	public class SoundBoolValueTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong Patch { get; set; }

		public ulong Control { get; set; }

		public bool Value { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(Patch, endianess);
			output.WriteValueU64(Control, endianess);
			output.WriteValueB32(Value, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Patch = input.ReadValueU64(endianess);
			Control = input.ReadValueU64(endianess);
			Value = input.ReadValueB32(endianess);
		}
	}
}
