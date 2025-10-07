using MU.GameTools.Common;
using MU.GameTools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod.Prototype1
{
    [Tod("proto::ShieldPower", PrototypeGame.P1)]
    public class ShieldPower : MetaObject
    {
        public string ShieldJoint { get; set; }

        public float DeployedScale { get; set; }

        public float DeploySpeed { get; set; }

        public float RetractSpeed { get; set; }

        public float MaxHealth { get; set; }

        public float Unknown1 { get; set; }

        public float Unknown2 { get; set; }

        public float Unknown3 { get; set; }

        public float Unknown4 { get; set; }

        public string CollisionTemplate { get; set; }

        public string GameObjectTemplate { get; set; }

        public override void Serialize(Stream output, Endian endian)
        {
            output.WriteStringU32NoTerminator(ShieldJoint, endian);
            output.WriteValueF32(DeployedScale, endian);
            output.WriteValueF32(DeploySpeed, endian);
            output.WriteValueF32(RetractSpeed, endian);
            output.WriteValueF32(MaxHealth, endian);
            output.WriteValueF32(Unknown1, endian);
            output.WriteValueF32(Unknown2, endian);
            output.WriteValueF32(Unknown3, endian);
            output.WriteStringU32NoTerminator(CollisionTemplate, endian);
            output.WriteStringU32NoTerminator(GameObjectTemplate, endian);
        }

        public override void Deserialize(Stream input, Endian endian)
        {
            ShieldJoint = input.ReadString(input.ReadValueS32(endian));
            DeployedScale = input.ReadValueF32(endian);
            DeploySpeed = input.ReadValueF32(endian);
            RetractSpeed = input.ReadValueF32(endian);
            MaxHealth = input.ReadValueF32(endian);
            Unknown1 = input.ReadValueF32(endian);
            Unknown2 = input.ReadValueF32(endian);
            Unknown3 = input.ReadValueF32(endian);
            CollisionTemplate = input.ReadString(input.ReadValueS32(endian));
            GameObjectTemplate = input.ReadString(input.ReadValueS32(endian));
        }
    }

}
