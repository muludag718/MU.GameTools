using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	public class TriggerVolumeEventCondition : P1Condition
	{
		public enum TriggerCollisionType : ulong
		{
			Either = 7792769599423272283uL,
			Enter = 4872555661335756302uL,
			Exit = 19477321536111832uL
		}

		public TriggerCollisionType Type { get; set; }

		public string TriggerVolumeName { get; set; }

		public int TriggerVolumeAttributesTags { get; set; }

		public string TriggerVolumeAttributesTagsTriggerAttributeKey1 { get; set; }

		public string TriggerVolumeAttributesTagsTriggerAttributeValue1 { get; set; }

		public string TriggerVolumeAttributesTagsTriggerAttributeKey2 { get; set; }

		public string TriggerVolumeAttributesTagsTriggerAttributeValue2 { get; set; }

		public string TriggerVolumeAttributesTagsTriggerTagList { get; set; }

		public string TouchName { get; set; }

		public int TouchAttributesTags { get; set; }

		public string TouchAttributesTagsTouchAttributeKey1 { get; set; }

		public string TouchAttributesTagsTouchAttributeValue1 { get; set; }

		public string TouchAttributesTagsTouchAttributeKey2 { get; set; }

		public string TouchAttributesTagsTouchAttributeValue2 { get; set; }

		public string TouchAttributesTagsTouchTagList { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			output.WriteStringAlignedU32(TriggerVolumeName, endianess);
			output.WriteValueS32(TriggerVolumeAttributesTags, endianess);
			output.WriteStringAlignedU32(TriggerVolumeAttributesTagsTriggerAttributeKey1, endianess);
			output.WriteStringAlignedU32(TriggerVolumeAttributesTagsTriggerAttributeValue1, endianess);
			output.WriteStringAlignedU32(TriggerVolumeAttributesTagsTriggerAttributeKey2, endianess);
			output.WriteStringAlignedU32(TriggerVolumeAttributesTagsTriggerAttributeValue2, endianess);
			output.WriteStringAlignedU32(TriggerVolumeAttributesTagsTriggerTagList, endianess);
			output.WriteStringAlignedU32(TouchName, endianess);
			output.WriteValueS32(TouchAttributesTags, endianess);
			output.WriteStringAlignedU32(TouchAttributesTagsTouchAttributeKey1, endianess);
			output.WriteStringAlignedU32(TouchAttributesTagsTouchAttributeValue1, endianess);
			output.WriteStringAlignedU32(TouchAttributesTagsTouchAttributeKey2, endianess);
			output.WriteStringAlignedU32(TouchAttributesTagsTouchAttributeValue2, endianess);
			output.WriteStringAlignedU32(TouchAttributesTagsTouchTagList, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = BaseProperty.DeserializePropertyEnum<TriggerCollisionType>(input, endianess);
			TriggerVolumeName = input.ReadStringAlignedU32(endianess);
			TriggerVolumeAttributesTags = input.ReadValueS32(endianess);
			TriggerVolumeAttributesTagsTriggerAttributeKey1 = input.ReadStringAlignedU32(endianess);
			TriggerVolumeAttributesTagsTriggerAttributeValue1 = input.ReadStringAlignedU32(endianess);
			TriggerVolumeAttributesTagsTriggerAttributeKey2 = input.ReadStringAlignedU32(endianess);
			TriggerVolumeAttributesTagsTriggerAttributeValue2 = input.ReadStringAlignedU32(endianess);
			TriggerVolumeAttributesTagsTriggerTagList = input.ReadStringAlignedU32(endianess);
			TouchName = input.ReadStringAlignedU32(endianess);
			TouchAttributesTags = input.ReadValueS32(endianess);
			TouchAttributesTagsTouchAttributeKey1 = input.ReadStringAlignedU32(endianess);
			TouchAttributesTagsTouchAttributeValue1 = input.ReadStringAlignedU32(endianess);
			TouchAttributesTagsTouchAttributeKey2 = input.ReadStringAlignedU32(endianess);
			TouchAttributesTagsTouchAttributeValue2 = input.ReadStringAlignedU32(endianess);
			TouchAttributesTagsTouchTagList = input.ReadStringAlignedU32(endianess);
		}
	}
}
