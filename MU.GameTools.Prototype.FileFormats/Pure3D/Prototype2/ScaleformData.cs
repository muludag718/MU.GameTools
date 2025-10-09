using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2
{
	[KnownGame(PrototypeGame.P2)]
	[KnownType(98817u)]
	public class ScaleformData : BaseNode
	{
		public string Name { get; set; }

		public int Unknown1 { get; set; }

		public byte[] Data { get; set; }

		public override bool Exportable
		{
			get
			{
				if (Data != null)
				{
					return Data.Length != 0;
				}
				return false;
			}
		}

		public override string ExportExtension => "gfx";

		public override bool Importable => true;

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
			output.WriteValueS32(Data.Length, endian);
			output.WriteBytes(Data);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Unknown1 = input.ReadValueS32(endian);
			int length = input.ReadValueS32(endian);
			Data = input.ReadBytes(length);
		}

		public override void Export(Stream output)
		{
			output.Write(Data, 0, Data.Length);
		}

		public override void Import(Stream input)
		{
			Data = new byte[input.Length];
			input.Read(Data, 0, Data.Length);
		}
	}
}
