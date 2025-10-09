using System;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats
{
    public class Vector3Half
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public Vector3Half()
        {
        }

        public Vector3Half(Stream input, Endian endian)
        {
            Deserialize(input, endian);
        }

        public void Serialize(Stream output, Endian endian)
        {
            Half value = (Half)X;
            output.WriteBytes(HalfExtensions.GetBytes(value));
            value = (Half)Y;
            output.WriteBytes(HalfExtensions.GetBytes(value));
            value = (Half)Z;
            output.WriteBytes(HalfExtensions.GetBytes(value));
        }

        public void Deserialize(Stream input, Endian endian)
        {
            ushort bits = input.ReadValueU16(endian);
            X = (float)HalfExtensions.ToHalf(bits);
            ushort bits2 = input.ReadValueU16(endian);
            Y = (float)HalfExtensions.ToHalf(bits2);
            ushort bits3 = input.ReadValueU16(endian);
            Z = (float)HalfExtensions.ToHalf(bits3);
        }
    }
}
