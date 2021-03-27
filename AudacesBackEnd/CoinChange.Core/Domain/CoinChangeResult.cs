using System.Collections.Generic;

namespace CoinChange.Core.Domain
{
    public class CoinChangeResult
    {
        public List<long> Combination { get; set; }

        public CoinChangeResult()
        {
            Combination = new List<long>();
        }
    }
}