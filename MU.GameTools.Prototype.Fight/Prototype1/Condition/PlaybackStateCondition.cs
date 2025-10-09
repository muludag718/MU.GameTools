using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.PlaybackState)]
	public class PlaybackStateCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public ulong State { get; set; }

		public ulong SpecificPlaybackSet { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueU64(State, endianess);
			output.WriteValueU64(SpecificPlaybackSet, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			State = input.ReadValueU64(endianess);
			SpecificPlaybackSet = input.ReadValueU64(endianess);
		}
	}
}
