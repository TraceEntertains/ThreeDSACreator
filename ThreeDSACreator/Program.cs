using ThreeDSACLib.FRD;

namespace ThreeDSACreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountDataV1 accountDataV1 = new();
            File.WriteAllBytes("test.3dsac", accountDataV1.Serialize());
        }
    }
}