using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntelectHackathon2022
{
    public class Parser
       {
        public static List<string> coal = new List<string>();
        public static List<string> fish = new List<string>();
        public static List<string> scrap = new List<string>();
        public int numRowsC;
        public int numRowsF;
        public int numRowsS;
        public int vals = 3;
        public string getStepALLowance(string[] data)
        {
            string[] stepallowanceValue = data[0].Split("=");
            return stepallowanceValue[1];
        }
        public string[] getCoal(string[] data)
        {

            string[] Coal = data[1].Split(",");
            numRowsC += int.Parse(Coal[1]);
            int coals = 0;
            for (int i = numRowsC; i < numRowsC; i++)
            {
                coal.Add(data[i]);
                coals++;
            }
            numRowsC = coals+1;
            return coal.ToArray();
        }
        public string[] getFish(string[] data)
        {
            
            string[] Fish = data[numRowsC + 2].Split(",");
            numRowsF = numRowsC + int.Parse(Fish[1]);
            Console.WriteLine("Num rows C " + numRowsC);
            int fishs = 0;
            for (int i = numRowsF; i < numRowsF; i++)
            {
                fish.Add(data[i]);
                fishs++;
            }
            numRowsF = fishs+numRowsC;
            Console.WriteLine("Num rows F " + numRowsF);
            return fish.ToArray();
        }
        public string[] getScrap_Metal(string[] data)
        {
            string[] Scrap = data[numRowsF + 2].Split(",");
            Console.WriteLine(Scrap[0]);
            numRowsS = numRowsF + int.Parse(scrap[0]);
            for (int i = numRowsS; i < numRowsS; i++)
            {
                scrap.Add(data[i]);
            }
            
            return scrap.ToArray();
        }



        public string getQuota(string[] data)
        {
            numRowsS = numRowsC + numRowsF + vals;
            Console.WriteLine("Num rows S " + numRowsS);
            string[] Quota = data[numRowsS + 2].Split("=");
            return Quota[1];
        }
        public string getQuotaM(string[] data)
        {
            string[] QuotaM = data[numRowsS + 3].Split("=");
            return QuotaM[1];
        }
        public string[] getMapSize(string[] data)
        {
            List<string> values = new List<string>();
            string[] MapSize = data[numRowsS + 3].Split("=");
            values.Add(MapSize[1].Split(",")[0]);
            values.Add(MapSize[1].Split(",")[1]);
            Console.WriteLine("Maproe " + MapSize[0].Split(",")[0]);
            return values.ToArray();
        }
        public string[] getMap(string[] data)
        {
            List<string> values = new List<string>();
            string[] MapSize = data[numRowsS + 3].Split("=");
            values.Add(MapSize[1].Split(",")[0]);
            values.Add(MapSize[1].Split(",")[1]);
            string[] mapD = values.ToArray();
            int MapRow = int.Parse(mapD[0]);
            //int MapCol = int.Parse(mapD[1]);
            int Start = numRowsS + 5;
            List<string> Map = new List<string>();
            for (int s = Start; s < MapRow; s++)
            {
                Map.Add("" + data[s].Split(","));
            }




            //List<string> Map = new List<string>();
            //for (int i = ; i < MapRow; i++)
            //{
            //    for (int z = i; z < MapCol; z++)
            //    {
            //        Map.Add("(" + i + "," + z + ")");
            //    }
            //}
            //string[] map = new string[2] { Map.ToArray(), Row.ToArray() };
            //string[] MapSize = data[numRowsS + 5];
            return Map.ToArray();
        }
    }
}
