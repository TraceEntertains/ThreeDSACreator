using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDSParserLib
{
    public class AccountDatParser
    {
        private string FilePath;
        
        public AccountDatParser(string filePath)
        {
            FilePath = filePath;
        }

        public Dictionary<string, string> Parse()
        {
            Dictionary<string, string> dict = new();
            using (FileStream file = File.OpenRead(FilePath))
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string line = sr.ReadLine()!;
                        string[] entry = line.Split('=');
                        if (entry.Length > 1)
                        {
                            dict.Add(entry[0].Trim(), entry[1].Trim());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalid entry detected, skipping, Exception: {ex.Message}");
                    }
                }
            }
            return dict;
        }
    }
}
