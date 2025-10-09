using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.DisguiseActionUsed)]
	public class DisguiseActionUsedTrack : P1Track
	{
		public enum DisguiseActionType : ulong
		{
			Patsy = 5692038329941528275uL,
			AirStrike = 10337102137488492662uL,
			CallStrikeTeam = 3853207631728303317uL
		}

		public DisguiseActionType Action { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Action);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Action = BaseProperty.DeserializePropertyEnum<DisguiseActionType>(input, endianess);
		}
	}
}
