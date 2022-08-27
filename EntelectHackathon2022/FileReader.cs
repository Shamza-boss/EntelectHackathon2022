using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntelectHackathon2022
{
    internal class FileReader
    {
        private string[] important = new string[] {};
        //The map folder containing the txt file is in the binary folder in debug
        public static string path = @"C:/Users/clift/source/repos/EntelectHackathon2022/EntelectHackathon2022/EntelectHackathon2022/Map/";

        public string[] Read()
        {
            List<string> list = new List<string>();
            //string to store correct data.
            string[] files = System.IO.Directory.GetFiles(path, "2.txt");
            // Open the text file using a stream reader.
            using (var sr = new StreamReader(files[0]))
            {
                var fullText = sr.ReadToEnd();
                var lineBreakes = fullText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                // Read the stream as a string, and write the string to the console.
                //Console.WriteLine(fullText);
                for (int i = 0; i < lineBreakes.Length; i++)
                {
                    if (lineBreakes[i].Length > 0)
                    {
                        //Console.WriteLine(lineBreakes[i]);
                        list.Add(lineBreakes[i]);

                    }
                    else
                    {
                        //Console.WriteLine(lineBreakes[i] + "empty");
                    }

                }
                important = list.ToArray();
                //Adding list items to array
                //for (int i = 0; i < list.Count; i++)
                //{
                //    Console.WriteLine(list[i]);
                //    important[i] = list[i];
                //}
            }
            foreach(string line in important)
            {
                Console.WriteLine(line);
            }
            
            //Console.WriteLine(important.Length);
            return important;
        }
    }
}
