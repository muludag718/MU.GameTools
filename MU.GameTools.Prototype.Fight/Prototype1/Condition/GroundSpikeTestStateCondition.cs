using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.GroundSpikeTestState)]
	public class GroundSpikeTestStateCondition : P1Condition
	{
		public enum GroundSpikeTestType : ulong
		{
			Descending = 605466029595790150uL,
			AllSpawnedMotionIncomplete = 8429933045917250773uL,
			AllSpawnedMotionComplete = 3617334664706998148uL,
			ClusterMotionIncomplete = 50436313802653084uL,
			ClusterMotionComplete = 13785681490621827537uL,
			ClusterInactive = 11364860035905269777uL,
			ClusterActive = 10578384007259670492uL,
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

		public GroundSpikeTestType TestType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, TestType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TestType = BaseProperty.DeserializePropertyEnum<GroundSpikeTestType>(input, endianess);
		}
	}
}
