using MU.GameTools.Common;
using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod.Prototype1
{
    [Tod("engine::StreamPackage", PrototypeGame.P1)]
    public class StreamPackage : MetaObject
    {
        [Descriptable]
        public string SlotGroup { get; set; }

        public List<string> Prerequisite { get; set; } = new List<string>();

        public List<string> Resources { get; set; } = new List<string>();

        public List<string> Tags { get; set; } = new List<string>();

        public uint Unknown1 { get; set; }

        public uint Weight { get; set; }

        public uint XenonMemorySize { get; set; }

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteStringU32NoTerminator(SlotGroup, endian);
            string text = Utils.ListToString(Prerequisite);
            output.WriteValueS32(text.Length);
            output.WriteString(text);
            text = Utils.ListToString(Resources);
            output.WriteValueS32(text.Length);
            output.WriteString(text);
            text = Utils.ListToString(Tags);
            output.WriteValueS32(text.Length);
            output.WriteString(text);
            output.WriteValueU32(Unknown1);
            output.WriteValueU32(Weight);
            output.WriteValueU32(XenonMemorySize);
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            SlotGroup = input.ReadString(input.ReadValueS32(endian));
            Prerequisite = Utils.StringToList(input);
            Resources = Utils.StringToList(input);
            Tags = Utils.StringToList(input);
            Unknown1 = input.ReadValueU32();
            Weight = input.ReadValueU32();
            XenonMemorySize = input.ReadValueU32();
        }
    }

}
