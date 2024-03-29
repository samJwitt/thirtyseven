using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace thirtyseven
{
    class Program
    {
        static void Main(string[] args)
        {
            double iterations = 1000000;

            Engine thirtySeven = new Engine();
            List<Stats> stats = new List<Stats>();
            for (int i = 0; i < iterations; i++)
            {
                stats.Add(thirtySeven.Execute());
            }
            double averageAccuracy = stats.Where(x => x.won == true).Count() / iterations;
        
            Console.Clear();
            Console.WriteLine("Iterations: " + iterations);
            Console.WriteLine("Average: " + averageAccuracy * 100 + "%");
            Console.WriteLine();
            Console.WriteLine("Example stats: ");
            Engine.printStats(stats.First(x => x.won == true));
        }
    }
}


