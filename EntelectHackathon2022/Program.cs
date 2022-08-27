using System.Data.Common;
using System.IO;

namespace EntelectHackathon2022
{
    public enum LANDSCAPE_TYPE { SNOW, ICE, THICK_SNOW, MOUNTAIN }

    public static class Ext
    {
        public static int To1D(this (int x, int y) pair, Vector2int size)
        {
            return pair.y * size.X + pair.x;
        }
    }

    public struct Vector2int
    {
        public int X;
        public int Y;

        public Vector2int(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public struct Landscape
    {
        public string symbol;
        public LANDSCAPE_TYPE type;

        public Landscape(string Symbol,  LANDSCAPE_TYPE type)
        {
            
            symbol = Symbol;
            this.type = type;
        }

        public override string ToString()
        {
            return $"Symbol: {symbol,-3} Type: {type}";
        }
    }







    internal class Program
    {
       
        public LANDSCAPE_TYPE LandscapeType { get; private set; }


        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            string[] MapData = fileReader.Read();
            Console.WriteLine(MapData);
        }

        
        
        void Psuedo()
        {
            //rows = 6
            //columns = 9
            //path = []

            //columnCount = 0

            //for row = 0 To rows - 1

            // add to path([row, columnCount])
            // add to path([row + 1, columnCount])
            // column += 1
            //for column = columnCounter To columns
            // add to path([rows, column])
            //                print {“Party”:[],“Path”: path
            //
            //
            //
            //    }

            
            

            int h = 6, w = 9;
            int columnCount = 0;

            var path = 0;
            
            for (int i = 0; i < h; i++)
            {
                //add to path([row, columnCount])
                //add to path([row + 1, columnCount])
                //column += 1
            }
            for (int i = 0; i < w; i++)
            {
                //add to path ([rows, column])
            }

            Console.WriteLine($"Party: {0} Path: {0}");

        }
    }
}