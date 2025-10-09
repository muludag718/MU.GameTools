using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Branch;

[KnownNodeForContext(ContextHash.Motion)]
[KnownNodeForContext(ContextHash.Scenario)]
[KnownBranch(BranchHash.Node)]
public class NodeBranch : BaseBranch
{
    public bool Override { get; set; }

    public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

    public PropertyTrackGroup Tracks { get; set; } = new PropertyTrackGroup(PropertyHash.Tracks);

    public override void Serialize(Stream output, Endian endianess)
    {
        base.Serialize(output, endianess);
        output.WriteValueB32(Override, endianess);
    }

    public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
    {
        BaseProperty.SerializeBaseProperty(game, output, endianess, Conditions);
        BaseProperty.SerializeBaseProperty(game, output, endianess, Tracks);
    }

    public override void Deserialize(Stream input, Endian endianess)
    {
        base.Deserialize(input, endianess);
        Override = input.ReadValueB32(endianess);
    }

    public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
    {
        Conditions = BaseProperty.DeserializeConditionProperty(game, input, endianess, PropertyHash.Conditions);
        Tracks = BaseProperty.DeserializeTrackProperty(game, input, endianess, PropertyHash.Tracks);
    }
}
