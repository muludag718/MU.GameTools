using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownTrack(TrackHash.Lua)]
	public class LuaTrack : P1Track
	{
		public byte[] _luaCode;

		public float StartTime { get; set; }

		public float EndTime { get; set; }

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
				if (LuaCode != null && LuaCode.Length != 0)
				{
					if (LuaCode[0] == 27 && LuaCode[1] == 76 && LuaCode[2] == 117 && LuaCode[3] == 97)
					{
						return LuaCode[4] == 81;
					}
					return false;
				}
				return false;
			}
		}

		public uint LuaLength
		{
			get
			{
				if (LuaCode != null)
				{
					return (uint)LuaCode.Length;
				}
				return 0u;
			}
		}

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(StartTime, endianess);
			output.WriteValueF32(EndTime, endianess);
			output.WriteValueU32(LuaLength, endianess);
			output.WriteBytes(LuaCode);
			for (uint num = LuaLength; num % 4 != 0; num++)
			{
				output.WriteByte(0);
			}
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			StartTime = input.ReadValueF32(endianess);
			EndTime = input.ReadValueF32(endianess);
			uint length = input.ReadValueU32(endianess);
			LuaCode = input.ReadBytes((int)length);
			for (uint num = LuaLength; num % 4 != 0; num++)
			{
				input.ReadByte();
			}
		}
	}
}
