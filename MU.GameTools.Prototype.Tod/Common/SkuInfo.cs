using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod.Common
{
    [Tod("engine::SkuInfo")]
    public class SkuInfo : MetaObject
    {
        public string SkuName { get; set; }

        public string SkuVersion { get; set; }

        public List<string> Languages { get; set; } = new List<string>();

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteValueS32(Languages.Count, endian);
            for (int i = 0; i < Languages.Count; i++)
            {
                output.WriteStringU32NoTerminator(Languages[i], endian);
            }
            output.WriteStringU32NoTerminator(SkuName, endian);
            output.WriteStringU32NoTerminator(SkuVersion, endian);
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            int num = input.ReadValueS32(endian);
            for (int i = 0; i < num; i++)
            {
                Languages.Add(input.ReadString(input.ReadValueS32(endian)));
            }
            SkuName = input.ReadString(input.ReadValueS32(endian));
            SkuVersion = input.ReadString(input.ReadValueS32(endian));
        }
    }
}
