using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.RequestLostHim)]
	public class RequestLostHimCondition : P1Condition
	{
		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
		}
	}
}
