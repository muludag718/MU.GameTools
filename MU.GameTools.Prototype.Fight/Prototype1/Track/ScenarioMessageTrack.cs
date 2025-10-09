using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Alert)]
	[KnownTrack(TrackHash.ScenarioMessage)]
	public class ScenarioMessageTrack : P1Track
	{
		public enum MessageType : ulong
		{
			EnterAlert = 1212611220454321848uL,
			LeaveAlert = 14301762854519847273uL,
			CallStrikeTeam = 7659658666603352665uL,
			PlayerEngaged = 9539135133961630246uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public MessageType Event { get; set; }

		public bool OnBegin { get; set; }

		public bool OnEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Event);
			output.WriteValueB32(OnBegin, endianess);
			output.WriteValueB32(OnEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Event = BaseProperty.DeserializePropertyEnum<MessageType>(input, endianess);
			OnBegin = input.ReadValueB32(endianess);
			OnEnd = input.ReadValueB32(endianess);
		}
	}
}
