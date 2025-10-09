using System;
using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats
{
	public class Pure3DFile
	{
		public Endian Endian;

		public List<BaseNode> Nodes = new List<BaseNode>();

		public PrototypeGame GamePicked;

		public const uint Signature = 1345537279u;

		private void SerializeNode(Stream output, BaseNode node, Endian endianess)
		{
			Stream stream = new MemoryStream();
			foreach (BaseNode child in node.Children)
			{
				SerializeNode(stream, child, endianess);
			}
			Stream stream2 = new MemoryStream();
			node.Serialize(stream2, endianess);
			output.WriteValueU32(node.TypeId, endianess);
			output.WriteValueU32((uint)(12 + stream2.Length), endianess);
			output.WriteValueU32((uint)(12 + stream2.Length + stream.Length), endianess);
			stream2.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream2, stream2.Length);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream, stream.Length);
		}

		public void Serialize(Stream output, Endian endianess)
		{
			Stream stream = new MemoryStream();
			foreach (BaseNode node in Nodes)
			{
				SerializeNode(stream, node, endianess);
			}
			output.WriteValueU32(4282659664u, endianess);
			output.WriteValueU32(12u, endianess);
			output.WriteValueU32((uint)(12 + stream.Length), endianess);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream, stream.Length);
		}

		public static BaseNode DeserializeNode(Stream input, Endian endian, BaseNode parent, PrototypeGame game)
		{
			long position = input.Position;
			input.ReadValueU32(endian);
			uint num = input.ReadValueU32(endian);
			uint num2 = input.ReadValueU32(endian);
			input.Position = position;
			BaseNode baseNode = CreateP3DNode(input, endian, parent, game);
			if (input.Position != position + num)
			{
				throw new FormatException();
			}
			long num3 = position + num2;
			while (input.Position < num3)
			{
				BaseNode item = DeserializeNode(input, endian, baseNode, game);
				baseNode.Children.Add(item);
			}
			if (input.Position != num3)
			{
				throw new FormatException();
			}
			return baseNode;
		}

		private static BaseNode CreateP3DNode(Stream input, Endian endian, BaseNode parent, PrototypeGame game = PrototypeGame.Any)
		{
			long position = input.Position;
			uint num = input.ReadValueU32(endian);
			uint num2 = input.ReadValueU32(endian);
			uint totalSize = input.ReadValueU32(endian);
			BaseNode baseNode = NodeFactory.CreateNode(num, game);
			if (baseNode != null)
			{
				baseNode.Game = game;
				baseNode.StartPosition = (uint)position;
				baseNode.HeaderSize = num2;
				baseNode.TotalSize = totalSize;
				baseNode.ParentNode = parent;
				baseNode.Deserialize(input, endian);
			}
			else
			{
				baseNode = new Unknown(num)
				{
					Game = PrototypeGame.Any,
					StartPosition = (uint)position,
					HeaderSize = num2,
					TotalSize = totalSize,
					Data = input.ReadBytes((int)(num2 - 12))
				};
				baseNode.ParentNode = parent;
			}
			baseNode.ID = num;
			return baseNode;
		}

		public void Deserialize(Stream input, Endian endianess)
		{
			long position = input.Position;
			uint num = input.ReadValueU32(endianess);
			if (num != 1345537279 && num.Swap() != 1345537279)
			{
				throw new FormatException("not a Pure3D file");
			}
			if (input.ReadValueU32(endianess) != 12)
			{
				throw new FormatException("invalid header size");
			}
			uint num2 = input.ReadValueU32(endianess);
			if (position + num2 > input.Length)
			{
				throw new FormatException();
			}
			long num3 = position + num2;
			Nodes.Clear();
			while (input.Position < num3)
			{
				Nodes.Add(DeserializeNode(input, endianess, null, GamePicked));
			}
			if (input.Position != num3)
			{
				throw new FormatException();
			}
			Endian = endianess;
		}
	}
}
