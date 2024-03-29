using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace thirtyseven
{
    public class Stats
    {
        public int? selectedValue { get; set; }
        public int highestFromFirstThirtySeven { get; set; }
        public int highestValue { get; set; }
        public int? selectedRanking { get; set; }
        public bool won => selectedValue == highestValue;
        public int[] topTen { get; set; }
        public int cap { get; set; }
        
    }
}