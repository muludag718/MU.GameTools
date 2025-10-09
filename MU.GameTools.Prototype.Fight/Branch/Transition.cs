using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Branch;

[KnownNodeForContext(ContextHash.Scenario)]
[KnownBranch(BranchHash.Transition)]
public class Transition : BaseBranch
{
    public BranchReference StateRef = new BranchReference();

    public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

    public override void Serialize(Stream output, Endian endianess)
    {
        base.Serialize(output, endianess);
        StateRef.Serialize(output, endianess);
    }

    public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
    {
        BaseProperty.SerializeBaseProperty(game, output, endianess, Conditions);
    }

    public override void Deserialize(Stream input, Endian endianess)
    {
        base.Deserialize(input, endianess);
        StateRef = new BranchReference(input, endianess);
    }

    public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
    {
        Conditions = BaseProperty.DeserializeConditionProperty(game, input, endianess, PropertyHash.Conditions);
    }
}
