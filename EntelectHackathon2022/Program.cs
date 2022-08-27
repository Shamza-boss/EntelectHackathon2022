namespace EntelectHackathon2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            string[] MapData = fileReader.Read();
            Console.WriteLine(MapData);
        }
    }
}