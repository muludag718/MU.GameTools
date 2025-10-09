using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Blind)]
	public class BlindTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public TakerGiverType Taker { get; set; }

		public bool Blind { get; set; }

		public ulong GrabSlot { get; set; }

		public bool UndoOnEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Taker);
			output.WriteValueB32(Blind, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueB32(UndoOnEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Taker = BaseProperty.DeserializePropertyEnum<TakerGiverType>(input, endianess);
			Blind = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			UndoOnEnd = input.ReadValueB32(endianess);
		}
	}
}
