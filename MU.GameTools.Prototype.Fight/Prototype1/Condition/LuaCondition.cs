using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.Lua)]
	public class LuaCondition : P1Condition
	{
		public byte[] _luaCode;

		public byte[] LuaCode
		{
			get
			{
				if (_luaCode == null)
				{
					return new byte[0];
				}
				return _luaCode;
			}
			set
			{
				_luaCode = value;
			}
		}

		public bool IsLuaCompiled
		{
			get
			{
				if (LuaCode[0] == 27 && LuaCode[1] == 76 && LuaCode[2] == 117 && LuaCode[3] == 97)
				{
					return LuaCode[4] == 81;
				}
				return false;
			}
		}

		public uint LuaLength
		{
			get
			{
				if (LuaCode == null)
				{
					return 0u;
				}
				return (uint)LuaCode.Length;
			}
		}

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU32(LuaLength);
			output.WriteBytes(LuaCode);
			for (uint num = LuaLength; num % 4 != 0; num++)
			{
				output.WriteByte(0);
			}
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			uint length = input.ReadValueU32(endianess);
			LuaCode = input.ReadBytes((int)length);
			for (uint num = LuaLength; num % 4 != 0; num++)
			{
				input.ReadByte();
			}
		}
	}
}
