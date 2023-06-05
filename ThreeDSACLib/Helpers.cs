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
    }
}
