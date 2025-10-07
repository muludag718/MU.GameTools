using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod.Common
{
    [Tod("ContentCementFileDefinition")]
    public class ContentCementFileDefinition : MetaObject
    {
        public List<string> DefaultFiles { get; set; } = new List<string>();

        public List<string> CachedFiles { get; set; } = new List<string>();

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteValueS32(2, endian);
            output.WriteStringU32NoTerminator("default", endian);
            output.WriteValueS32(DefaultFiles.Count, endian);
            for (int i = 0; i < DefaultFiles.Count; i++)
            {
                output.WriteStringU32NoTerminator(DefaultFiles[i], endian);
            }
            output.WriteStringU32NoTerminator("cached", endian);
            output.WriteValueS32(CachedFiles.Count, endian);
            for (int j = 0; j < CachedFiles.Count; j++)
            {
                output.WriteStringU32NoTerminator(CachedFiles[j], endian);
            }
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            if (input.ReadValueS32(endian) != 2)
            {
                throw new Exception("that was unexpected");
            }
            if (input.ReadString(input.ReadValueS32(endian)) != "default")
            {
                throw new Exception("that was unexpected");
            }
            int num = input.ReadValueS32(endian);
            for (int i = 0; i < num; i++)
            {
                DefaultFiles.Add(input.ReadString(input.ReadValueS32(endian)));
            }
            if (input.ReadString(input.ReadValueS32(endian)) != "cached")
            {
                throw new Exception("that was unexpected");
            }
            num = input.ReadValueS32(endian);
            for (int j = 0; j < num; j++)
            {
                CachedFiles.Add(input.ReadString(input.ReadValueS32(endian)));
            }
        }
    }
}
