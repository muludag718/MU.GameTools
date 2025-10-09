using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Branch;

[KnownNodeForContext(ContextHash.Scenario)]
[KnownBranch(BranchHash.StateMachine)]
public class StateMachine : BaseBranch
{
    public BaseProperty InitialTracks { get; set; } = new PropertyTrackGroup(PropertyHash.InitialTracks);

    public BaseProperty Functions { get; set; } = new PropertyTrackGroup(PropertyHash.Functions);

    public BaseProperty ExitTracks { get; set; } = new PropertyTrackGroup(PropertyHash.ExitTracks);

    public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
    {
        BaseProperty.SerializeBaseProperty(game, output, endianess, InitialTracks);
        BaseProperty.SerializeBaseProperty(game, output, endianess, Functions);
        BaseProperty.SerializeBaseProperty(game, output, endianess, ExitTracks);
    }

    public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
    {
        InitialTracks = BaseProperty.DeserializeTrackProperty(game, input, endianess, PropertyHash.InitialTracks);
        Functions = BaseProperty.DeserializeTrackProperty(game, input, endianess, PropertyHash.Functions);
        ExitTracks = BaseProperty.DeserializeTrackProperty(game, input, endianess, PropertyHash.ExitTracks);
    }
}
