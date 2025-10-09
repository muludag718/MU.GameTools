using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.GrabButtonStruggle)]
	public class GrabButtonStruggleTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float TimeInput { get; set; }

		public ulong GrabSlot { get; set; }

		public float InitialCharge { get; set; }

		public float AutoChargeRateMin { get; set; }

		public float AutoChargeRateMax { get; set; }

		public float ButtonChargeRate { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(TimeInput, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueF32(InitialCharge, endianess);
			output.WriteValueF32(AutoChargeRateMin, endianess);
			output.WriteValueF32(AutoChargeRateMax, endianess);
			output.WriteValueF32(ButtonChargeRate, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			TimeInput = input.ReadValueF32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			InitialCharge = input.ReadValueF32(endianess);
			AutoChargeRateMin = input.ReadValueF32(endianess);
			AutoChargeRateMax = input.ReadValueF32(endianess);
			ButtonChargeRate = input.ReadValueF32(endianess);
		}
	}
}
