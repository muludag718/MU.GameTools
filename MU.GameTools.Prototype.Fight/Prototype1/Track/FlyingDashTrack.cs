using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.FlyingDash)]
	public class FlyingDashTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float VelocityAdd { get; set; }

		public float VelocityMax { get; set; }

		public bool PreserveYVelocity { get; set; }

		public ulong DashToTargetGrabbableClass { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(VelocityAdd, endianess);
			output.WriteValueF32(VelocityMax, endianess);
			output.WriteValueB32(PreserveYVelocity, endianess);
			output.WriteValueU64(DashToTargetGrabbableClass, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			VelocityAdd = input.ReadValueF32(endianess);
			VelocityMax = input.ReadValueF32(endianess);
			PreserveYVelocity = input.ReadValueB32(endianess);
			DashToTargetGrabbableClass = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
