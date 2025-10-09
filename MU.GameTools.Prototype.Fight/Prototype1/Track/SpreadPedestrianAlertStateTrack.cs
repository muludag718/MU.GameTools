using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SpreadPedestrianAlertState)]
	public class SpreadPedestrianAlertStateTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public MessageType State { get; set; }

		public float Radius { get; set; }

		public float MaxDistanceFromSource { get; set; }

		public int MaxPasses { get; set; }

		public int AlertFrequency { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, State);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueF32(MaxDistanceFromSource, endianess);
			output.WriteValueS32(MaxPasses, endianess);
			output.WriteValueS32(AlertFrequency, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			State = BaseProperty.DeserializePropertyEnum<MessageType>(input, endianess);
			Radius = input.ReadValueF32(endianess);
			MaxDistanceFromSource = input.ReadValueF32(endianess);
			MaxPasses = input.ReadValueS32(endianess);
			AlertFrequency = input.ReadValueS32(endianess);
		}
	}
}
