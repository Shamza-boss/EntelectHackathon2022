using System.Data.Common;
using System.Drawing;
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




    


    

    public class Cell
    {
        public int i { get; }
        public int j { get; }

        public int fcost { get; set; }
        public int Gcost { get; set; }
        public int Hcost { get; set; }
        public bool InClosed { get; set; }
        public Point Origin { get; set; }

        public bool[] borders;
        public Cell(int i, int j, bool[] borders, Point Origin, int FCost, int GCost)
        {
            this.i = i; this.j = j;
            this.Origin = Origin;
            this.borders = borders;
            this.fcost = FCost;
            this.Gcost = GCost;
        }
        public List<Cell> GetNeighbors(Cell[,] cells)
        {
            List<Cell> ls = new List<Cell>();
            if (cells[i, j].borders[0] == false)//top                          
                ls.Add(cells[i, j - 1]);
            if (cells[i, j].borders[1] == false)//right                         
                ls.Add(cells[i + 1, j]);
            if (cells[i, j].borders[2] == false)//bottom                        
                ls.Add(cells[i, j + 1]);
            if (cells[i, j].borders[3] == false)//left                        
                ls.Add(cells[i - 1, j]);

            for (int k = 0; k < ls.Count; k++)
            {
                if (ls[k].Origin == new Point(ls[k].i, ls[k].j))
                {
                    var Fcostnew = FCost(cells);
                    ls[k] = new Cell(ls[k].i, ls[k].j, ls[k].borders, new Point(i, j), 0, 0);
                    ls[k].fcost = Fcostnew[0]; ls[k].Gcost = Fcostnew[1]; ls[k].Hcost = Fcostnew[2];
                    cells[ls[k].i, ls[k].j] = ls[k];
                }
            }
            return ls;
        }
        public Cell UpdateNeighbor(Cell[,] cells, Cell parent)
        {
            var Fcostnew = FCost(cells);
            if (Fcostnew[1] < Gcost)
            {
                Origin = new Point(parent.i, parent.j);
                fcost = Fcostnew[0]; Gcost = Fcostnew[1]; Hcost = Fcostnew[2];
            }
            var res = new Cell(i, j, borders, Origin, fcost, Gcost);
            cells[i, j] = res;
            return res;
        }
        int Herustic(Cell[,] cells,Cell end)
        {
            var c = Math.Abs(i - end.i) + Math.Abs(j - end.j);
            cells[i, j].Hcost = c;
            return c;
        }
        int GCost(Cell[,] cells)
        {
            var g = cells[Origin.X, Origin.Y].Gcost + 1;
            cells[i, j].Gcost = g;
            return g;
        }
        public int[] FCost(Cell[,] cells)
        {
            int[] res = new int[3];
            res[1] = GCost(cells);
            res[2] = Herustic(cells, cells[cells.GetLength(0) - 1, cells.GetLength(1) - 1]);
            res[0] = res[1] + res[2];
            //Console.WriteLine("InFcst... heurist:{0}  gCost:{1}",Herustic(),GCost());
            cells[i, j].fcost = res[0];
            return res;
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