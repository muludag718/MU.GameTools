using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Branch;

[KnownNodeForContext(ContextHash.Scenario)]
[KnownNodeForContext(ContextHash.Motion)]
[KnownBranch(BranchHash.PlaybackSet)]
public class PlaybackSet : BaseBranch
{
    public ulong LogicTreeName { get; set; }

    public override void Serialize(Stream output, Endian endianess)
    {
        base.Serialize(output, endianess);
        output.WriteValueU64(LogicTreeName, endianess);
    }

    public override void Deserialize(Stream input, Endian endianess)
    {
        base.Deserialize(input, endianess);
        LogicTreeName = input.ReadValueU64(endianess);
    }
}
