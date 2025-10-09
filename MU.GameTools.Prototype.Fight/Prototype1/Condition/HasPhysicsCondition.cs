using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.HasPhysics)]
	public class HasPhysicsCondition : P1Condition
	{
		public enum InContextType : ulong
		{
			Yes = 382980737677uL,
			No = 5116765uL,
			DontCare = 8061513285755875840uL
		}

		public enum EnabledCollisionObjectsType : ulong
		{
			All = 279702787393uL,
			None = 22018610510307286uL,
			AtLeastOne = 16128247779282615688uL,
			DontCare = 8061513285755875840uL
		}

		public bool ValidPhysicsObject { get; set; }

		public InContextType InContext { get; set; }

		public EnabledCollisionObjectsType EnabledCollisionObjects { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(ValidPhysicsObject, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, InContext);
			BaseProperty.SerializePropertyEnum(output, endianess, EnabledCollisionObjects);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ValidPhysicsObject = input.ReadValueB32(endianess);
			InContext = BaseProperty.DeserializePropertyEnum<InContextType>(input, endianess);
			EnabledCollisionObjects = BaseProperty.DeserializePropertyEnum<EnabledCollisionObjectsType>(input, endianess);
		}
	}
}
