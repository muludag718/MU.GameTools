using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.Debug)]
	public class DebugCondition : P1Condition
	{
		public enum ReleaseModeType : ulong
		{
			Debug = 14087970539477689809uL,
			Tune = 11779051480164391926uL,
			Release = 15988309783157748103uL
		}

		public CompareOperator Compare { get; set; }

		public ReleaseModeType Mode { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			BaseProperty.SerializePropertyEnum(output, endianess, Mode);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Mode = BaseProperty.DeserializePropertyEnum<ReleaseModeType>(input, endianess);
		}
	}
}
