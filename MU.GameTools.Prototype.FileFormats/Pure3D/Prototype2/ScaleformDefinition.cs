using System;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2
{
	[KnownGame(PrototypeGame.P2)]
	[KnownType(98819u)]
	public class ScaleformDefinition : BaseNode
	{
		public string Name { get; set; }

		public int Unknown1 { get; set; }

		public override string ExportExtension => "gfx";

		public override bool Exportable => GetChildNode<ScaleformData>()?.Exportable ?? false;

		public override bool Importable => GetChildNode<ScaleformData>()?.Exportable ?? false;

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Name.Trim(default(char)) + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Name);
			output.WriteValueS32(Unknown1, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Unknown1 = input.ReadValueS32(endian);
		}

		public override void Export(Stream output)
		{
			(GetChildNode<ScaleformData>() ?? throw new InvalidOperationException()).Export(output);
		}

		public override void Import(Stream input)
		{
			(GetChildNode<ScaleformData>() ?? throw new InvalidOperationException()).Import(input);
		}
	}
}
