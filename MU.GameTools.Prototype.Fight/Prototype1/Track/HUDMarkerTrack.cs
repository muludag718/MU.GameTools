using System;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.HUDMarker)]
	public class HUDMarkerTrack : P1Track
	{
		public enum HUDIconAnimation : ulong
		{
			NONE = 22018748215728118uL,
			PULSE_SLOW = 3665480714829312421uL,
			PULSE_FAST = 3668585279254091496uL,
			INTRO = 5167983425046386766uL,
			OUTRO = 5589952664214003225uL
		}

		public enum HUDIconColor : ulong
		{
			EVENT = 4879330626040897096uL,
			OBJECTIVE = 17058728716782777749uL,
			MISSION = 4334989616241774622uL,
			OPPORTUNITY = 1370945567035357059uL,
			SCIENTIST = 5005180118806087990uL,
			META_GAME = 16428558314997069388uL,
			ZONE_INFECTED = 17595790134620054805uL,
			ZONE_MILITARY = 10616222432864268188uL,
			AWARENESS_PERCEPTION = 17801449295885656871uL,
			AWARENESS_LOW = 6576193518582633164uL,
			AWARENESS_MED_SOUND = 12045037681404148444uL,
			AWARENESS_MED = 6576193522894783440uL,
			AWARENESS_HIGH = 14607332645658772330uL,
			AWARENESS_HIGH_OUTOFSIGHT = 8428198859817923579uL,
			STRIKE_TEAM = 13141943391753985174uL,
			BASE = 18631255110497579uL,
			HIVE = 20324945720908898uL,
			MISSION_AREA = 16690139112599310638uL,
			MEDAL_NONE = 1590293401304588950uL,
			MEDAL_BRONZE = 12260960288387540uL,
			MEDAL_SILVER = 15409522211401927059uL,
			MEDAL_GOLD = 1588317879328936414uL,
			MEDAL_PLATINUM = 7872818629347817308uL,
			DESTROY = 8991619527592467022uL
		}

		[Flags]
		public enum HUDDisplayType : ulong
		{
			Mainmap = 1uL,
			Minimap = 2uL,
			Onscreen = 4uL,
			Offscreen = 8uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public MarkerType Type { get; set; }

		public HUDDisplayType DisplayType { get; set; }

		public HUDIconAnimation AnimType { get; set; }

		public HUDIconColor Color { get; set; }

		public float Radius { get; set; }

		public bool UseGrabSlot { get; set; }

		public ulong GrabSlot { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			BaseProperty.SerializePropertyBitfield(output, endianess, DisplayType);
			BaseProperty.SerializePropertyEnum(output, endianess, AnimType);
			BaseProperty.SerializePropertyEnum(output, endianess, Color);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueB32(UseGrabSlot, endianess);
			output.WriteValueU64(GrabSlot, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Type = BaseProperty.DeserializePropertyEnum<MarkerType>(input, endianess);
			DisplayType = BaseProperty.DeserializePropertyBitfield<HUDDisplayType>(input, endianess);
			AnimType = BaseProperty.DeserializePropertyEnum<HUDIconAnimation>(input, endianess);
			Color = BaseProperty.DeserializePropertyEnum<HUDIconColor>(input, endianess);
			Radius = input.ReadValueF32(endianess);
			UseGrabSlot = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
		}
	}
}
