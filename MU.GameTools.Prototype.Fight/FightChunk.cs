using System;
using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.Fight
{
	public class FightChunk
	{
		public uint Unknown1 { get; set; }

		public ulong NameHash { get; set; }

		public ContextHash Context { get; set; }

		public BranchReference BranchRef { get; set; }

		public List<BaseBranch> Branches { get; set; }

		public FightChunk()
		{
		}

		public FightChunk(PrototypeGame game, Stream input, Endian endianess)
		{
			Deserialize(game, input, endianess);
		}

		private void P1_Serialize(Stream output, Endian endianess)
		{
			output.WriteValueU64(7021078959221846271uL);
			Stream stream = new MemoryStream();
			stream.WriteValueU32(Unknown1, endianess);
			stream.WriteValueU64(NameHash, endianess);
			stream.WriteValueU64((ulong)Context, endianess);
			BranchRef.Serialize(stream, endianess);
			output.WriteValueU32((uint)stream.Length, endianess);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream, stream.Length);
			BaseBranch.SerializeBaseBranches(PrototypeGame.P1, output, endianess, Branches);
			output.WriteValueU64(0uL);
		}

		private void P1_Deserialize(Stream input, Endian endianess)
		{
			uint num = input.ReadValueU32(endianess);
			long position = input.Position;
			Unknown1 = input.ReadValueU32(endianess);
			NameHash = input.ReadValueU64(endianess);
			ulong num2 = input.ReadValueU64(endianess);
			if (!Enum.IsDefined(typeof(ContextHash), num2))
			{
				throw new NotImplementedException("Unknown context");
			}
			Context = (ContextHash)num2;
			BranchRef = new BranchReference(input, endianess);
			if (input.Position != position + num)
			{
				throw new FormatException("Invalid chunk header length");
			}
			Branches = BaseBranch.DeserializeBaseBranches(PrototypeGame.P1, input, endianess);
			input.ReadValueU64(Endian.Little);
		}

		private void P2_Serialize(Stream output, Endian endianess)
		{
			throw new NotImplementedException();
		}

		private void P2_Deserialize(Stream input, Endian endianess)
		{
			uint num = input.ReadValueU32(endianess);
			long position = input.Position;
			Unknown1 = input.ReadValueU32(endianess);
			NameHash = input.ReadValueU64(endianess);
			ulong num2 = input.ReadValueU64(endianess);
			if (!Enum.IsDefined(typeof(ContextHash), num2))
			{
				throw new NotImplementedException("Unknown context");
			}
			Context = (ContextHash)num2;
			BranchRef = new BranchReference(input, endianess);
			input.ReadValueS32(endianess);
			Branches = BaseBranch.DeserializeBaseBranches(PrototypeGame.P2, input, endianess);
			if (input.Position != position + num)
			{
				throw new FormatException("Invalid chunk length");
			}
			input.ReadValueU64(Endian.Little);
		}

		public void Serialize(PrototypeGame game, Stream output, Endian endianess)
		{
			switch (game)
			{
			case PrototypeGame.P1:
				P1_Serialize(output, endianess);
				break;
			case PrototypeGame.P2:
				P2_Serialize(output, endianess);
				break;
			default:
				throw new Exception("Non valid game");
			}
		}

		public void Deserialize(PrototypeGame game, Stream input, Endian endianess)
		{
			switch (game)
			{
			case PrototypeGame.P1:
				P1_Deserialize(input, endianess);
				break;
			case PrototypeGame.P2:
				P2_Deserialize(input, endianess);
				break;
			default:
				throw new Exception("Non valid game");
			}
		}
	}
}
