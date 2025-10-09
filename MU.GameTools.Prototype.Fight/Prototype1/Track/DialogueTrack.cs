using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownTrack(TrackHash.Dialogue)]
	public class DialogueTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public string CharacterName { get; set; }

		public string EventName { get; set; }

		public string PlayOn { get; set; }

		public float Frequency { get; set; }

		public float InstanceFrequencySensitivity { get; set; }

		public int MinDelay { get; set; }

		public int MaxDelay { get; set; }

		public bool KillOnExit { get; set; }

		public bool IfPlayerCanBeSeen { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteStringAlignedU32(CharacterName, endianess);
			output.WriteStringAlignedU32(EventName, endianess);
			output.WriteStringAlignedU32(PlayOn, endianess);
			output.WriteValueF32(Frequency, endianess);
			output.WriteValueF32(InstanceFrequencySensitivity, endianess);
			output.WriteValueS32(MinDelay, endianess);
			output.WriteValueS32(MaxDelay, endianess);
			output.WriteValueB32(KillOnExit, endianess);
			output.WriteValueB32(IfPlayerCanBeSeen, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			CharacterName = input.ReadStringAlignedU32(endianess);
			EventName = input.ReadStringAlignedU32(endianess);
			PlayOn = input.ReadStringAlignedU32(endianess);
			Frequency = input.ReadValueF32(endianess);
			InstanceFrequencySensitivity = input.ReadValueF32(endianess);
			MinDelay = input.ReadValueS32(endianess);
			MaxDelay = input.ReadValueS32(endianess);
			KillOnExit = input.ReadValueB32(endianess);
			IfPlayerCanBeSeen = input.ReadValueB32(endianess);
		}
	}
}
