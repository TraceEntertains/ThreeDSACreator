using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDSACLib.FRD
{
    public class TitleData
    {
        public long tid; // little endian
        public int version; // little endian
        public int unk; // little endian

        public byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(tid);
                writer.Write(version);
                writer.Write(unk);

                return stream.ToArray();
            }
        }
    }
}
