using MU.GameTools.IO;
using MU.GameTools.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod.Prototype1
{
    public class UnlockableInfo : ISerializable
    {
        public Unlockable Unlockable { get; set; }

        public string HudCode { get; set; }

        public int Unknown1 { get; set; }

        public int Cost { get; set; }

        public string Mission { get; set; }

        public Unlockable Requirement { get; set; }

        public bool IsCore { get; set; }

        public UnlockableInfo()
        {
        }

        public UnlockableInfo(Stream input, Endian endian)
        {
            Deserialize(input, endian);
        }

        public void Serialize(Stream output, Endian endian)
        {
            output.WriteValueS32((int)(Unlockable + 1), endian);
            output.WriteStringU32NoTerminator(HudCode, endian);
            output.WriteValueS32(Unknown1, endian);
            output.WriteValueS32(Cost, endian);
            output.WriteStringU32NoTerminator(Mission, endian);
            output.WriteValueS32((int)(Requirement + 1), endian);
            output.WriteValueB32(IsCore, endian);
        }

        public void Deserialize(Stream input, Endian endian)
        {
            Unlockable = (Unlockable)(input.ReadValueS32(endian) - 1);
            HudCode = input.ReadString(input.ReadValueS32(endian));
            Unknown1 = input.ReadValueS32(endian);
            Cost = input.ReadValueS32(endian);
            Mission = input.ReadString(input.ReadValueS32(endian));
            Requirement = (Unlockable)(input.ReadValueS32(endian) - 1);
            IsCore = input.ReadValueB32(endian);
        }
    }
}
