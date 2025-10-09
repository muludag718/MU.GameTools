using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.GrabPlayer)]
	public class GrabPlayerTrack : P1Track
	{
		public enum ActionOnEndType : ulong
		{
			Nothing = 2101550166651037979uL,
			Detach = 6128845052282864129uL
		}

		public bool UseLocalSpace { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public PlayerType GrabbingPlayer { get; set; }

		public PlayerType GrabbedPlayer { get; set; }

		public ActionOnEndType ActionOnEnd { get; set; }

		public ulong GrabSlot { get; set; }

		public ulong ParentJoint { get; set; }

		public Vector ParentPositionOffset { get; set; } = new Vector();

		public Vector ParentRotationOffset { get; set; } = new Vector();

		public ulong ChildJoint { get; set; }

		public Vector ChildPositionOffset { get; set; } = new Vector();

		public Vector ChildRotationOffset { get; set; } = new Vector();

		public float BlendTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(UseLocalSpace, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, GrabbingPlayer);
			BaseProperty.SerializePropertyEnum(output, endianess, GrabbedPlayer);
			BaseProperty.SerializePropertyEnum(output, endianess, ActionOnEnd);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueU64(ParentJoint, endianess);
			ParentPositionOffset.Serialize(output, endianess);
			ParentRotationOffset.Serialize(output, endianess);
			output.WriteValueU64(ChildJoint, endianess);
			ChildPositionOffset.Serialize(output, endianess);
			ChildRotationOffset.Serialize(output, endianess);
			output.WriteValueF32(BlendTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			UseLocalSpace = input.ReadValueB32(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			GrabbingPlayer = BaseProperty.DeserializePropertyEnum<PlayerType>(input, endianess);
			GrabbedPlayer = BaseProperty.DeserializePropertyEnum<PlayerType>(input, endianess);
			ActionOnEnd = BaseProperty.DeserializePropertyEnum<ActionOnEndType>(input, endianess);
			GrabSlot = input.ReadValueU64(endianess);
			ParentJoint = input.ReadValueU64(endianess);
			ParentPositionOffset.Deserialize(input, endianess);
			ParentRotationOffset.Deserialize(input, endianess);
			ChildJoint = input.ReadValueU64(endianess);
			ChildPositionOffset.Deserialize(input, endianess);
			ChildRotationOffset.Deserialize(input, endianess);
			BlendTime = input.ReadValueF32(endianess);
		}
	}
}
