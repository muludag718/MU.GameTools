using MU.GameTools.Common;
using MU.GameTools.IO;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Branch;

[KnownBranch(BranchHash.Bank)]
public class Bank : BaseBranch
{
	public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

	public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
	{
		BaseProperty.SerializeBaseProperty(game, output, endianess, Conditions);
	}

	public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
	{
		Conditions = BaseProperty.DeserializeConditionProperty(game, input, endianess, PropertyHash.Conditions);
	}
}
