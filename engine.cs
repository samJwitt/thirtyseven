
using System.Text.Json.Serialization;

namespace thirtyseven
{
    public class engine
    {
        public engine(){}
        public Stats Execute()
        {
            const int nThirtySeven = 37;
            int rCap = randomCap();
            int[] selection = generateSelectionArray(rCap);

            var highestFromControlCap = maxFromFirst(selection, nThirtySeven);
            int acceptedIdx = -1;
            for (int i = nThirtySeven; i<100; i++)
            {
                if (selection[i] > highestFromControlCap)
                {
                    acceptedIdx = i;
                    break;
                }
            }

            return makeStats(selection, acceptedIdx, rCap);
        }

        private static int randomCap()
        {
            return new Random().Next(101,1000);
        }

        private static int[] generateSelectionArray(int maxValue)
        {
            int[] selection = new int[100];
            Random random = new Random();

            for (int idx = 0; idx<100; idx++)
            {
                bool searching = true;
                do
                {
                    var candidate = random.Next(1,maxValue);
                    if (!selection.Contains(candidate))
                    {
                        selection[idx] = candidate;
                        searching = false;
                    }
                }
                while(searching);
            }
            
            return selection;
        }

        private static int ranking(int[] selection, int idx)
        {
            int value = selection[idx];
            var selectionSorted = selection.OrderDescending().ToArray();

            int sortedIdx = Array.IndexOf(selectionSorted, value);

            return sortedIdx + 1;
        }

        private static int maxFromFirst(int[] selection, int cap)
        {
            var capped = selection.Take(cap).ToArray();
            return capped.Max();
        }

        private static Stats makeStats(int[] selection, int acceptedIdx, int rCap)
        {
            Stats stats = new Stats();

            stats.selectedValue = acceptedIdx > -1 ? selection[acceptedIdx] : null;
            stats.highestFromFirstThirtySeven = maxFromFirst(selection, 37);
            stats.highestValue = selection.Max();
            stats.selectedRanking = acceptedIdx > -1 ? ranking(selection, acceptedIdx) : null;
            stats.topTen = selection.OrderDescending().Take(10).ToArray();
            stats.cap = rCap;
            stats.won = stats.selectedValue == stats.highestValue;

            return stats;
        }

        public static void printStats(Stats stats)
        {
            if (stats.selectedValue.HasValue)
            {
                Console.WriteLine("Won: " + stats.won);
                Console.WriteLine("Cap: " + stats.cap);
                Console.WriteLine("Highest from first 37: " + stats.highestFromFirstThirtySeven);
                Console.WriteLine("Selected: " + stats.selectedValue ?? "None / Impossible Game");
                Console.WriteLine("Highest: " + stats.highestValue);
                Console.WriteLine("Selected Rank: " + stats.selectedRanking ?? "N/A");
                Console.WriteLine("Top Ten: " + string.Join(", ", stats.topTen));
            }
            else
            {
                Console.WriteLine("Impossible game. Highest in first 37.");
            }
            Console.WriteLine("---------------------------------------------");
        }
    }
}