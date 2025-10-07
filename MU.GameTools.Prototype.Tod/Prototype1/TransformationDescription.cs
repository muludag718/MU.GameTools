using MU.GameTools.Common;
using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod.Prototype1
{

    [Tod("proto::TransformationDescription", PrototypeGame.P1)]
    public class TransformationDescription : MetaObject
    {
        public string Name { get; set; }

        public string PackageName { get; set; }

        public string ArmsCompositeDrawableName { get; set; }

        public string BodyTemplateName { get; set; }

        public string UnknownName { get; set; }

        public string UnknownName2 { get; set; }

        public string PhysicsFactoryName { get; set; }

        public string SupportingLimbName { get; set; }

        public string PowerName { get; set; }

        public string Faction { get; set; }

        public float DamageMultiplier { get; set; }

        public float DamageReceived { get; set; }

        public float DamageToAttacker { get; set; }

        public int TransformationIndex { get; set; }

        public string LeftArmTemplateName { get; set; }

        public bool IsOneHanded { get; set; }

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteStringU32NoTerminator(Name, endian);
            output.WriteStringAlignedU8(PackageName);
            output.WriteStringU32NoTerminator(ArmsCompositeDrawableName, endian);
            output.WriteStringU32NoTerminator(BodyTemplateName, endian);
            output.WriteStringU32NoTerminator(UnknownName, endian);
            output.WriteStringAlignedU8(UnknownName2);
            output.WriteStringAlignedU8(PhysicsFactoryName);
            output.WriteStringAlignedU8(SupportingLimbName);
            output.WriteStringAlignedU8(PowerName);
            output.WriteStringU32NoTerminator(Faction, endian);
            output.WriteValueF32(DamageMultiplier, endian);
            output.WriteValueF32(DamageReceived, endian);
            output.WriteValueF32(DamageToAttacker, endian);
            output.WriteValueS32(TransformationIndex, endian);
            output.WriteStringU32NoTerminator(LeftArmTemplateName, endian);
            output.WriteValueB32(IsOneHanded, endian);
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            Name = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            PackageName = input.ReadStringAlignedU8();
            ArmsCompositeDrawableName = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            BodyTemplateName = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            UnknownName = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            UnknownName2 = input.ReadStringAlignedU8();
            PhysicsFactoryName = input.ReadStringAlignedU8();
            SupportingLimbName = input.ReadStringAlignedU8();
            PowerName = input.ReadStringAlignedU8();
            Faction = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            DamageMultiplier = input.ReadValueF32(endian);
            DamageReceived = input.ReadValueF32(endian);
            DamageToAttacker = input.ReadValueF32(endian);
            TransformationIndex = input.ReadValueS32(endian);
            LeftArmTemplateName = input.ReadString(input.ReadValueS32(endian), trailingNull: false);
            IsOneHanded = input.ReadValueB32(endian);
        }
    }
}
