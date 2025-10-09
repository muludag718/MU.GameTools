using System.Collections.Generic;
using System.IO;
using System.Linq;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(1184002u)]
	public class Vector1DOFChannel : AnimationChannel
	{
		public override void Serialize(Stream output, Endian endian)
		{
			base.Serialize(output, endian);
			output.WriteValueU16(base.Mapping);
			base.BaseValues.Serialize(output, endian);
			output.WriteValueU32(base.NumberOfFrames);
			if (!base.ContainsAnimData)
			{
				return;
			}
			foreach (ushort key in base.Frames.Keys)
			{
				output.WriteValueU16(key, endian);
			}
			foreach (Vector4 value in base.Frames.Values)
			{
				output.WriteValueF32(value.X, endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			base.Deserialize(input, endian);
			base.Mapping = input.ReadValueU16(endian);
			base.BaseValues = new Vector3(input, endian);
			base.NumberOfFrames = input.ReadValueU32(endian);
			base.Frames = new Dictionary<ushort, Vector4>();
			for (int i = 0; i < base.NumberOfFrames; i++)
			{
				base.Frames.Add(input.ReadValueU16(endian), new Vector4());
			}
			ReadChannel(input, endian);
		}

		protected override void ReadChannel(Stream input, Endian endian)
		{
			foreach (Vector4 value in base.Frames.Values)
			{
				value.X = input.ReadValueF32(endian);
			}
		}

		public override Vector4 CalculateValue(float frame)
		{
			Vector4 vector = new Vector4
			{
				X = base.BaseValues.X,
				Y = base.BaseValues.Y,
				Z = base.BaseValues.Z
			};
			if (GetKey(frame, out var start, out var end))
			{
				if (frame - (float)(int)base.Frames.Keys.ElementAt(start) == 0f)
				{
					vector[base.Mapping] = base.Frames.ElementAt(start).Value.X;
				}
				else
				{
					float num = base.Frames.Keys.ElementAt(end) - base.Frames.Keys.ElementAt(start);
					vector[base.Mapping] = (base.Frames.ElementAt(end).Value.X - base.Frames.ElementAt(start).Value.X) * num + base.Frames.ElementAt(start).Value.X;
				}
			}
			else
			{
				vector[base.Mapping] = base.Frames.ElementAt(start).Value.X;
			}
			return vector;
		}
	}
}
