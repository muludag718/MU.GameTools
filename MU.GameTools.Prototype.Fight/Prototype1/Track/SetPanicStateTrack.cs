using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SetVehiclePanicState)]
	public class SetPanicStateTrack : P1Track
	{
		public enum PanicEnumType : ulong
		{
			Normal = 1737215327242219437uL,
			Panic = 7983194175341262185uL,
			EBrake = 10938921865974813017uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public PanicEnumType PanicType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, PanicType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			PanicType = BaseProperty.DeserializePropertyEnum<PanicEnumType>(input, endianess);
		}
	}
}
