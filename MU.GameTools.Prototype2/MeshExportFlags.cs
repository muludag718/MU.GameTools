namespace MU.GameTools.Prototype2
{
	public enum MeshExportFlags
	{
		Position = 1,
		Normal = 2,
		Tangent = 4,
		Weight = 8,
		Group = 0x10,
		UV = 0x20,
		Padding = 0x40,
		Faces = 0x80,
		Colour = 0x100
	}
}
