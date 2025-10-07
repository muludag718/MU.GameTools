using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod.Prototype2
{
    public class TransformationDescription : MetaObject
    {
        public string Name { get; set; }

        public int TransformationIndex { get; set; }

        public int UnknownInt1 { get; set; }

        public string PackageName { get; set; }

        public string ArmsCompositeDrawableName { get; set; }

        public int UnknownInt2 { get; set; }

        public string BodyTemplateName { get; set; }

        public string UnknownName1 { get; set; }

        public string PowerClassName { get; set; }

        public string Faction { get; set; }

        public float DamageMultiplier { get; set; }

        public float DamageReceived { get; set; }

        public string UnknownName2 { get; set; }

        public string UnknownName3 { get; set; }

        public string LeftArmTemplateName { get; set; }

        public string UnknownName4 { get; set; }

        public string UnknownName5 { get; set; }

        public bool IsOneHanded { get; set; }

        public int UnknownInt3 { get; set; }

        public int UnknownInt4 { get; set; }

        public string ShoulderPowerCapLeft { get; set; }

        public string ShoulderPowerCapRight { get; set; }

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteStringU32NoTerminator(Name, endian);
            output.WriteValueS32(TransformationIndex, endian);
            output.WriteValueS32(UnknownInt1, endian);
            output.WriteStringAlignedU8(PackageName);
            output.WriteStringU32NoTerminator(ArmsCompositeDrawableName, endian);
            output.WriteValueS32(UnknownInt2, endian);
            output.WriteStringU32NoTerminator(BodyTemplateName, endian);
            output.WriteStringU32NoTerminator(UnknownName1, endian);
            output.WriteStringAlignedU8(PowerClassName);
            output.WriteStringU32NoTerminator(Faction, endian);
            output.WriteValueF32(DamageMultiplier, endian);
            output.WriteValueF32(DamageReceived, endian);
            output.WriteValueB32(IsOneHanded, endian);
            output.WriteStringAlignedU8(UnknownName2);
            output.WriteStringAlignedU8(UnknownName3);
            output.WriteStringU32NoTerminator(UnknownName2, endian);
            output.WriteValueS32(UnknownInt3, endian);
            output.WriteValueS32(UnknownInt4, endian);
            output.WriteStringU32NoTerminator(ShoulderPowerCapLeft, endian);
            output.WriteStringU32NoTerminator(ShoulderPowerCapRight, endian);
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            Name = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            TransformationIndex = input.ReadValueS32(endian);
            UnknownInt1 = input.ReadValueS32(endian);
            PackageName = input.ReadStringAlignedU8();
            ArmsCompositeDrawableName = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            UnknownInt2 = input.ReadValueS32(endian);
            BodyTemplateName = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            PowerClassName = input.ReadStringAlignedU8();
            Faction = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            DamageMultiplier = input.ReadValueF32(endian);
            DamageReceived = input.ReadValueF32(endian);
            UnknownName2 = input.ReadStringAlignedU8();
            UnknownName3 = input.ReadStringAlignedU8();
            LeftArmTemplateName = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            IsOneHanded = input.ReadValueB32(endian);
            UnknownName2 = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            ShoulderPowerCapLeft = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            ShoulderPowerCapRight = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
        }
    }

}
