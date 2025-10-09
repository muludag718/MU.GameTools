using System.Collections.Generic;
using System.IO;
using System.Linq;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	public abstract class AnimationChannel : BaseNode
	{
		public uint Version { get; set; }

		public string TranslationType { get; set; }

		public uint NumberOfFrames { get; set; }

		public ushort Mapping { get; set; }

		public Dictionary<ushort, Vector4> Frames { get; set; }

		public Vector3 BaseValues { get; set; }

		public bool ContainsAnimData => NumberOfFrames != 0;

		public override string ToString()
		{
			if (string.IsNullOrEmpty(TranslationType))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + TranslationType.Trim(default(char)) + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version);
			output.WriteString(TranslationType);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			TranslationType = input.ReadString(4);
		}

		public virtual void ReadFrames(byte[] animationData)
		{
			if (!ContainsAnimData)
			{
				MemoryStream memoryStream = new MemoryStream(animationData);
				AnimationDataReference childNode = GetChildNode<AnimationDataReference>();
				memoryStream.Position = childNode.Offset;
				NumberOfFrames = childNode.Frames;
				Frames = new Dictionary<ushort, Vector4>();
				for (int i = 0; i < NumberOfFrames; i++)
				{
					Frames.Add(memoryStream.ReadValueU16(), new Vector4());
				}
				if (NumberOfFrames % 2 != 0)
				{
					memoryStream.ReadBytes(2);
				}
				ReadChannel(memoryStream, Endian.Little);
			}
		}

		protected virtual bool GetKey(float frame, out int start, out int end)
		{
			if (frame < (float)(int)Frames.Keys.First())
			{
				start = (end = 0);
				return false;
			}
			if (frame >= (float)(int)Frames.Keys.Last())
			{
				start = (end = Frames.Keys.Count - 1);
				return false;
			}
			int num = 0;
			int num2 = Frames.Keys.Count - 1;
			int num3 = num2 / 2;
			while (!(frame >= (float)(int)Frames.Keys.ElementAt(num3)) || !(frame < (float)(int)Frames.Keys.ElementAt(num3 + 1)))
			{
				if ((float)(int)Frames.Keys.ElementAt(num3) < frame)
				{
					num = num3 + 1;
				}
				else if ((float)(int)Frames.Keys.ElementAt(num3) > frame)
				{
					num2 = num3 - 1;
				}
				num3 = (num + num2) / 2;
			}
			start = num3;
			end = num3 + 1;
			return true;
		}

		protected abstract void ReadChannel(Stream input, Endian endian);

		public abstract Vector4 CalculateValue(float frame);
	}
}
