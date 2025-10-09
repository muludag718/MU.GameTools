using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.HeliBoundaryStatus)]
	public class HeliBoundaryStatusCondition : P1Condition
	{
		public enum HeliBoundaryType : ulong
		{
			Ok = 4909933728871709489uL,
			Warn = 18283616285219566495uL,
			Kill = 18275712200623121687uL
		}

		public HeliBoundaryType HeliBoundaryStatus { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, HeliBoundaryStatus);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			HeliBoundaryStatus = BaseProperty.DeserializePropertyEnum<HeliBoundaryType>(input, endianess);
		}
	}
}
