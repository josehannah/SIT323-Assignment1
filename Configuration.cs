using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment1SIT323
{
    class Configuration
    {
        public string LogFileName { get; set; }

        public List<string> Errors { get; set; }

        public bool Validate(string getCffFilename)
        {
            LogFileName = null;
            Errors = new List<string>();

            StreamReader sr = new StreamReader(getCffFilename);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                line = line.Trim();

                // Check for empty line
                if (line.Length == 0)
                {
                    // Skip
                }
                else if (line.StartsWith("//"))
                {
                    // Skip
                }
                else if (line.StartsWith("DEFAULT-LOGFILE"))
                {
                    string[] data = line.Split("=");
                    if (data.Length == 2)
                    {
                        LogFileName = data[1].Trim('"');

                        if (LogFileName.Length > 0)
                        {
                            // Invalid characters in CFFFileName
                            if (LogFileName.IndexOfAny(Path.GetInvalidPathChars()) == -1)
                            {
                                string path = Path.GetDirectoryName(getCffFilename);
                                LogFileName = path + Path.DirectorySeparatorChar + LogFileName;
                            }
                            else
                            {
                                // Error
                                Errors.Add("Invalid characters");

                            }
                        }
                        else
                        {
                            // Error
                            Errors.Add("No file name found");

                        }
                    }
                    else
                    {
                        // Error
                        Errors.Add("No value for keyboard");

                    }

                }

            }

            sr.Close();

            return (Errors.Count == 0);

        }
    }
}