using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.AIPeriodicMessage)]
	public class AIPeriodicMessageTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public MessageType Type { get; set; }

		public float Intensity { get; set; }

		public TakerGiverType Taker { get; set; }

		public TakerGiverType Giver { get; set; }

		public bool UseOriginator { get; set; }

		public float Period { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			output.WriteValueF32(Intensity, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Taker);
			BaseProperty.SerializePropertyEnum(output, endianess, Giver);
			output.WriteValueB32(UseOriginator, endianess);
			output.WriteValueF32(Period, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Type = BaseProperty.DeserializePropertyEnum<MessageType>(input, endianess);
			Intensity = input.ReadValueF32(endianess);
			Taker = BaseProperty.DeserializePropertyEnum<TakerGiverType>(input, endianess);
			Giver = BaseProperty.DeserializePropertyEnum<TakerGiverType>(input, endianess);
			UseOriginator = input.ReadValueB32(endianess);
			Period = input.ReadValueF32(endianess);
		}
	}
}
