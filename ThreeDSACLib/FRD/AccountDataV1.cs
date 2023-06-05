using System.Text;
using ThreeDSACLib;

namespace ThreeDSACLib.FRD
{
    public class AccountDataV1
    {
        static readonly uint FRIEND_SCREEN_NAME_SIZE = 0xB;            ///< 11-short UTF-16 screen name
        static readonly uint FRIEND_COMMENT_SIZE = 0x11;               ///< 17-short UTF-16 comment
        static readonly uint FRIEND_GAME_MODE_DESCRIPTION_SIZE = 0x80; ///< 128-short UTF-16 description
        static readonly uint FRIEND_LIST_SIZE = 0x64;

        static readonly uint MAGIC_VALUE = 0x54444146;
        static readonly uint VERSION_VALUE = 0x1;

        public uint magic = MAGIC_VALUE; // file magic (little endian)
        public uint version = VERSION_VALUE; // file version (little endian)
        public uint reserved = 0; // unknown (little endian)
        public uint checksum = 0; // unknown (little endian)
        public UserNameData device_name = new();
        public uint padding1 = 0; // padding (little endian)
        public char[] password = new char[0x20]; // NEX Password (found in friends list save
        public char[] pid_HMAC = new char[0x10]; // PrincipalID HMAC (found in friends list save, account file, offset 0x42)
        public char[] serial_number = new char[0x10]; // 3ds serial I guess
        public byte[] mac_address = new byte[6]; // 3ds mac address in bytes
        public ushort padding2 = 0; // more padding (little endian)
        public byte[] device_cert = new byte[0x110]; // device certificates, unknown location, maybe size 0x180?
        public char[] nasc_url = new char[0x20];
        public byte[] ctr_common_prod_cert = new byte[0x4E0];
        public byte[] ctr_common_prod_key = new byte[0x4C0];
        public FriendKey my_key = new();
        public byte my_pref_public_mode = 0;
        public byte my_pref_public_game_name = 0;
        public byte my_pref_public_played_game = 0;
        public byte padding3 = 0;
        public FriendProfile my_profile = new();
        public ushort[] my_screen_name = new ushort[FRIEND_SCREEN_NAME_SIZE]; // little endian
        public ushort padding4 = 0; // little endian
        public Mii.ChecksummedMiiData my_mii_data = new();
        public uint padding5 = 0; // little endian
        public TitleData my_fav_game = new();
        public ushort[] my_comment = new ushort[FRIEND_COMMENT_SIZE]; // little endian
        public ushort my_friend_count = 0; // little endian
        public uint padding6 = 0; // little endian
        public FriendInfo[] friend_info = new FriendInfo[FRIEND_LIST_SIZE];

        public byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(Helpers.ToLittleEndian(magic));
                writer.Write(Helpers.ToLittleEndian(version));
                writer.Write(Helpers.ToLittleEndian(reserved));
                writer.Write(Helpers.ToLittleEndian(checksum));
                writer.Write(device_name.Serialize());
                writer.Write(Helpers.ToLittleEndian(padding1));
                writer.Write(Encoding.Unicode.GetBytes(password));
                writer.Write(Encoding.Unicode.GetBytes(pid_HMAC));
                writer.Write(Encoding.Unicode.GetBytes(serial_number));
                writer.Write(mac_address);
                writer.Write(Helpers.ToLittleEndian(padding2));
                writer.Write(device_cert);
                writer.Write(Encoding.Unicode.GetBytes(nasc_url));
                writer.Write(ctr_common_prod_cert);
                writer.Write(ctr_common_prod_key);
                writer.Write(my_key.Serialize());
                writer.Write(my_pref_public_mode);
                writer.Write(my_pref_public_game_name);
                writer.Write(my_pref_public_played_game);
                writer.Write(padding3);
                writer.Write(my_profile.Serialize());
                foreach (ushort screenNameChar in my_screen_name)
                {
                    writer.Write(Helpers.ToLittleEndian(screenNameChar));
                }
                writer.Write(Helpers.ToLittleEndian(padding4));
                //writer.Write(my_mii_data.Serialize());
                writer.Write(Helpers.ToLittleEndian(padding5));
                //writer.Write(my_fav_game.Serialize());
                foreach (ushort commentChar in my_comment)
                {
                    writer.Write(Helpers.ToLittleEndian(commentChar));
                }
                writer.Write(Helpers.ToLittleEndian(my_friend_count));
                writer.Write(Helpers.ToLittleEndian(padding6));
                foreach (FriendInfo friendInfo in friend_info)
                {
                    //writer.Write(friendInfo.Serialize());
                }

                return stream.ToArray();
            }
        }
    }
}
