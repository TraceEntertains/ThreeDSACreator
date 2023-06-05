using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDSACLib
{
    public static class Helpers
    {
        // Helper method to convert a value to little endian
        public static uint ToLittleEndian(uint value)
        {
            if (BitConverter.IsLittleEndian)
                return value;

            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);

            return BitConverter.ToUInt32(bytes, 0);
        }

        public static ushort ToLittleEndian(ushort value)
        {
            if (BitConverter.IsLittleEndian)
                return value;

            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);

            return BitConverter.ToUInt16(bytes, 0);
        }

        public static byte[] StringBytesToByteArray(string stringInput)
        {
            string byteString = stringInput;
            byte[] bytes = new byte[byteString.Length / 2];

            for (int i = 0; i < byteString.Length; i += 2)
            {
                string byteHex = byteString.Substring(i, 2);
                bytes[i / 2] = Convert.ToByte(byteHex, 16);
            }

            return bytes;
        }

        public static ushort[] StringBytesToUShortArray(string stringInput)
        {
            string byteString = stringInput;
            ushort[] ushorts = new ushort[byteString.Length / 4];

            for (int i = 0; i < byteString.Length; i += 4)
            {
                string byteHex = byteString.Substring(i, 4);
                ushorts[i / 4] = Convert.ToByte(byteHex, 16);
            }

            return ushorts;
        }
    }
}
