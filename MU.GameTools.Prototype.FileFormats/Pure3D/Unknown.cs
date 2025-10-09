using System;
using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	public class Unknown : BaseNode
	{
		private readonly uint _TypeId;

		public override uint TypeId => _TypeId;

		public bool HasError { get; set; }

		[ReadOnly(true)]
		[Category("Pure3D")]
		public byte[] Data { get; set; }

		[ReadOnly(true)]
		[Category("Pure3D")]
		public int Length
		{
			get
			{
				if (Data != null)
				{
					return Data.Length;
				}
				return -1;
			}
		}

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

		public Unknown(uint typeId)
		{
			_TypeId = typeId;
		}

		public override string ToString()
		{
			return "Unknown (" + TypeId.ToString("X8") + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteBytes(Data);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			throw new NotSupportedException();
		}

		public override void Export(Stream output)
		{
			output.Write(Data, 0, Data.Length);
		}
	}
}
