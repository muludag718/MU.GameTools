using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.PhysicsSetIntersectionProperties)]
	public class PhysicsSetIntersectionPropertiesTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ColliderType Collider { get; set; }

		public Collidables CollideWith { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, Collider);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWith);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Collider = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
			CollideWith = BaseProperty.DeserializePropertyBitfield<Collidables>(input, endianess);
		}
	}
}
