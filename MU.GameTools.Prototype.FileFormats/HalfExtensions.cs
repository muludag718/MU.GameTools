using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.FileFormats;

public static class HalfExtensions
{
    // float veya double'dan Half'e dönüşüm
    public static byte[] GetBytes(Half value)
    {
        // Half doğrudan BitConverter ile desteklenmiyor, önce float'a çevir
        return BitConverter.GetBytes((float)value);
    }

    // float veya double'dan Half'e dönüştürme
    public static Half ToHalf(float value) => (Half)value;
    public static Half ToHalf(double value) => (Half)value;
    public static Half ToHalf(ushort bits)
    {
        // BitConverter veya MemoryMarshal kullanarak
        return MemoryMarshal.Cast<ushort, Half>(new ushort[] { bits })[0];
    }
}