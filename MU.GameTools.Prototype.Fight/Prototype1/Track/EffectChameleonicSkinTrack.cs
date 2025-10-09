using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.EffectChameleonicSkin)]
	public class EffectChameleonicSkinTrack : P1Track
	{
		public enum ActionEventType : ulong
		{
			Enable = 8038335290554022053uL,
			Disable = 9965250516041879004uL,
			None = 22018610510307286uL
		}

		public enum ColourEnumType : ulong
		{
			Prototype = 11199460887736065746uL,
			Infected = 13743031593724774280uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ActionEventType ActionOnBegin { get; set; }

		public ActionEventType ActionOnEnd { get; set; }

		public float WarpingFactor { get; set; }

		public float WarpOffsetScale { get; set; }

		public ColourEnumType ColourType { get; set; }

		public Color Colour { get; set; } = new Color();

		public float ColourMix { get; set; }

		public float BlurRadius { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ActionOnBegin);
			BaseProperty.SerializePropertyEnum(output, endianess, ActionOnEnd);
			output.WriteValueF32(WarpingFactor, endianess);
			output.WriteValueF32(WarpOffsetScale, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ColourType);
			Colour.Serialize(output, endianess);
			output.WriteValueF32(ColourMix, endianess);
			output.WriteValueF32(BlurRadius, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			ActionOnBegin = BaseProperty.DeserializePropertyEnum<ActionEventType>(input, endianess);
			ActionOnEnd = BaseProperty.DeserializePropertyEnum<ActionEventType>(input, endianess);
			WarpingFactor = input.ReadValueF32(endianess);
			WarpOffsetScale = input.ReadValueF32(endianess);
			ColourType = BaseProperty.DeserializePropertyEnum<ColourEnumType>(input, endianess);
			Colour.Deserialize(input, endianess);
			ColourMix = input.ReadValueF32(endianess);
			BlurRadius = input.ReadValueF32(endianess);
		}
	}
}
