using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SoundZone)]
	public class SoundZoneTrack : P1Track
	{
		public enum BoundaryActionType : ulong
		{
			ZoneEnter = 3205891085038241972uL,
			ZoneExit = 12785862139907654626uL
		}

		public ulong ZoneName { get; set; }

		public ulong Reverb { get; set; }

		public ulong Ambience { get; set; }

		public ulong Mix { get; set; }

		public BoundaryActionType BoundaryAction { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(ZoneName, endianess);
			output.WriteValueU64(Reverb, endianess);
			output.WriteValueU64(Ambience, endianess);
			output.WriteValueU64(Mix, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, BoundaryAction);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ZoneName = input.ReadValueU64(endianess);
			Reverb = input.ReadValueU64(endianess);
			Ambience = input.ReadValueU64(endianess);
			Mix = input.ReadValueU64(endianess);
			BoundaryAction = BaseProperty.DeserializePropertyEnum<BoundaryActionType>(input, endianess);
		}
	}
}
