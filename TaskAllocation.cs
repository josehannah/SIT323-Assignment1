using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment1SIT323
{
    class TaskAllocation
    {
        // public string EffFilename { get; set; }

        List<string> Errors { get; set; }
        public string CffFilename { get; set; }

        public static readonly string[] KEYWORDS = { "ALLOCATIONS-DATA", "ALLOCATION-ID" };

        private void GetAllocationData(string line)
        {
            if (line == KEYWORDS[0])
            {
                Console.WriteLine("This line contains Allocation data");
            }

            if (line == KEYWORDS[1])
            {
                Console.WriteLine("This line contains Allocation ID");
                Console.WriteLine("Following this line are allocations");
            }
        }

        public Boolean GetCffFilename(string taffFilename)
        {
            CffFilename = null;
            Errors = new List<string>();

            StreamReader sr = new StreamReader(taffFilename);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                line = line.Trim();

                if (line.StartsWith("CONFIG-FILE"))
                {
                    string[] data = line.Split('=');

                    if (data.Length == 2)
                    {
                        CffFilename = data[1].Trim('"');

                        if (CffFilename.Length > 0)
                        {
                            // Invalid characters in CffFilename
                            if (CffFilename.IndexOfAny(Path.GetInvalidFileNameChars()) == -1)
                            {
                                string path = Path.GetDirectoryName(taffFilename);
                                CffFilename = path + Path.DirectorySeparatorChar + CffFilename;
                            }
                            else
                            {
                                Errors.Add("Invalid characters");
                            }
                        }
                        else
                        {
                            Errors.Add("No file name founded");
                        }
                    }
                    else
                    {
                        Errors.Add("No value for keyboard");
                    }
                }
            }

            sr.Close();
            return (Errors.Count == 0);
        }

        public Boolean Validate (string taffFilename)
        {
            Errors = new List<string>();

            return (Errors.Count == 0);
        }
    }
}