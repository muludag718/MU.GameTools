using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(69644u)]
	public class ShaderCode : BaseNode
	{
		[TypeConverter(typeof(ExpandableObjectConverter))]
		public interface ICode
		{
			void Serialize(Stream output);

			void Deserialize(Stream input);
		}

		public class CompiledCode : ICode
		{
			public byte[] Data { get; set; }

			public void Serialize(Stream output)
			{
				output.Write(Data, 0, Data.Length);
			}

			public void Deserialize(Stream input)
			{
				Data = new byte[input.Length];
				input.Read(Data, 0, Data.Length);
			}
		}

		public class SourceCode : ICode
		{
			public string Text { get; set; }

			public void Serialize(Stream output)
			{
				output.WriteStringZ(Text, Encoding.ASCII);
			}

			public void Deserialize(Stream input)
			{
				Text = input.ReadString((int)input.Length, trailingNull: true, Encoding.ASCII);
			}
		}

		[DisplayName("Global Variable Count")]
		public uint GlobalVariableCount { get; set; }

		public ICode Code { get; set; }

		public override bool Exportable => Code != null;

		public override bool Importable => Code != null;

		public override string ToString()
		{
			if (Code == null)
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Code.GetType().Name + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			if (Code is SourceCode)
			{
				output.WriteValueU32(1u, endian);
			}
			else
			{
				if (!(Code is CompiledCode))
				{
					throw new InvalidOperationException();
				}
				output.WriteValueU32(5u, endian);
			}
			Stream stream = new MemoryStream();
			Code.Serialize(stream);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteValueS32((int)stream.Length);
			output.WriteFromStream(stream, stream.Length);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			uint num = input.ReadValueU32(endian);
			int size = input.ReadValueS32(endian);
			GlobalVariableCount = input.ReadValueU32(endian);
			MemoryStream input2 = input.ReadToMemoryStream(size);
			ICode code = num switch
			{
				1u => new SourceCode(), 
				5u => new CompiledCode(), 
				_ => throw new InvalidOperationException(), 
			};
			code.Deserialize(input2);
			Code = code;
		}

		public override void Export(Stream output)
		{
			Code.Serialize(output);
		}

		public override void Import(Stream input)
		{
			Code.Deserialize(input);
		}
	}
}
