using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ButtonHintShow)]
	public class ButtonHintShowTrack : P1Track
	{
		public enum EnumPressType : ulong
		{
			TAP = 361475483139uL,
			HOLD = 20324971539363327uL,
			MASH = 21735858257907179uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public InputButton Button { get; set; }

		public EnumPressType PressType { get; set; }

		public string DisplayMessage { get; set; }

		public ulong ScenarioMessage { get; set; }

		public int Priority { get; set; }

		public bool Persistent { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Button);
			BaseProperty.SerializePropertyEnum(output, endianess, PressType);
			output.WriteStringAlignedU32(DisplayMessage, endianess);
			output.WriteValueU64(ScenarioMessage, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueB32(Persistent, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Button = BaseProperty.DeserializePropertyEnum<InputButton>(input, endianess);
			PressType = BaseProperty.DeserializePropertyEnum<EnumPressType>(input, endianess);
			DisplayMessage = input.ReadStringAlignedU32(endianess);
			ScenarioMessage = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			Persistent = input.ReadValueB32(endianess);
		}
	}
}
