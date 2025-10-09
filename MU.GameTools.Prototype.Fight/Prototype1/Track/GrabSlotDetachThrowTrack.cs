using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GrabSlotDetachThrow)]
	public class GrabSlotDetachThrowTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float LatestDetachTime { get; set; }

		public ulong GrabSlot { get; set; }

		public VelocityReference LinearVelocityReference { get; set; }

		public Vector AddedLinearVelocity { get; set; } = new Vector();

		public VelocityReference AngularVelocityReference { get; set; }

		public Vector AddedAngularVelocity { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(LatestDetachTime, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, LinearVelocityReference);
			AddedLinearVelocity.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AngularVelocityReference);
			AddedAngularVelocity.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			LatestDetachTime = input.ReadValueF32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			LinearVelocityReference = BaseProperty.DeserializePropertyEnum<VelocityReference>(input, endianess);
			AddedLinearVelocity = new Vector(input, endianess);
			AngularVelocityReference = BaseProperty.DeserializePropertyEnum<VelocityReference>(input, endianess);
			AddedAngularVelocity = new Vector(input, endianess);
		}
	}
}
