using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.VariableNameSet)]
	public class VariableNameSetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong Variable { get; set; }

		public ulong Value { get; set; }

		public bool Persistent { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(Variable, endianess);
			output.WriteValueU64(Value, endianess);
			output.WriteValueB32(Persistent, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Variable = input.ReadValueU64(endianess);
			Value = input.ReadValueU64(endianess);
			Persistent = input.ReadValueB32(endianess);
		}
	}
}
