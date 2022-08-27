using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntelectHackathon2022
{
    public class Parser
    {
        //map x and y length
        public Vector2int MapSize { get; private set; }
        //Stores map data that is converted to int
        public int[] Data { get; private set; }
        //the whole text file
        public string Map { get; private set; }

        public List<Landscape> landscapes { get; private set; }

        public Parser(int textFileNo)
        {
            string[] all = ReadAllTextFiles();

            //choose text file to parse
            ParseText(all[textFileNo]);
        }
        public Parser(string txtName)
        {
            string fullPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..", "maps", txtName);


            ParseText(File.ReadAllText(fullPath));
        }

        void ParseText(string text)
        {
            landscapes = new List<Landscape>();

            int i = 0;

            while (text.Substring(i++, 9) != "map_size=") { }

            i += 8;

            string y = "";
            while (text[i] != ',')
                y += text[i++];

            ++i;

            string x = "";
            while (text[i] != '\n' && text[i] != '\r' && text[i] != ' ')
                x += text[i++];

            MapSize = new Vector2int(int.Parse(x), int.Parse(y));

            while (!char.IsDigit(text[i++])) { }

            --i;

            for (; ; i++)
            {
                if (char.IsDigit(text[i]))
                    Map += text[i];

                if (text[i] == '-')
                    break;
            }

            //go back to one char before start of number and remove extra chars from map
            while (text[--i] != '\n' && text[i] != '\r' && text[i] != ' ')
                Map = Map.Remove(Map.Length - 1);

            Data = GetData(Map, 3);

            ++i;

            //landscape
            for (; ; )
            {
                string start = "", stop = "", type = "";


                while (text[i] != '-')
                {
                    if (i == text.Length - 1) return;

                    start += text[i++];
                }

                ++i;

                while (char.IsDigit(text[i]))
                    stop += text[i++];


                //go to type
                while (text[i++] == ' ') { }

                --i;

                for (; i < text.Length && text[i] != '\n' && text[i] != '\r'; i++)
                {
                    type += text[i];

                    if (i == text.Length - 1)
                    {
                        //landscapes.Add(new Landscape((int.Parse(start), int.Parse(stop)), string.Join("", type.Split(' ').Select(s => s[0])), type));

                        return;
                    }
                }
                //landscapes.Add(new Landscape((int.Parse(start), int.Parse(stop)), string.Join("", type.Split(' ').Select(s => s[0])), type));
            }

            //for (int k = 0; k < landscapeTypes.Count; k++)
            //{
            //    Console.WriteLine(landscapeTypes[k].ToString());
            //}

            //Console.WriteLine(map);  
        }

        string[] ReadAllTextFiles()
        {
            string[] filePaths = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"..\..\..", "maps"), "*.txt");

            string[] all = new string[filePaths.Length];

            for (int i = 0; i < filePaths.Length; i++)
            {
                all[i] = File.ReadAllText(filePaths[i]);
            }

            return all;

            //if (FullPath == "")
            //    path = Path.Combine(Environment.CurrentDirectory, @"..\..", path);
            //else
            //    path = FullPath;


            //string text = File.ReadAllText(path);     
        }

        int[] GetData(string map, int numberLength)
        {
            return Enumerable.Range(0, map.Length / numberLength).Select(i => map.Substring(i * numberLength, numberLength)).Select(s => int.Parse(s)).ToArray();
        }

        public void PrintData(LANDSCAPE_TYPE type)
        {
            Console.WriteLine();
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int k = 0; k < MapSize.X; k++)
                Console.Write($"{k,-4}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n");

            for (int y = 0; y < MapSize.Y; y++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write($"{y,-4}");
                Console.BackgroundColor = ConsoleColor.Black;

                for (int x = 0; x < MapSize.X; x++)
                {
                    int i = (x, y).To1D(MapSize);

                    //if (Data[i] >= landscapes[(int)type].elevationRange.min && Data[i] <= landscapes[(int)type].elevationRange.max)
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Black;
                    //    Console.BackgroundColor = ConsoleColor.Red;
                    //}


                    Console.Write($"{Data[i],-4}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                Console.WriteLine("\n");
            }
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int k = 0; k < MapSize.X; k++)
                Console.Write($"{k,-4}");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("\n\n");
        }
    }
}
