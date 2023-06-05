using ThreeDSACLib.FRD;
using ThreeDSParserLib;

namespace ThreeDSACreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountDatParser accountDatParser = new("account.dat");
            
            AccountDataV1 accountDataV1 = new();
            File.WriteAllBytes("test.3dsac", accountDataV1.Serialize(accountDatParser.Parse(), "https://nasc.pretendo.cc/ac/"));
        }
    }
}