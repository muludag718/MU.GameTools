using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.MotionTrail)]
	public class MotionTrailTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Shader { get; set; }

		public float GenerateTime { get; set; }

		public float FadeInTime { get; set; }

		public float FadeOutTime { get; set; }

		public float TextureTime { get; set; }

		public float FadeTime { get; set; }

		public float FadeInTrailTime { get; set; }

		public float ShrinkTime { get; set; }

		public bool Dragged { get; set; }

		public ulong ShrinkJoint { get; set; }

		public Vector ShrinkOffset { get; set; } = new Vector();

		public int NumJoints { get; set; }

		public ulong Joint1 { get; set; }

		public Vector JointOffset1 { get; set; } = new Vector();

		public ulong Joint2 { get; set; }

		public Vector JointOffset2 { get; set; } = new Vector();

		public ulong Joint3 { get; set; }

		public Vector JointOffset3 { get; set; } = new Vector();

		public ulong Joint4 { get; set; }

		public Vector JointOffset4 { get; set; } = new Vector();

		public ulong Joint5 { get; set; }

		public Vector JointOffset5 { get; set; } = new Vector();

		public ulong Joint6 { get; set; }

		public Vector JointOffset6 { get; set; } = new Vector();

		public bool AbortWhenInterrupted { get; set; }

		public bool RunTillStop { get; set; }

		public int Slot { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Shader, endianess);
			output.WriteValueF32(GenerateTime, endianess);
			output.WriteValueF32(FadeInTime, endianess);
			output.WriteValueF32(FadeOutTime, endianess);
			output.WriteValueF32(TextureTime, endianess);
			output.WriteValueF32(FadeTime, endianess);
			output.WriteValueF32(FadeInTrailTime, endianess);
			output.WriteValueF32(ShrinkTime, endianess);
			output.WriteValueB32(Dragged, endianess);
			output.WriteValueU64(ShrinkJoint, endianess);
			ShrinkOffset.Serialize(output, endianess);
			output.WriteValueS32(NumJoints, endianess);
			output.WriteValueU64(Joint1, endianess);
			JointOffset1.Serialize(output, endianess);
			output.WriteValueU64(Joint2, endianess);
			JointOffset2.Serialize(output, endianess);
			output.WriteValueU64(Joint3, endianess);
			JointOffset3.Serialize(output, endianess);
			output.WriteValueU64(Joint4, endianess);
			JointOffset4.Serialize(output, endianess);
			output.WriteValueU64(Joint5, endianess);
			JointOffset5.Serialize(output, endianess);
			output.WriteValueU64(Joint6, endianess);
			JointOffset6.Serialize(output, endianess);
			output.WriteValueB32(AbortWhenInterrupted, endianess);
			output.WriteValueB32(RunTillStop, endianess);
			output.WriteValueS32(Slot, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Shader = input.ReadValueU64(endianess);
			GenerateTime = input.ReadValueF32(endianess);
			FadeInTime = input.ReadValueF32(endianess);
			FadeOutTime = input.ReadValueF32(endianess);
			TextureTime = input.ReadValueF32(endianess);
			FadeTime = input.ReadValueF32(endianess);
			FadeInTrailTime = input.ReadValueF32(endianess);
			ShrinkTime = input.ReadValueF32(endianess);
			Dragged = input.ReadValueB32(endianess);
			ShrinkJoint = input.ReadValueU64(endianess);
			ShrinkOffset = new Vector(input, endianess);
			NumJoints = input.ReadValueS32(endianess);
			Joint1 = input.ReadValueU64(endianess);
			JointOffset1 = new Vector(input, endianess);
			Joint2 = input.ReadValueU64(endianess);
			JointOffset2 = new Vector(input, endianess);
			Joint3 = input.ReadValueU64(endianess);
			JointOffset3 = new Vector(input, endianess);
			Joint4 = input.ReadValueU64(endianess);
			JointOffset4 = new Vector(input, endianess);
			Joint5 = input.ReadValueU64(endianess);
			JointOffset5 = new Vector(input, endianess);
			Joint6 = input.ReadValueU64(endianess);
			JointOffset6 = new Vector(input, endianess);
			AbortWhenInterrupted = input.ReadValueB32(endianess);
			RunTillStop = input.ReadValueB32(endianess);
			Slot = input.ReadValueS32(endianess);
		}
	}
}
