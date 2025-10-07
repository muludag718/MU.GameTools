using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod;


public class FactionAttribute : MetaAttribute
{
    public string Faction { get; set; }

    public override void Serialize(Stream output, Endian endian)
    {
        base.Serialize(output, endian);
        output.WriteStringU32NoTerminator(Faction, endian);
    }

    public override void Deserialize(Stream input, Endian endian)
    {
        base.Deserialize(input, endian);
        Faction = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
    }
}
