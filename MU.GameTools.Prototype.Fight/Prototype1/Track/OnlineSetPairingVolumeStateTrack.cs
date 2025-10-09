using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.OnlineSetPairingVolumeState)]
	public class OnlineSetPairingVolumeStateTrack : P1Track
	{
		public enum OnlineVolumeType : ulong
		{
			Inner = 5158950044111431452uL
		}

		public OnlineVolumeType VolumeType { get; set; }

		public bool InVolume { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, VolumeType);
			output.WriteValueB32(InVolume, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			VolumeType = BaseProperty.DeserializePropertyEnum<OnlineVolumeType>(input, endianess);
			InVolume = input.ReadValueB32(endianess);
		}
	}
}
