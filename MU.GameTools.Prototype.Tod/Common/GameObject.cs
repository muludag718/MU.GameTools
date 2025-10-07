using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod.Common
{
    public class GameObject : MetaObject
    {
        [Browsable(false)]
        public byte[] Data { get; set; }

        [Browsable(false)]
        public override bool HasAttributeList => true;

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteValueS32(base.Attributes.Count, endian);
            foreach (MetaAttribute attribute in base.Attributes)
            {
                attribute.Serialize(output, endian);
            }
            output.WriteBytes(Data);
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            long position = input.Position;
            int num = input.ReadValueS32(endian);
            for (int i = 0; i < num; i++)
            {
                string attributeName = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
                string text = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
                MetaAttribute metaAttribute = MetaObjectFactory.CreateAttribute(text);
                if (metaAttribute == null)
                {
                    throw new FormatException("Unknown attribute: " + text);
                }
                metaAttribute.AttributeName = attributeName;
                metaAttribute.TypeName = text;
                metaAttribute.Deserialize(input, endian);
                base.Attributes.Add(metaAttribute);
            }
            long num2 = input.Position - position;
            long num3 = base.Length - num2;
            Data = input.ReadBytes((int)num3);
        }
    }
}
