using MU.GameTools.Common;
using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod.Prototype1
{
    [Tod("proto::WhipFistPower", PrototypeGame.P1)]
    public class WhipFistPower : MetaObject
    {
        public int UnknownInt1 { get; set; }

        public float UnknownFloat1 { get; set; }

        public string WhipfistSegment { get; set; }

        public string UnknownJoint1 { get; set; }

        public string UnknownJoint2 { get; set; }

        public string WhipfistEnd { get; set; }

        public float UnknownFloat2 { get; set; }

        public float UnknownFloat3 { get; set; }

        public float UnknownFloat4 { get; set; }

        public int UnknownInt2 { get; set; }

        public int UnknownInt3 { get; set; }

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteValueS32(UnknownInt1, endian);
            output.WriteValueF32(UnknownFloat1, endian);
            output.WriteStringAlignedU8(WhipfistSegment);
            output.WriteStringU32NoTerminator(UnknownJoint1, endian);
            output.WriteStringU32NoTerminator(UnknownJoint2, endian);
            output.WriteStringU32NoTerminator(WhipfistEnd, endian);
            output.WriteValueF32(UnknownFloat2, endian);
            output.WriteValueF32(UnknownFloat3, endian);
            output.WriteValueF32(UnknownFloat4, endian);
            output.WriteValueS32(UnknownInt2, endian);
            output.WriteValueS32(UnknownInt3, endian);
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            UnknownInt1 = input.ReadValueS32(endian);
            UnknownFloat1 = input.ReadValueF32(endian);
            WhipfistSegment = input.ReadStringAlignedU8();
            UnknownJoint1 = input.ReadString(input.ReadValueS32(endian));
            UnknownJoint2 = input.ReadString(input.ReadValueS32(endian));
            WhipfistEnd = input.ReadString(input.ReadValueS32(endian));
            UnknownFloat2 = input.ReadValueF32(endian);
            UnknownFloat3 = input.ReadValueF32(endian);
            UnknownFloat4 = input.ReadValueF32(endian);
            UnknownInt2 = input.ReadValueS32(endian);
            UnknownInt3 = input.ReadValueS32(endian);
        }
    }

}
