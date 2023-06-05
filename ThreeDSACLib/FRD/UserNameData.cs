using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDSACLib.FRD
{
    public class UserNameData
    {
        public ushort[] user_name = new ushort[11]; // little endian
        public byte is_bad_word = 0;
        public byte unknown = 0;
        public uint bad_word_ver = 0; // little endian

        public byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                foreach (ushort namebyte in user_name)
                {
                    writer.Write(Helpers.ToLittleEndian(namebyte));
                }
                writer.Write(is_bad_word);
                writer.Write(unknown);
                writer.Write(Helpers.ToLittleEndian(bad_word_ver));

                return stream.ToArray();
            }
        }
    }
}
