using System;
using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.Fight
{
	public class BaseBranch : FightNode
	{
		public ulong NameHash { get; set; }

		public string Path { get; set; } = "";

		public uint NumberOfSiblings { get; set; }

		public List<BaseBranch> Branches { get; set; } = new List<BaseBranch>();

		public override object Clone(PrototypeGame game)
		{
			Stream stream = new MemoryStream();
			SerializeBaseBranch(game, stream, Endian.Little, this, 0);
			stream.Position = 0L;
			ulong hash = stream.ReadValueU64();
			return DeserializeBaseBranch(game, stream, Endian.Little, hash);
		}

		public override void Serialize(Stream output, Endian endianess)
		{
			output.WriteValueU64(NameHash, endianess);
			output.WriteStringAlignedU32(Path, endianess);
			output.WriteValueU32(NumberOfSiblings, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			NameHash = input.ReadValueU64(endianess);
			Path = input.ReadStringAlignedU32(endianess);
			NumberOfSiblings = input.ReadValueU32(endianess);
		}

		public static void SerializeBaseBranch(PrototypeGame game, Stream output, Endian endianess, BaseBranch branch, int numSiblings)
		{
			switch (game)
			{
			case PrototypeGame.P1:
				P1_SerializeBaseBranch(output, endianess, branch, numSiblings);
				break;
			case PrototypeGame.P2:
				P2_SerializeBaseBranch(output, endianess, branch, numSiblings);
				break;
			default:
				throw new Exception("Non valid game");
			}
		}

		public static void SerializeBaseBranches(PrototypeGame game, Stream output, Endian endianess, List<BaseBranch> branches)
		{
			switch (game)
			{
			case PrototypeGame.P1:
				P1_SerializeBaseBranches(output, endianess, branches);
				break;
			case PrototypeGame.P2:
				P2_SerializeBaseBranches(output, endianess, branches);
				break;
			default:
				throw new Exception("Non valid game");
			}
		}

		public static BaseBranch DeserializeBaseBranch(PrototypeGame game, Stream input, Endian endianess, ulong hash)
		{
			return game switch
			{
				PrototypeGame.P1 => P1_DeserializeBaseBranch(input, endianess, hash), 
				PrototypeGame.P2 => P2_DeserializeBaseBranch(input, endianess, hash), 
				_ => throw new Exception("Non valid game"), 
			};
		}

		public static List<BaseBranch> DeserializeBaseBranches(PrototypeGame game, Stream input, Endian endianess)
		{
			return game switch
			{
				PrototypeGame.P1 => P1_DeserializeBaseBranches(input, endianess), 
				PrototypeGame.P2 => P2_DeserializeBaseBranches(input, endianess), 
				_ => throw new Exception("Non valid game"), 
			};
		}

		public static void P1_SerializeBaseBranch(Stream output, Endian endianess, BaseBranch branch, int numSiblings)
		{
			Stream stream = new MemoryStream();
			branch.NumberOfSiblings = (uint)numSiblings;
			branch.Serialize(stream, endianess);
			output.WriteValueU64(branch.TypeHash, endianess);
			output.WriteValueU32((uint)stream.Length, endianess);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream, stream.Length);
			branch.SerializeProperties(PrototypeGame.P1, output, endianess);
			P1_SerializeBaseBranches(output, endianess, branch.Branches);
			output.WriteValueU64(0uL);
		}

		public static void P1_SerializeBaseBranches(Stream output, Endian endianess, List<BaseBranch> branches)
		{
			foreach (BaseBranch branch in branches)
			{
				P1_SerializeBaseBranch(output, endianess, branch, branches.Count);
			}
		}

		public static BaseBranch P1_DeserializeBaseBranch(Stream input, Endian endianess, ulong hash)
		{
			BaseBranch obj = Factory<BaseBranch, KnownBranchAttribute>.Build(PrototypeGame.P1, hash) ?? throw new NotImplementedException("Unknown branch");
			uint num = input.ReadValueU32(endianess);
			long position = input.Position;
			obj.Deserialize(input, endianess);
			if (input.Position != position + num)
			{
				throw new FormatException("Invalid branch length");
			}
			obj.DeserializeProperties(PrototypeGame.P1, input, endianess);
			obj.Branches = DeserializeBaseBranches(PrototypeGame.P1, input, endianess);
			input.ReadValueU64(Endian.Little);
			return obj;
		}

		public static List<BaseBranch> P1_DeserializeBaseBranches(Stream input, Endian endianess)
		{
			List<BaseBranch> list = new List<BaseBranch>();
			while (true)
			{
				ulong num = input.ReadValueU64(endianess);
				if (num == 0L)
				{
					break;
				}
				list.Add(P1_DeserializeBaseBranch(input, endianess, num));
			}
			input.Position -= 8L;
			return list;
		}

		private static void P2_SerializeBaseBranch(Stream output, Endian endianess, BaseBranch branch, int numSiblings)
		{
			Stream stream = new MemoryStream();
			branch.NumberOfSiblings = (uint)numSiblings;
			branch.Serialize(stream, endianess);
			output.WriteValueU64(branch.TypeHash, endianess);
			output.WriteValueU32((uint)stream.Length, endianess);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream, stream.Length);
			branch.SerializeProperties(PrototypeGame.P1, output, endianess);
			P2_SerializeBaseBranches(output, endianess, branch.Branches);
			output.WriteValueU64(0uL);
		}

		private static void P2_SerializeBaseBranches(Stream output, Endian endianess, List<BaseBranch> branches)
		{
			foreach (BaseBranch branch in branches)
			{
				P2_SerializeBaseBranch(output, endianess, branch, branches.Count);
			}
		}

		private static BaseBranch P2_DeserializeBaseBranch(Stream input, Endian endianess, ulong hash)
		{
			BaseBranch obj = Factory<BaseBranch, KnownBranchAttribute>.Build(PrototypeGame.P2, hash) ?? throw new NotImplementedException("Unknown branch");
			uint num = input.ReadValueU32(endianess);
			long position = input.Position;
			obj.Deserialize(input, endianess);
			obj.DeserializeProperties(PrototypeGame.P2, input, endianess);
			obj.Branches = P2_DeserializeBaseBranches(input, endianess);
			if (input.Position != position + num)
			{
				throw new FormatException("Invalid branch length");
			}
			input.ReadValueU64(Endian.Little);
			return obj;
		}

		private static List<BaseBranch> P2_DeserializeBaseBranches(Stream input, Endian endianess)
		{
			List<BaseBranch> list = new List<BaseBranch>();
			while (true)
			{
				ulong num = input.ReadValueU64(endianess);
				if (num == 0L)
				{
					break;
				}
				list.Add(P2_DeserializeBaseBranch(input, endianess, num));
			}
			input.Position -= 8L;
			return list;
		}
	}
}
