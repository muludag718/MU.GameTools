using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.MagneticBootsTestWall)]
	public class MagneticBootsTestWallTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public float YawOffset { get; set; }

		public float Length { get; set; }

		public ColliderType CollideWith { get; set; }

		public bool UseFacing { get; set; }

		public bool UseBackwardsFacing { get; set; }

		public bool DebugDraw { get; set; }

		public BranchReference Branch { get; set; } = new BranchReference();

		public int Priority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			Offset.Serialize(output, endianess);
			output.WriteValueF32(YawOffset, endianess);
			output.WriteValueF32(Length, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWith);
			output.WriteValueB32(UseFacing, endianess);
			output.WriteValueB32(UseBackwardsFacing, endianess);
			output.WriteValueB32(DebugDraw, endianess);
			Branch.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Offset = new Vector(input, endianess);
			YawOffset = input.ReadValueF32(endianess);
			Length = input.ReadValueF32(endianess);
			CollideWith = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
			UseFacing = input.ReadValueB32(endianess);
			UseBackwardsFacing = input.ReadValueB32(endianess);
			DebugDraw = input.ReadValueB32(endianess);
			Branch = new BranchReference(input, endianess);
			Priority = input.ReadValueS32(endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Conditions);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Conditions = BaseProperty.DeserializeConditionProperty(PrototypeGame.P1, input, endianess, PropertyHash.Conditions);
		}
	}
}
