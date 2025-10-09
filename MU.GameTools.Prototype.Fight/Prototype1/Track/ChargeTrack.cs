using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Charge)]
	public class ChargeTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ChargeType Type { get; set; }

		public bool ClearOnBegin { get; set; }

		public float FinalCharge { get; set; }

		public float RandomRange { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			output.WriteValueB32(ClearOnBegin, endianess);
			output.WriteValueF32(FinalCharge, endianess);
			output.WriteValueF32(RandomRange, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Type = BaseProperty.DeserializePropertyEnum<ChargeType>(input, endianess);
			ClearOnBegin = input.ReadValueB32(endianess);
			FinalCharge = input.ReadValueF32(endianess);
			RandomRange = input.ReadValueF32(endianess);
		}
	}
}
