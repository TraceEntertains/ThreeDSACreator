namespace ThreeDSACLib.FRD
{
    public class FriendInfo
    {
        public FriendKey friend_key;
        public long account_creation_timestamp; // little endian
        public byte relationship;
        public byte[] padding1 = new byte[3];
        public uint padding2; // little endian
        public FriendProfile friend_profile;
        public TitleData favorite_game;
        public uint principal_ID; // little endian
        public ushort[] comment = new ushort[AccountDataV1.FRIEND_COMMENT_SIZE]; // little endian
        public ushort padding3; // little endian
        public long last_online_timestamp; // little endian
        public ushort[] screen_name = new ushort[AccountDataV1.FRIEND_SCREEN_NAME_SIZE];
        public byte font_region;
        public byte padding4;
        public Mii.ChecksummedMiiData mii_data;
    }
}
