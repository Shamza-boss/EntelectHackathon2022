namespace EntelectHackathon2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            string[] MapData = fileReader.Read();
            //for(int i = 0; i < MapData.Length; i++)
            //{
            //    Console.WriteLine(MapData[i]);
            //}
            

            IndexingComponents indexingComponents = new IndexingComponents();
            string stepAll = indexingComponents.getStepALLowance(MapData);
            string[] Coal = indexingComponents.getCoal(MapData);
            string[] Fish = indexingComponents.getFish(MapData);
            string[] scrap = indexingComponents.getScrap_Metal(MapData);
            string[] Quaota = indexingComponents.getQuota(MapData);
            string[] QuoataM = indexingComponents.getQuotaM(MapData);
            string[] mapSize = indexingComponents.getMapSize(MapData);
            //string[] Map = indexingComponents.getMap(MapData);

            //string 
            Console.WriteLine(stepAll);
            //Console.WriteLine(Coal[0]);
            //Console.WriteLine(Fish[0]);
            //Console.WriteLine(scrap[0]);
            //Console.WriteLine(Quaota[0]);
            //Console.WriteLine(QuoataM[0]);
            //Console.WriteLine(mapSize[0]);
            //Console.WriteLine(Map[0]);
        }
    }
}