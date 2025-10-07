using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod;

public abstract class MetaObject
{
    [Browsable(false)]
    public uint Length { get; set; }

    public List<MetaAttribute> Attributes { get; set; } = new List<MetaAttribute>();

    [Browsable(false)]
    public virtual bool HasAttributeList => false;

    public virtual void Serialize(Stream output, Endian endian)
    {
    }

    public virtual void Deserialize(Stream input, Endian endian)
    {
    }
}
