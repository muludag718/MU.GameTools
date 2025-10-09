using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.CharacterCloudState)]
	public class CharacterCloudStateCondition : P1Condition
	{
		public bool Match { get; set; }

		public CloudStateType State { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Match, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, State);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Match = input.ReadValueB32(endianess);
			State = BaseProperty.DeserializePropertyEnum<CloudStateType>(input, endianess);
		}
	}
}
