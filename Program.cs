using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace thirtyseven
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 1000;
            engine thirtySeven = new engine();
            List<Stats> stats = new List<Stats>();
            for (int i = 0; i < 1000; i++)
            {
                stats.Add(thirtySeven.Execute());
            }
            double averageAccuracy = stats.Where(x => x.won == true).Count() * .10;
        
            Console.Clear();
            Console.WriteLine("Iterations: " + iterations);
            Console.WriteLine("Average: " + averageAccuracy);
            Console.WriteLine();
            Console.WriteLine("Example stats: ");
            engine.printStats(stats.First(x => x.won == true));
        }
    }
}


