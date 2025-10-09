using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Decal)]
	public class DecalTrack : P1Track
	{
		public enum DecalStoreType : ulong
		{
			General = 1312132684818588012uL,
			Treadmark = 12991007662534441811uL
		}

		public ulong ShaderName { get; set; }

		public int RandomSelect { get; set; }

		public float RandomOrientation { get; set; }

		public bool ScaleByDamage { get; set; }

		public float ScaleX { get; set; }

		public float ScaleY { get; set; }

		public string Patch { get; set; }

		public DecalStoreType DecalStore { get; set; }

		public bool CullOffscreen { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(ShaderName, endianess);
			output.WriteValueS32(RandomSelect, endianess);
			output.WriteValueF32(RandomOrientation, endianess);
			output.WriteValueB32(ScaleByDamage, endianess);
			output.WriteValueF32(ScaleX, endianess);
			output.WriteValueF32(ScaleY, endianess);
			output.WriteStringAlignedU32(Patch, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DecalStore);
			output.WriteValueB32(CullOffscreen, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ShaderName = input.ReadValueU64(endianess);
			RandomSelect = input.ReadValueS32(endianess);
			RandomOrientation = input.ReadValueF32(endianess);
			ScaleByDamage = input.ReadValueB32(endianess);
			ScaleX = input.ReadValueF32(endianess);
			ScaleY = input.ReadValueF32(endianess);
			Patch = input.ReadStringAlignedU32(endianess);
			DecalStore = BaseProperty.DeserializePropertyEnum<DecalStoreType>(input, endianess);
			CullOffscreen = input.ReadValueB32(endianess);
		}
	}
}
