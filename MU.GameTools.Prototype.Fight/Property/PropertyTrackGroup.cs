using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.Fight.Property;

public class PropertyTrackGroup : BaseProperty
{
    public List<BaseTrack> Tracks { get; set; } = new List<BaseTrack>();

    public PropertyTrackGroup()
    {
    }

    public PropertyTrackGroup(PropertyHash hash)
        : base(hash)
    {
    }

    public override object Clone(PrototypeGame game)
    {
        Stream stream = new MemoryStream();
        BaseProperty.SerializeBaseProperty(game, stream, Endian.Little, this);
        stream.Position = 0L;
        ulong hash = stream.ReadValueU64();
        stream.Position = 0L;
        return BaseProperty.DeserializeTrackProperty(game, stream, Endian.Little, (PropertyHash)hash);
    }

    public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
    {
        switch (game)
        {
            case PrototypeGame.P1:
                P1_SerializeProperties(output, endianess);
                break;
            case PrototypeGame.P2:
                P2_SerializeProperties(output, endianess);
                break;
            default:
                throw new Exception("Non valid game");
        }
    }

    public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
    {
        switch (game)
        {
            case PrototypeGame.P1:
                P1_DeserializeProperties(input, endianess);
                break;
            case PrototypeGame.P2:
                P2_DeserializeProperties(input, endianess);
                break;
            default:
                throw new Exception("Non valid game");
        }
    }

    private void P1_SerializeProperties(Stream output, Endian endianess)
    {
        BaseTrack.SerializeBaseTracks(PrototypeGame.P1, output, endianess, Tracks);
    }

    private void P1_DeserializeProperties(Stream input, Endian endianess)
    {
        Tracks = new List<BaseTrack>();
        while (true)
        {
            ulong num = input.ReadValueU64(endianess);
            if (num != 0L)
            {
                BaseTrack item = BaseTrack.DeserializeBaseTrack(PrototypeGame.P1, input, endianess, num);
                Tracks.Add(item);
                continue;
            }
            break;
        }
    }

    private void P2_SerializeProperties(Stream output, Endian endianess)
    {
        BaseTrack.SerializeBaseTracks(PrototypeGame.P2, output, endianess, Tracks);
    }

    private void P2_DeserializeProperties(Stream input, Endian endianess)
    {
        Tracks = new List<BaseTrack>();
        while (true)
        {
            ulong num = input.ReadValueU64(endianess);
            if (num == 0L)
            {
                break;
            }
            BaseTrack item = BaseTrack.DeserializeBaseTrack(PrototypeGame.P2, input, endianess, num);
            Tracks.Add(item);
        }
        input.Position -= 8L;
    }
}
