using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Joint)]
	public class JointTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Joint { get; set; }

		public bool UseRestPose { get; set; }

		public bool HasTranslation { get; set; }

		public Vector Translation { get; set; } = new Vector();

		public bool HasRotation { get; set; }

		public Vector Rotation { get; set; } = new Vector();

		public int Priority { get; set; }

		public bool AutomaticBlendTimes { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Joint, endianess);
			output.WriteValueB32(UseRestPose, endianess);
			output.WriteValueB32(HasTranslation, endianess);
			Translation.Serialize(output, endianess);
			output.WriteValueB32(HasRotation, endianess);
			Rotation.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueB32(AutomaticBlendTimes, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Joint = input.ReadValueU64(endianess);
			UseRestPose = input.ReadValueB32(endianess);
			HasTranslation = input.ReadValueB32(endianess);
			Translation = new Vector(input, endianess);
			HasRotation = input.ReadValueB32(endianess);
			Rotation = new Vector(input, endianess);
			Priority = input.ReadValueS32(endianess);
			AutomaticBlendTimes = input.ReadValueB32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
