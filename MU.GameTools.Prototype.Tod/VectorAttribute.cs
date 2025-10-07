using MU.GameTools.Common;
using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod
{
    public class VectorAttribute : MetaAttribute
    {
        public Vector3 Vector { get; set; }

        public override void Serialize(Stream output, Endian endian)
        {
            base.Serialize(output, endian);
            Vector.Serialize(output, endian);
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            base.Deserialize(input, endian);
            Vector = new Vector3(input, endian);
        }
    }
}
