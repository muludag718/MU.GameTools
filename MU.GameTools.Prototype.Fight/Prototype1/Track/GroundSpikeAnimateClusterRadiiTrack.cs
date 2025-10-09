using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GroundSpikeAnimateClusterRadii)]
	public class GroundSpikeAnimateClusterRadiiTrack : P1Track
	{
		public enum VelocityType : ulong
		{
			OffshootsInactive = 4778735518721658666uL,
			OffshootsActive = 7949029966231454343uL,
			AccDecExponential = 174932811517141887uL,
			AccDec = 4489517269923741034uL,
			DecelerateExponential = 8982505683990869611uL,
			Decelerate = 9186242548299919630uL,
			AccelerateExponential = 11292729051863009090uL,
			Accelerate = 15267335328970854751uL,
			Linear = 4206860010037910535uL
		}

		public float Delay { get; set; }

		public VelocityType SpawnRadiusVelocityType { get; set; }

		public float SpawnEndRadiusScalar { get; set; }

		public VelocityType SpreadRadiusVelocityType { get; set; }

		public float SpreadEndRadiusScalar { get; set; }

		public VelocityType OffsetVelocityType { get; set; }

		public float OffsetAtEnd { get; set; }

		public float AnimationTimeMin { get; set; }

		public float AnimationTimeMax { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(Delay, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, SpawnRadiusVelocityType);
			output.WriteValueF32(SpawnEndRadiusScalar, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, SpreadRadiusVelocityType);
			output.WriteValueF32(SpreadEndRadiusScalar, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, OffsetVelocityType);
			output.WriteValueF32(OffsetAtEnd, endianess);
			output.WriteValueF32(AnimationTimeMin, endianess);
			output.WriteValueF32(AnimationTimeMax, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Delay = input.ReadValueF32(endianess);
			SpawnRadiusVelocityType = BaseProperty.DeserializePropertyEnum<VelocityType>(input, endianess);
			SpawnEndRadiusScalar = input.ReadValueF32(endianess);
			SpreadRadiusVelocityType = BaseProperty.DeserializePropertyEnum<VelocityType>(input, endianess);
			SpreadEndRadiusScalar = input.ReadValueF32(endianess);
			OffsetVelocityType = BaseProperty.DeserializePropertyEnum<VelocityType>(input, endianess);
			OffsetAtEnd = input.ReadValueF32(endianess);
			AnimationTimeMin = input.ReadValueF32(endianess);
			AnimationTimeMax = input.ReadValueF32(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
		}
	}
}
