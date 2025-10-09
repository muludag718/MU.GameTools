using MU.GameTools.IO;
usingMU.GameTools.Common;

namespace MU.GameTools.Prototype.Fight.Property;

public class PropertyConditionGroup : BaseProperty
{
    public List<BaseCondition> Conditions { get; set; } = new List<BaseCondition>();

    public PropertyConditionGroup()
    {
    }

    public PropertyConditionGroup(PropertyHash hash)
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
        return BaseProperty.DeserializeConditionProperty(game, stream, Endian.Little, (PropertyHash)hash);
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
        BaseCondition.SerializeBaseConditions(PrototypeGame.P1, output, endianess, Conditions);
    }

    private void P1_DeserializeProperties(Stream input, Endian endianess)
    {
        Conditions = new List<BaseCondition>();
        while (true)
        {
            ulong num = input.ReadValueU64(endianess);
            if (num == 0L)
            {
                break;
            }
            BaseCondition item = BaseCondition.DeserializeBaseCondition(PrototypeGame.P1, input, endianess, num);
            Conditions.Add(item);
        }
    }

    private void P2_SerializeProperties(Stream output, Endian endianess)
    {
        BaseCondition.SerializeBaseConditions(PrototypeGame.P2, output, endianess, Conditions);
    }

    private void P2_DeserializeProperties(Stream input, Endian endianess)
    {
        Conditions = new List<BaseCondition>();
        while (true)
        {
            ulong num = input.ReadValueU64(endianess);
            if (num == 0L)
            {
                break;
            }
            BaseCondition item = BaseCondition.DeserializeBaseCondition(PrototypeGame.P2, input, endianess, num);
            Conditions.Add(item);
        }
        input.Position -= 8L;
    }
}
