using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.DramaticCamera)]
	public class DramaticCameraTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool Parent { get; set; }

		public ulong GrabSlot { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public bool TrackCharacter { get; set; }

		public bool AbortWhenInterrupted { get; set; }

		public float FirstFrameHoldTime { get; set; }

		public float LastFrameHoldTime { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public float NoCameraWeight { get; set; }

		public ulong Animation1 { get; set; }

		public float StartFrame1 { get; set; }

		public float EndFrame1 { get; set; }

		public float Speed1 { get; set; }

		public bool EnableNormal1 { get; set; }

		public bool EnableMirror1 { get; set; }

		public float AnimationWeight1 { get; set; }

		public ulong Animation2 { get; set; }

		public float StartFrame2 { get; set; }

		public float EndFrame2 { get; set; }

		public float Speed2 { get; set; }

		public bool EnableNormal2 { get; set; }

		public bool EnableMirror2 { get; set; }

		public float AnimationWeight2 { get; set; }

		public ulong Animation3 { get; set; }

		public float StartFrame3 { get; set; }

		public float EndFrame3 { get; set; }

		public float Speed3 { get; set; }

		public bool EnableNormal3 { get; set; }

		public bool EnableMirror3 { get; set; }

		public float AnimationWeight3 { get; set; }

		public ulong Animation4 { get; set; }

		public float StartFrame4 { get; set; }

		public float EndFrame4 { get; set; }

		public float Speed4 { get; set; }

		public bool EnableNormal4 { get; set; }

		public bool EnableMirror4 { get; set; }

		public float AnimationWeight4 { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(Parent, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			Offset.Serialize(output, endianess);
			output.WriteValueB32(TrackCharacter, endianess);
			output.WriteValueB32(AbortWhenInterrupted, endianess);
			output.WriteValueF32(FirstFrameHoldTime, endianess);
			output.WriteValueF32(LastFrameHoldTime, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
			output.WriteValueF32(NoCameraWeight, endianess);
			output.WriteValueU64(Animation1, endianess);
			output.WriteValueF32(StartFrame1, endianess);
			output.WriteValueF32(EndFrame1, endianess);
			output.WriteValueF32(Speed1, endianess);
			output.WriteValueB32(EnableNormal1, endianess);
			output.WriteValueB32(EnableMirror1, endianess);
			output.WriteValueF32(AnimationWeight1, endianess);
			output.WriteValueU64(Animation2, endianess);
			output.WriteValueF32(StartFrame2, endianess);
			output.WriteValueF32(EndFrame2, endianess);
			output.WriteValueF32(Speed2, endianess);
			output.WriteValueB32(EnableNormal2, endianess);
			output.WriteValueB32(EnableMirror2, endianess);
			output.WriteValueF32(AnimationWeight2, endianess);
			output.WriteValueU64(Animation3, endianess);
			output.WriteValueF32(StartFrame3, endianess);
			output.WriteValueF32(EndFrame3, endianess);
			output.WriteValueF32(Speed3, endianess);
			output.WriteValueB32(EnableNormal3, endianess);
			output.WriteValueB32(EnableMirror3, endianess);
			output.WriteValueF32(AnimationWeight3, endianess);
			output.WriteValueU64(Animation4, endianess);
			output.WriteValueF32(StartFrame4, endianess);
			output.WriteValueF32(EndFrame4, endianess);
			output.WriteValueF32(Speed4, endianess);
			output.WriteValueB32(EnableNormal4, endianess);
			output.WriteValueB32(EnableMirror4, endianess);
			output.WriteValueF32(AnimationWeight4, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Parent = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			Offset = new Vector(input, endianess);
			TrackCharacter = input.ReadValueB32(endianess);
			AbortWhenInterrupted = input.ReadValueB32(endianess);
			FirstFrameHoldTime = input.ReadValueF32(endianess);
			LastFrameHoldTime = input.ReadValueF32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
			NoCameraWeight = input.ReadValueF32(endianess);
			Animation1 = input.ReadValueU64(endianess);
			StartFrame1 = input.ReadValueF32(endianess);
			EndFrame1 = input.ReadValueF32(endianess);
			Speed1 = input.ReadValueF32(endianess);
			EnableNormal1 = input.ReadValueB32(endianess);
			EnableMirror1 = input.ReadValueB32(endianess);
			AnimationWeight1 = input.ReadValueF32(endianess);
			Animation2 = input.ReadValueU64(endianess);
			StartFrame2 = input.ReadValueF32(endianess);
			EndFrame2 = input.ReadValueF32(endianess);
			Speed2 = input.ReadValueF32(endianess);
			EnableNormal2 = input.ReadValueB32(endianess);
			EnableMirror2 = input.ReadValueB32(endianess);
			AnimationWeight2 = input.ReadValueF32(endianess);
			Animation3 = input.ReadValueU64(endianess);
			StartFrame3 = input.ReadValueF32(endianess);
			EndFrame3 = input.ReadValueF32(endianess);
			Speed3 = input.ReadValueF32(endianess);
			EnableNormal3 = input.ReadValueB32(endianess);
			EnableMirror3 = input.ReadValueB32(endianess);
			AnimationWeight3 = input.ReadValueF32(endianess);
			Animation4 = input.ReadValueU64(endianess);
			StartFrame4 = input.ReadValueF32(endianess);
			EndFrame4 = input.ReadValueF32(endianess);
			Speed4 = input.ReadValueF32(endianess);
			EnableNormal4 = input.ReadValueB32(endianess);
			EnableMirror4 = input.ReadValueB32(endianess);
			AnimationWeight4 = input.ReadValueF32(endianess);
		}
	}
}
