using MU.GameTools.IO;

namespace MU.GameTools.Common;


public interface ISerializable
{
    void Serialize(Stream output, Endian endian);

    void Deserialize(Stream input, Endian endian);
}
