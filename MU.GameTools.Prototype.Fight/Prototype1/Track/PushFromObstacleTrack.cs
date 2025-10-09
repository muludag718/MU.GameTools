using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.PushFromObstacle)]
	public class PushFromObstacleTrack : P1Track
	{
		public float BeginTime { get; set; }

		public float EndTime { get; set; }

		public ulong JointName { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public Vector RayVector { get; set; } = new Vector();

		public Collidables CollideWith { get; set; }

		public float Velocity { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			output.WriteValueF32(EndTime, endianess);
			output.WriteValueU64(JointName, endianess);
			Offset.Serialize(output, endianess);
			RayVector.Serialize(output, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWith);
			output.WriteValueF32(Velocity, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			EndTime = input.ReadValueF32(endianess);
			JointName = input.ReadValueU64(endianess);
			Offset = new Vector(input, endianess);
			RayVector = new Vector(input, endianess);
			CollideWith = BaseProperty.DeserializePropertyBitfield<Collidables>(input, endianess);
			Velocity = input.ReadValueF32(endianess);
		}
	}
}
