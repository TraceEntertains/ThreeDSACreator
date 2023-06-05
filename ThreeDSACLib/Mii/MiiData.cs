namespace ThreeDSACLib.Mii
{
    public class MiiData
    {
        public byte[] mii_data_bytes;

        public MiiData(byte[] miiData)
        {
            Console.WriteLine("WARNING: Due to C#'s lack of proper bitfields, this class is currently incomplete (STUBBED).");
            if (miiData.Length != 0x5C)
                throw new ArgumentException($"The Mii Data provided is invalid, length is {miiData.Length}, expected length is {0x5C}");
            mii_data_bytes = miiData;
        }

        public byte[] Serialize()
        {
            /*using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write("amongus");

            
            }*/
            return mii_data_bytes;
        }
    }
}
