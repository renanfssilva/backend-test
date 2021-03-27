using System.Collections.Generic;

namespace CoinChange.Core.Domain
{
    public class CoinChangeRequest
    {
        public List<long> Sequence { get; set; }
        public long Target { get; set; }

        public CoinChangeRequest()
        {
            Sequence = new List<long>();
        }
    }
}