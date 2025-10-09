using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(1184025u)]
	public class Vector3DOFCompressedChannel : AnimationChannel
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
			foreach (Vector4 value2 in base.Frames.Values)
			{
				Half value = (Half)value2.X;
				output.WriteBytes(HalfExtensions.GetBytes(value));
				value = (Half)value2.Y;
				output.WriteBytes(HalfExtensions.GetBytes(value));
				value = (Half)value2.Z;
				output.WriteBytes(HalfExtensions.GetBytes(value));
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
				Vector3Half vector3Half = new Vector3Half(input, endian);
				value.X = vector3Half.X;
				value.Y = vector3Half.Y;
				value.Z = vector3Half.Z;
			}
		}

		public override Vector4 CalculateValue(float frame)
		{
			Vector4 vector = new Vector4();
			if (GetKey(frame, out var start, out var end))
			{
				float num = frame - (float)(int)base.Frames.Keys.ElementAt(start);
				if (num == 0f)
				{
					vector = base.Frames.ElementAt(start).Value;
				}
				else
				{
					float num2 = num / (float)(base.Frames.Keys.ElementAt(end) - base.Frames.Keys.ElementAt(start));
					vector.X = (base.Frames.ElementAt(end).Value.X - base.Frames.ElementAt(start).Value.X) * num2 + base.Frames.ElementAt(start).Value.X;
					vector.Y = (base.Frames.ElementAt(end).Value.Y - base.Frames.ElementAt(start).Value.Y) * num2 + base.Frames.ElementAt(start).Value.Y;
					vector.Z = (base.Frames.ElementAt(end).Value.Z - base.Frames.ElementAt(start).Value.Z) * num2 + base.Frames.ElementAt(start).Value.Z;
				}
			}
			else
			{
				vector = base.Frames.ElementAt(start).Value;
			}
			return vector;
		}
	}
}
