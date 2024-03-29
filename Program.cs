using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace thirtyseven
{
    class Program
    {
        static void Main(string[] args)
        {
            engine thirtySeven = new engine();
            List<Stats> stats = new List<Stats>();

            List<int> iterationAccuracy = new List<int>();
            for(int ct = 0; ct < 25; ct++)
            {
                stats.Clear();
                for (int i = 0; i < 100; i++)
                {
                    stats.Add(thirtySeven.Execute());
                }
                iterationAccuracy.Add(stats.Where(x => x.won == true).Count());
            
                Console.Clear();
                Console.WriteLine("Iterations: " + iterationAccuracy.Count());
                double avg = iterationAccuracy.Average();
                double stddev = Math.Sqrt(iterationAccuracy.Average(v=>Math.Pow(v-avg,2)));
                Console.WriteLine("Average: " + avg);
                Console.WriteLine("Std. Dev: " + stddev);
                Console.WriteLine();
                Console.WriteLine("Example stats: ");
                engine.printStats(stats.First());
            }
        }
    }
}


