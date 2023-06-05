using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDSACLib.Mii
{
    public class ChecksummedMiiData
    {
        private ushort unknown = 0;
        private ushort crc16;
        private byte[] mii_data;

        private void FixChecksum()
        {
            crc16 = CalcChecksum();
        }

        public ChecksummedMiiData(MiiData miiData)
        {
            if (miiData.mii_data_bytes.Length != 0x5c)
                throw new ArgumentException($"The Mii Data provided is invalid, length is {miiData.mii_data_bytes.Length}, expected length is {0x5C}");
            mii_data = miiData.mii_data_bytes;
            FixChecksum();
        }

        public ChecksummedMiiData(byte[] miiData)
        {
            if (miiData.Length != 0x60)
                throw new ArgumentException($"The Mii Data provided is invalid, length is {miiData.Length}, expected length is {0x60}");
            mii_data = miiData;
        }

        public ushort CalcChecksum()
        {
            ushort checksum = 0;
            byte[] data = Serialize();

            for (int i = 0; i < data.Length; i++)
            {
                checksum ^= (ushort)(data[i] << 8);

                for (int j = 0; j < 8; j++)
                {
                    if ((checksum & 0x8000) != 0)
                    {
                        checksum = (ushort)((checksum << 1) ^ 0x1021);
                    }
                    else
                    {
                        checksum <<= 1;
                    }
                }
            }

            return checksum;
        }

        public byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(mii_data);
                writer.Write(unknown);
                writer.Write(crc16);

                return stream.ToArray();
            }
        }
    }
}
