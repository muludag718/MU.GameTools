using MU.GameTools.Common;
using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod.Prototype1
{
    [Tod("proto::UnlockablesList", PrototypeGame.P1)]
    public class UnlockablesList : MetaObject
    {
        public UnlockableType UnlockableType { get; set; }

        public List<UnlockableInfo> UnlockableList { get; set; } = new List<UnlockableInfo>();

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteValueS32((int)UnlockableType, endian);
            output.WriteValueS32(UnlockableList.Count, endian);
            for (int i = 0; i < UnlockableList.Count; i++)
            {
                UnlockableList[i].Serialize(output, endian);
            }
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            UnlockableType = (UnlockableType)input.ReadValueS32(endian);
            int num = input.ReadValueS32(endian);
            for (int i = 0; i < num; i++)
            {
                UnlockableList.Add(new UnlockableInfo(input, endian));
            }
        }
    }
}
