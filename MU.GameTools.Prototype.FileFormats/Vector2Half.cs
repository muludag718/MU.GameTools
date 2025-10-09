using System;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats
{
    public class Vector2Half
    {
        public float X { get; set; }

        public float Y { get; set; }

        public Vector2Half()
        {
        }

        public Vector2Half(Stream input, Endian endian)
        {
            Deserialize(input, endian);
        }

        public void Serialize(Stream output, Endian endian)
        {
            Half value = (Half)X;
            output.WriteBytes(HalfExtensions.GetBytes(value));
            value = (Half)Y;
            output.WriteBytes(HalfExtensions.GetBytes(value));
        }

        public void Deserialize(Stream input, Endian endian)
        {
            ushort bits = input.ReadValueU16(endian);
            X = (float)HalfExtensions.ToHalf(bits);
            ushort bits2 = input.ReadValueU16(endian);
            Y = (float)HalfExtensions.ToHalf(bits2);
        }
    }
}
