using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDSACLib.FRD
{
    public class FriendProfile
    {
        public byte region;
        public byte country;
        public byte area;
        public byte language;
        public byte[] padding = new byte[3];

        public byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(region);
                writer.Write(country);
                writer.Write(area);
                writer.Write(language);
                writer.Write(padding);

                return stream.ToArray();
            }
        }
    }
}
