using System;
using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Tod;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(133169153u)]
	[TypeConverter(typeof(TodTypeConverter))]
	public class MetaObjectData : BaseNode
	{
		[Browsable(false)]
		public MetaObject metaObject;

		[Browsable(false)]
		public MetaObjectDefinition ObjectDefinition { get; set; }

		[Browsable(false)]
		public bool BigEndian { get; set; }

		[Browsable(false)]
		public string TypeName => ObjectDefinition.TypeName;

		public override string ToString()
		{
			if (string.IsNullOrEmpty(TypeName))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + TypeName.Trim(default(char)) + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			Stream stream = new MemoryStream();
			if (BigEndian)
			{
				stream.WriteString("ATEM");
			}
			else
			{
				stream.WriteString("META");
			}
			Endian endian2 = (BigEndian ? Endian.Big : Endian.Little);
			metaObject.Serialize(stream, endian2);
			output.WriteValueU32((uint)stream.Length, endian);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream, stream.Length);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			ObjectDefinition = (MetaObjectDefinition)ParentNode;
			uint num = input.ReadValueU32(endian);
			num -= 4;
			string text = input.ReadString(4);
			if (text == "META")
			{
				BigEndian = false;
			}
			else
			{
				if (!(text == "ATEM"))
				{
					throw new FormatException("Invalid tod signature");
				}
				BigEndian = true;
			}
			Endian endian2 = (BigEndian ? Endian.Big : Endian.Little);
			MetaObject metaObject = MetaObjectFactory.CreateTod(TypeName.Trim(default(char)), base.Game);
			if (metaObject == null)
			{
				this.metaObject = new UnknownMeta(input, endian2, num);
				return;
			}
			this.metaObject = metaObject;
			this.metaObject.Length = num;
			this.metaObject.Deserialize(input, endian2);
		}
	}
}
