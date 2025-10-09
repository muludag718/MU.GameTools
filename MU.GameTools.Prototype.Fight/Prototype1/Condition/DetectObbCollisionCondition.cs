using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.DetectObbCollision)]
	public class DetectObbCollisionCondition : P1Condition
	{
		public Collidables CollideWith { get; set; }

		public bool Match { get; set; }

		public ulong Joint { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public Vector Orientation { get; set; } = new Vector();

		public Vector Extents { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWith);
			output.WriteValueB32(Match, endianess);
			output.WriteValueU64(Joint, endianess);
			Offset.Serialize(output, endianess);
			Orientation.Serialize(output, endianess);
			Extents.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			CollideWith = BaseProperty.DeserializePropertyBitfield<Collidables>(input, endianess);
			Match = input.ReadValueB32(endianess);
			Joint = input.ReadValueU64(endianess);
			Offset.Deserialize(input, endianess);
			Orientation.Deserialize(input, endianess);
			Extents.Deserialize(input, endianess);
		}
	}
}
