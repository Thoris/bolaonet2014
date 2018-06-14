using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BolaoNet.Database.AppendScripts
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputFileName = "result.sql";

            string[] files = System.IO.Directory.GetFiles("..\\..\\..\\BolaoNet.Database\\build\\dbDeploy\\1.0", "0*.sql");

            if (System.IO.File.Exists(outputFileName))
                System.IO.File.Delete(outputFileName);

            StreamWriter writer = new StreamWriter(outputFileName);

            try
            {
                foreach (string file in files)
                {
                    StreamReader reader = new StreamReader(file);

                    //if (!file.ToLower().StartsWith("out"))
                    {

                        writer.WriteLine("---------------------- " + file + "---------------------- ");
                        writer.WriteLine(reader.ReadToEnd());
                        writer.WriteLine("GO");
                    }
                    
                }
            }
            finally 
            {
                writer.Close();
            }
        }
    }
}
