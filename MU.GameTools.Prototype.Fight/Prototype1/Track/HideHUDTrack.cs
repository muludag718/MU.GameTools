using System;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.HideHUD)]
	public class HideHUDTrack : P1Track
	{
		[Flags]
		public enum HUDElement : ulong
		{
			MINIMAP = 1uL,
			HEALTH = 2uL,
			POWERS = 4uL,
			POPUP = 8uL,
			DISGUISE_PERCEPTION = 0x10uL,
			BUTTON_HINT = 0x20uL,
			TARGETING = 0x40uL,
			EVOLUTION_POINTS = 0x80uL,
			METER = 0x100uL,
			TEXTLOG = 0x200uL,
			VEHICLE_HEALTH = 0x400uL,
			MARKERS = 0x800uL,
			KEYCARD = 0x1000uL,
			DISGUISE_ACTIONS = 0x2000uL,
			AWARENESS = 0x4000uL,
			CCR = 0x8000uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public int HideIndividualElements { get; set; }

		public HUDElement HideIndividualElementsHideElements { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueS32(HideIndividualElements, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, HideIndividualElementsHideElements);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			HideIndividualElements = input.ReadValueS32(endianess);
			HideIndividualElementsHideElements = BaseProperty.DeserializePropertyBitfield<HUDElement>(input, endianess);
		}
	}
}
