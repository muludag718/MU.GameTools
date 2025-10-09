using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ChargeSet)]
	public class ChargeSetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ChargeType Type { get; set; }

		public float Charge { get; set; }

		public float RandomRange { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			output.WriteValueF32(Charge, endianess);
			output.WriteValueF32(RandomRange, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Type = BaseProperty.DeserializePropertyEnum<ChargeType>(input, endianess);
			Charge = input.ReadValueF32(endianess);
			RandomRange = input.ReadValueF32(endianess);
		}
	}
}
