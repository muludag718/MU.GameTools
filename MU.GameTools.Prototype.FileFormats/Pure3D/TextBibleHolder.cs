using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using MU.GameTools.Common;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
    //[KnownType(98818u)]
    [KnownGame(PrototypeGame.P1)]

    [KnownType(98818)]
    public class TextBibleHolder : BaseNode
    {
        public string Language { get; set; }

        public uint Version { get; set; }

        public uint Count { get; set; }

        public List<string> Keys { get; set; }

        public List<uint> StringStarts { get; set; }

        public List<uint> StringStops { get; set; }

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteStringAlignedU8(Language);
            output.WriteValueU32(Version, endian);
            output.WriteValueU32(Count, endian);
            for (int i = 0; i < Count; i++)
            {
                output.WriteStringAlignedU8(Keys[i]);
            }
            for (int j = 0; j < Count; j++)
            {
                output.WriteValueU32(StringStarts[j], endian);
            }
            for (int k = 0; k < Count; k++)
            {
                output.WriteValueU32(StringStops[k], endian);
            }
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            var position = input.Position;
            Language = input.ReadStringAlignedU8();
            Version = input.ReadValueU32(endian);
            Count = input.ReadValueU32(endian);
            Keys = new List<string>();
            Debug.WriteLine($"------TextBibleHolder  : {Language}-{Version}-{Count}--------");
            Debug.WriteLine("Keys : ");
            for (uint num = 0u; num < Count; num++)
            {
                var inputvalue = input.ReadStringAlignedU8();

                Keys.Add(inputvalue);
                Debug.Write(inputvalue + ",");
            }
            Debug.WriteLine("");
            Debug.WriteLine("StringStarts : ");

            StringStarts = new List<uint>();
            for (uint num2 = 0u; num2 < Count; num2++)
            {
                var inputvalue = input.ReadValueU32(endian);
                StringStarts.Add(inputvalue);
                Debug.Write(inputvalue + ",");
            }
            Debug.WriteLine("");
            Debug.WriteLine("StringStops : ");
            StringStops = new List<uint>();
            for (uint num3 = 0u; num3 < Count; num3++)
            {
                var inputvalue = input.ReadValueU32(endian);
                StringStops.Add(inputvalue);
                Debug.Write(inputvalue + ",");

            }

        }
    }
}
