using MU.GameTools.Common;
using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod.Prototype2
{
    [Tod("engine::StreamPackage", PrototypeGame.P2)]
    public class StreamPackage : MetaObject
    {
        public string SlotGroup { get; set; }

        public List<string> Dependencies { get; set; } = new List<string>();

        public List<string> Packages { get; set; } = new List<string>();

        public List<string> Tags { get; set; } = new List<string>();

        public string UnknownString { get; set; }

        public uint Unknown1 { get; set; }

        public uint Unknown2 { get; set; }

        public uint XenonMemorySize { get; set; }

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteStringU32NoTerminator(SlotGroup, endian);
            string text = Utils.ListToString(Dependencies);
            output.WriteValueS32(text.Length);
            output.WriteString(text);
            text = Utils.ListToString(Packages);
            output.WriteValueS32(text.Length);
            output.WriteString(text);
            text = Utils.ListToString(Tags);
            output.WriteValueS32(text.Length);
            output.WriteString(text);
            output.WriteStringU32NoTerminator(UnknownString, endian);
            output.WriteValueU32(Unknown1);
            output.WriteValueU32(Unknown2);
            output.WriteValueU32(XenonMemorySize);
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            SlotGroup = input.ReadString(input.ReadValueS32(endian));
            Dependencies = Utils.StringToList(input);
            Packages = Utils.StringToList(input);
            Tags = Utils.StringToList(input);
            UnknownString = input.ReadString(input.ReadValueS32(endian));
            Unknown1 = input.ReadValueU32();
            Unknown2 = input.ReadValueU32();
            XenonMemorySize = input.ReadValueU32();
        }
    }
}
