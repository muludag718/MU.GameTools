using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.OnlineFlagPlayerDeath)]
	public class OnlineFlagPlayerDeathTrack : P1Track
	{
		public PlayerType PlayerToTell { get; set; }

		public PlayerType PlayerThatDied { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, PlayerToTell);
			BaseProperty.SerializePropertyEnum(output, endianess, PlayerThatDied);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			PlayerToTell = BaseProperty.DeserializePropertyEnum<PlayerType>(input, endianess);
			PlayerThatDied = BaseProperty.DeserializePropertyEnum<PlayerType>(input, endianess);
		}
	}
}
