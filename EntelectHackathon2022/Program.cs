namespace EntelectHackathon2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            string[] MapData = fileReader.Read();
            Console.WriteLine(MapData);

            /*
    Score score = new Score();

    int allowance = 5;
    double travelScore = 0;
    bool scout = true;
    int[] difficulty = {0,1,5,5,10,1,1};
    double sum = 0;

    for(int i =0; i<6; i++)
    {
        Console.WriteLine(score.calcScore(difficulty[i],i,5, travelScore, scout, false).ToString());
        sum += score.calcScore(difficulty[i], i, 5, travelScore, scout, false);
    }
    Console.WriteLine((2*(200 + 400 + sum)).ToString()); // 2 fish, + 2 coal, + x2 multiplier
 */
        }
    }
}