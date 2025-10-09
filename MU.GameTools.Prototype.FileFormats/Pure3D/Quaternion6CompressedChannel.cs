using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(1184018u)]
	public class Quaternion6CompressedChannel : AnimationChannel
	{
		public override void Serialize(Stream output, Endian endian)
		{
			base.Serialize(output, endian);
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
				int num = (int)(value.X * 32767f);
				int num2 = (int)(value.Y * 32767f);
				int num3 = (int)(value.Z * 32767f);
				output.WriteValueS16((short)num);
				output.WriteValueS16((short)num2);
				output.WriteValueS16((short)num3);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			base.Deserialize(input, endian);
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
				value.X = Convert.ToSingle((int)input.ReadValueS16());
				value.Y = Convert.ToSingle((int)input.ReadValueS16());
				value.Z = Convert.ToSingle((int)input.ReadValueS16());
				value.X *= 3.051851E-05f;
				value.Y *= 3.051851E-05f;
				value.Z *= 3.051851E-05f;
				float num = value.X * value.X + value.Y * value.Y + value.Z * value.Z;
				float num2 = 1f - num;
				if (num2 <= 0f)
				{
					value.W = 0f;
				}
				else
				{
					value.W = (float)Math.Sqrt(num2);
				}
			}
		}

		public override Vector4 CalculateValue(float frame)
		{
			if (GetKey(frame, out var start, out var end))
			{
				float num = frame - (float)(int)base.Frames.Keys.ElementAt(start);
				if (num == 0f)
				{
					return base.Frames.ElementAt(start).Value;
				}
				float delta = num / (float)(base.Frames.Keys.ElementAt(end) - base.Frames.Keys.ElementAt(start));
				return Vector4.QuaternionSlerp(base.Frames.ElementAt(start).Value, base.Frames.ElementAt(end).Value, delta);
			}
			return base.Frames.ElementAt(start).Value;
		}
	}
}
