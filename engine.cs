namespace thirtyseven
{
    public class Engine
    {
        public Engine(){}
        public Stats Execute()
        {
            const int nThirtySeven = 37;
            int rngCeiling = getRngCeiling();
            int[] selectionArray = generateSelectionArray(rngCeiling);

            var highestFromControlCap = maxFromFirst(selectionArray, nThirtySeven);
            int acceptedIdx = -1;
            for (int i = nThirtySeven; i<100; i++)
            {
                if (selectionArray[i] > highestFromControlCap)
                {
                    acceptedIdx = i;
                    break;
                }
            }

            return makeStats(selectionArray, acceptedIdx, rngCeiling);
        }

        private static int getRngCeiling()
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

            return Array.IndexOf(selectionSorted, value) + 1;
        }

        private static int maxFromFirst(int[] selection, int cap)
        {
            return selection.Take(cap).ToArray().Max();
        }

        private static Stats makeStats(int[] selection, int acceptedIdx, int rCap)
        {
            return new Stats()
            {
                selectedValue = acceptedIdx > -1 ? selection[acceptedIdx] : null,
                highestFromFirstThirtySeven = maxFromFirst(selection, 37),
                highestValue = selection.Max(),
                selectedRanking = acceptedIdx > -1 ? ranking(selection, acceptedIdx) : null,
                topTen = selection.OrderDescending().Take(10).ToArray(),
                cap = rCap
            };  
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
        }
    }
}