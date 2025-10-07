using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod
{
    public class PoseAttribute : MetaAttribute
    {
        public bool Unknown { get; set; }

        public override void Serialize(Stream output, Endian endian)
        {
            base.Serialize(output, endian);
            output.WriteValueB8(Unknown);
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            base.Deserialize(input, endian);
            Unknown = input.ReadValueB8();
        }
    }

}
