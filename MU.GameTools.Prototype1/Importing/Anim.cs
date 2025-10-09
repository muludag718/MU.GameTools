using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D;

namespace MU.GameTools.Prototype1.Importing
{
	public static class Anim
	{
		public static byte[] UncompressAnimationData(AnimationData animationData)
		{
			if (animationData == null)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream(animationData.CompressedData);
			using DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress);
			memoryStream.Position = 2L;
			byte[] array = new byte[animationData.UncompressedSize];
			deflateStream.Read(array, 0, (int)animationData.UncompressedSize);
			return array;
		}

		public static Dictionary<ushort, FrameData> GetFrameData(AnimationBone bone, byte[] animationData)
		{
			Dictionary<ushort, FrameData> dictionary = new Dictionary<ushort, FrameData>();
			foreach (AnimationChannel childNode in bone.GetChildNodes<AnimationChannel>())
			{
				if (!childNode.ContainsAnimData)
				{
					childNode.ReadFrames(animationData);
				}
				foreach (KeyValuePair<ushort, Vector4> frame in childNode.Frames)
				{
					FrameData frameData = (dictionary.ContainsKey(frame.Key) ? dictionary[frame.Key] : new FrameData());
					if (!dictionary.ContainsKey(frame.Key))
					{
						dictionary.Add(frame.Key, frameData);
					}
					Vector4 vector = childNode.CalculateValue((int)frame.Key);
					switch (childNode.TranslationType)
					{
					case "SCL\0":
						frameData.scale = vector;
						break;
					case "TRAN":
						frameData.location = vector;
						break;
					case "ROT\0":
						frameData.rotation = vector;
						break;
					}
				}
			}
			return dictionary;
		}
	}
}
