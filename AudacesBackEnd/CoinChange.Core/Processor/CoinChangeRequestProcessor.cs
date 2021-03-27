using System;
using System.Linq;
using CoinChange.Core.Domain;

namespace CoinChange.Core.Processor
{
    public class CoinChangeRequestProcessor
    {
        public CoinChangeRequestProcessor()
        {
        }

        public CoinChangeResult CoinChange(CoinChangeRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Sequence.Count == 0)
                throw new InvalidOperationException("Sequence contains no elements");

            var amount = request.Target;
            var result = new CoinChangeResult();

            foreach (var value in request.Sequence.OrderByDescending(x => x))
            {
                if (amount == 0)
                    break;

                var count = amount / value;

                if (count != 0)
                {
                    for (var i = 0; i < count; i++)
                    {
                        result.Combination.Add(value);
                    }
                }

                amount %= value;
            }

            return result.Combination.Sum() == request.Target ? result : new CoinChangeResult();
        }
    }
}