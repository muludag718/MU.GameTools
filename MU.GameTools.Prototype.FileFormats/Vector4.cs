using System;
using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats
{
	[TypeConverter(typeof(VectorTypeConverter))]
	public class Vector4
	{
		public float X { get; set; }

		public float Y { get; set; }

		public float Z { get; set; }

		public float W { get; set; }

		public float this[int index]
		{
			get
			{
				return index switch
				{
					0 => X, 
					1 => Y, 
					2 => Z, 
					3 => W, 
					_ => throw new IndexOutOfRangeException(), 
				};
			}
			set
			{
				switch (index)
				{
				case 0:
					X = value;
					break;
				case 1:
					Y = value;
					break;
				case 2:
					Z = value;
					break;
				case 3:
					W = value;
					break;
				default:
					throw new IndexOutOfRangeException();
				}
			}
		}

		public Vector4()
		{
		}

		public Vector4(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public static implicit operator Vector4(Vector3 vec)
		{
			return new Vector4
			{
				X = vec.X,
				Y = vec.Y,
				Z = vec.Z
			};
		}

		public static implicit operator Vector4(Vector2 vec)
		{
			return new Vector4
			{
				X = vec.X,
				Y = vec.Y
			};
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteValueF32(X, endian);
			output.WriteValueF32(Y, endian);
			output.WriteValueF32(Z, endian);
			output.WriteValueF32(W, endian);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			X = input.ReadValueF32(endian);
			Y = input.ReadValueF32(endian);
			Z = input.ReadValueF32(endian);
			W = input.ReadValueF32(endian);
		}

		public static Vector4 QuaternionSlerp(Vector4 q1, Vector4 q2, float delta)
		{
			float num = 1f;
			float num2 = q1.W * q2.W + q1.X * q2.X + q1.Y * q2.Y + q1.Z * q2.Z;
			if (num2 < 0f)
			{
				num = -1f;
				num2 = 0f - num2;
			}
			float num3;
			if (1f - num2 < 0.0027777778f)
			{
				num3 = 1f - delta;
				num *= delta;
			}
			else
			{
				float num4 = (float)Math.Acos(num2);
				float num5 = 1f / (float)Math.Sin(num4);
				num3 = (float)Math.Sin((1f - delta) * num4) * num5;
				num *= (float)Math.Sin(delta * num4) * num5;
			}
			return new Vector4
			{
				W = num3 * q1.W + num * q2.W,
				X = num3 * q1.X + num * q2.X,
				Y = num3 * q1.Y + num * q2.Y,
				Z = num3 * q1.Z + num * q2.Z
			};
		}

		public static explicit operator Vector4(Vector3Half value)
		{
			return new Vector4
			{
				X = value.X,
				Y = value.Y,
				Z = value.Z,
				W = 0f
			};
		}

		public static explicit operator Vector4(Vector2Half value)
		{
			return new Vector4
			{
				X = value.X,
				Y = value.Y,
				Z = 0f,
				W = 0f
			};
		}
	}
}
