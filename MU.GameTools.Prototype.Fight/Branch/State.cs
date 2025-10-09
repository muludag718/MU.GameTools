using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Branch;

[KnownNodeForContext(ContextHash.Scenario)]
[KnownBranch(BranchHash.State)]
public class State : BaseBranch
{
    public enum StateTypeHash : ulong
    {
        Default = 0uL,
        Complete = 14580388344362222301uL,
        Failed = 10329798022809230167uL
    }

    public PropertyTrackGroup EnterTracks { get; set; } = new PropertyTrackGroup(PropertyHash.EnterTracks);

    public PropertyTrackGroup ExitTracks { get; set; } = new PropertyTrackGroup(PropertyHash.ExitTracks);

    public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
    {
        BaseProperty.SerializeBaseProperty(game, output, endianess, EnterTracks);
        BaseProperty.SerializeBaseProperty(game, output, endianess, ExitTracks);
    }

    public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
    {
        EnterTracks = BaseProperty.DeserializeTrackProperty(game, input, endianess, PropertyHash.EnterTracks);
        ExitTracks = BaseProperty.DeserializeTrackProperty(game, input, endianess, PropertyHash.ExitTracks);
    }
}
