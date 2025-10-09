using System;
using System.IO;
using System.Text;

namespace MU.GameTools.Prototype.FileFormats
{
	public class FourCC
	{
		private readonly byte[] _Chars = new byte[4];

		public FourCC()
		{
		}

		public FourCC(byte[] chars)
		{
			if (chars == null)
			{
				throw new ArgumentNullException("chars");
			}
			if (chars.Length != 4)
			{
				throw new ArgumentException("chars must have a length of 4");
			}
			Array.Copy(chars, _Chars, 4);
		}

		public FourCC(Stream input)
		{
			Deserialize(input);
		}

		public override string ToString()
		{
			return Encoding.ASCII.GetString(_Chars).TrimEnd(default(char));
		}

		public static implicit operator FourCC(string s)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			if (bytes.Length != 4)
			{
				throw new InvalidCastException();
			}
			return new FourCC(bytes);
		}

		public override int GetHashCode()
		{
			return _Chars.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is FourCC fourCC)
			{
				if (fourCC._Chars[0] == _Chars[0] && fourCC._Chars[1] == _Chars[1] && fourCC._Chars[2] == _Chars[2])
				{
					return fourCC._Chars[3] == _Chars[3];
				}
				return false;
			}
			return false;
		}

		public void Serialize(Stream output)
		{
			output.Write(_Chars, 0, 4);
		}

		public void Deserialize(Stream input)
		{
			input.Read(_Chars, 0, 4);
		}
	}
}
