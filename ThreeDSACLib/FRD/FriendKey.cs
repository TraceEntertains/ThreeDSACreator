using System.IO;

namespace ThreeDSACLib.FRD
{
    public class FriendKey
    {
        public uint friend_id; // little endian
        public uint unknown; // little endian
        public ulong friend_code; // little endian

        public static bool operator == (FriendKey compare, FriendKey other) {
            return compare.friend_id == other.friend_id;
        }

        public static bool operator != (FriendKey compare, FriendKey other)
        {
            return compare.friend_id != other.friend_id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(FriendKey)) return false;
            return friend_id == ((FriendKey)obj).friend_id;
        }

        public byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(friend_id);
                writer.Write(unknown);
                writer.Write(friend_code);

                return stream.ToArray();
            }
        }
    }
}
