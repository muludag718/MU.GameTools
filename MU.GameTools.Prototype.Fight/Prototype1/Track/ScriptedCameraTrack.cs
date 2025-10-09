using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ScriptedCamera)]
	public class ScriptedCameraTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool AutoEnd { get; set; }

		public bool Parent { get; set; }

		public ulong GrabSlot { get; set; }

		public ulong Joint { get; set; }

		public float OffsetX { get; set; }

		public float OffsetY { get; set; }

		public float OffsetZ { get; set; }

		public bool TrackObject { get; set; }

		public ulong Animation { get; set; }

		public bool RotateY { get; set; }

		public bool MirrorX { get; set; }

		public float StartFrame { get; set; }

		public float EndFrame { get; set; }

		public float Speed { get; set; }

		public AnimationCyclic Cyclic { get; set; }

		public float DofNear { get; set; }

		public float DofFar { get; set; }

		public float DofRange { get; set; }

		public float DofAperture { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(AutoEnd, endianess);
			output.WriteValueB32(Parent, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueU64(Joint, endianess);
			output.WriteValueF32(OffsetX, endianess);
			output.WriteValueF32(OffsetY, endianess);
			output.WriteValueF32(OffsetZ, endianess);
			output.WriteValueB32(TrackObject, endianess);
			output.WriteValueU64(Animation, endianess);
			output.WriteValueB32(RotateY, endianess);
			output.WriteValueB32(MirrorX, endianess);
			output.WriteValueF32(StartFrame, endianess);
			output.WriteValueF32(EndFrame, endianess);
			output.WriteValueF32(Speed, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Cyclic);
			output.WriteValueF32(DofNear, endianess);
			output.WriteValueF32(DofFar, endianess);
			output.WriteValueF32(DofRange, endianess);
			output.WriteValueF32(DofAperture, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			AutoEnd = input.ReadValueB32(endianess);
			Parent = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			Joint = input.ReadValueU64(endianess);
			OffsetX = input.ReadValueF32(endianess);
			OffsetY = input.ReadValueF32(endianess);
			OffsetZ = input.ReadValueF32(endianess);
			TrackObject = input.ReadValueB32(endianess);
			Animation = input.ReadValueU64(endianess);
			RotateY = input.ReadValueB32(endianess);
			MirrorX = input.ReadValueB32(endianess);
			StartFrame = input.ReadValueF32(endianess);
			EndFrame = input.ReadValueF32(endianess);
			Speed = input.ReadValueF32(endianess);
			Cyclic = BaseProperty.DeserializePropertyEnum<AnimationCyclic>(input, endianess);
			DofNear = input.ReadValueF32(endianess);
			DofFar = input.ReadValueF32(endianess);
			DofRange = input.ReadValueF32(endianess);
			DofAperture = input.ReadValueF32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
