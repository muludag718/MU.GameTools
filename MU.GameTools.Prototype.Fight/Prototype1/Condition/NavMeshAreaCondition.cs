using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.NavMeshArea)]
	public class NavMeshAreaCondition : P1Condition
	{
		public AllowedAreasFlags AllowedAreas { get; set; }

		public float VerticalTolerance { get; set; }

		public float RayIfNotSupported { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, AllowedAreas);
			output.WriteValueF32(VerticalTolerance, endianess);
			output.WriteValueF32(RayIfNotSupported, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			AllowedAreas = BaseProperty.DeserializePropertyBitfield<AllowedAreasFlags>(input, endianess);
			VerticalTolerance = input.ReadValueF32(endianess);
			RayIfNotSupported = input.ReadValueF32(endianess);
		}
	}
}
