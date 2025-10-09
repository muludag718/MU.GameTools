using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SetPedestrianAlertState)]
	public class SetPedestrianAlertStateTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public MessageType State { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, State);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			State = BaseProperty.DeserializePropertyEnum<MessageType>(input, endianess);
		}
	}
}
