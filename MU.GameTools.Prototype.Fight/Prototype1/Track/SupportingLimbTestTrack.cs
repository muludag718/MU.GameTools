using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.SupportingLimbTest)]
	public class SupportingLimbTestTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong SupportingLimb { get; set; }

		public Vector Direction { get; set; } = new Vector();

		public Vector Offset { get; set; } = new Vector();

		public float Radius { get; set; }

		public float Arc { get; set; }

		public float ExtraDistance { get; set; }

		public bool UseInput { get; set; }

		public float MaxInputArc { get; set; }

		public bool UsePreviousSurface { get; set; }

		public bool UseMotion { get; set; }

		public bool SwitchSurfaces { get; set; }

		public BranchReference Branch { get; set; } = new BranchReference();

		public int Priority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(SupportingLimb, endianess);
			Direction.Serialize(output, endianess);
			Offset.Serialize(output, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueF32(Arc, endianess);
			output.WriteValueF32(ExtraDistance, endianess);
			output.WriteValueB32(UseInput, endianess);
			output.WriteValueF32(MaxInputArc, endianess);
			output.WriteValueB32(UsePreviousSurface, endianess);
			output.WriteValueB32(UseMotion, endianess);
			output.WriteValueB32(SwitchSurfaces, endianess);
			Branch.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Conditions);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			SupportingLimb = input.ReadValueU64(endianess);
			Direction = new Vector(input, endianess);
			Offset = new Vector(input, endianess);
			Radius = input.ReadValueF32(endianess);
			Arc = input.ReadValueF32(endianess);
			ExtraDistance = input.ReadValueF32(endianess);
			UseInput = input.ReadValueB32(endianess);
			MaxInputArc = input.ReadValueF32(endianess);
			UsePreviousSurface = input.ReadValueB32(endianess);
			UseMotion = input.ReadValueB32(endianess);
			SwitchSurfaces = input.ReadValueB32(endianess);
			Branch = new BranchReference(input, endianess);
			Priority = input.ReadValueS32(endianess);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Conditions = BaseProperty.DeserializeConditionProperty(PrototypeGame.P1, input, endianess, PropertyHash.Conditions);
		}
	}
}
