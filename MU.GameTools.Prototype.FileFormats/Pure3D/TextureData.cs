using System.ComponentModel;
using System.Globalization;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(102402u)]
	public class TextureData : BaseNode
	{
		[Category("Image")]
		[ReadOnly(true)]
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

		public override string ExportExtension => "dds";

		public override bool Importable => true;

		public override string ToString()
		{
			if (Data == null || Data.Length == 0)
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Data.Length.ToString(CultureInfo.InvariantCulture) + " bytes)";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueS32(Data.Length, endian);
			output.Write(Data, 0, Data.Length);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			int num = input.ReadValueS32(endian);
			Data = new byte[num];
			input.Read(Data, 0, Data.Length);
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
