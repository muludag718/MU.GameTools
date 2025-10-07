using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod
{
    public class UnknownMeta : MetaObject
    {
        public byte[] Data;

        [Browsable(false)]
        public uint MetaLength { get; set; }

        public UnknownMeta()
        {
        }

        public UnknownMeta(Stream input, Endian endian, uint length)
        {
            MetaLength = length;
            Deserialize(input, endian);
        }

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteBytes(Data);
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            Data = input.ReadBytes((int)MetaLength);
        }
    }
}
