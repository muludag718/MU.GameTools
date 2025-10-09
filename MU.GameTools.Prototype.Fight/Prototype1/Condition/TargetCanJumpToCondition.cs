using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.TargetCanJumpTo)]
	public class TargetCanJumpToCondition : P1Condition
	{
		public float LaunchAngle { get; set; }

		public float MinLaunchAngle { get; set; }

		public float Gravity { get; set; }

		public float MaxInitialVelocity { get; set; }

		public bool UseStoredValues { get; set; }

		public float Margin { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(LaunchAngle, endianess);
			output.WriteValueF32(MinLaunchAngle, endianess);
			output.WriteValueF32(Gravity, endianess);
			output.WriteValueF32(MaxInitialVelocity, endianess);
			output.WriteValueB32(UseStoredValues, endianess);
			output.WriteValueF32(Margin, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			LaunchAngle = input.ReadValueF32(endianess);
			MinLaunchAngle = input.ReadValueF32(endianess);
			Gravity = input.ReadValueF32(endianess);
			MaxInitialVelocity = input.ReadValueF32(endianess);
			UseStoredValues = input.ReadValueB32(endianess);
			Margin = input.ReadValueF32(endianess);
		}
	}
}
