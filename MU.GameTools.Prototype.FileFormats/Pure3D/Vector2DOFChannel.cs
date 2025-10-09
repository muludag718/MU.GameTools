using System.Collections.Generic;
using System.IO;
using System.Linq;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(1184003u)]
	public class Vector2DOFChannel : AnimationChannel
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
				output.WriteValueF32(value.Y, endian);
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
				Vector2 vector = new Vector2(input, endian);
				value.X = vector.X;
				value.Y = vector.Y;
			}
		}

		public override Vector4 CalculateValue(float frame)
		{
			Vector4 vector = new Vector4
			{
				X = base.BaseValues.X,
				Y = base.BaseValues.Y,
				Z = base.BaseValues.Z,
				W = 0f
			};
			int[] array = Constants.STATIC_INDEX[base.Mapping];
			if (GetKey(frame, out var start, out var end))
			{
				float num = frame - (float)(int)base.Frames.Keys.ElementAt(start);
				if (num == 0f)
				{
					vector[array[0]] = base.Frames.ElementAt(start).Value.X;
					vector[array[1]] = base.Frames.ElementAt(start).Value.Y;
				}
				else
				{
					float num2 = num / (float)(base.Frames.Keys.ElementAt(end) - base.Frames.Keys.ElementAt(start));
					vector[array[0]] = base.Frames.ElementAt(start).Value.X + (base.Frames.ElementAt(end).Value.X - base.Frames.ElementAt(start).Value.X) * num2;
					vector[array[1]] = base.Frames.ElementAt(start).Value.Y + (base.Frames.ElementAt(end).Value.Y - base.Frames.ElementAt(start).Value.Y) * num2;
				}
			}
			else
			{
				vector[array[0]] = base.Frames.ElementAt(start).Value.X;
				vector[array[1]] = base.Frames.ElementAt(start).Value.Y;
			}
			return vector;
		}
	}
}
