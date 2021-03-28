using System;
using System.Collections.Generic;
using System.Linq;
using ScoreCombination.Core.Domain;

namespace ScoreCombination.Core.Processor
{
    public class ScoreCombinationRequestValidator
    {
        public void Validate(ScoreCombinationRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Sequence.Count == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }

            if (request.Target > 0 && (request.Sequence.Count == 0 || request.Sequence.SequenceEqual(new List<long> { 0 })))
            {
                throw new ArgumentException("Target is unreachable with the sequence entered");
            }

            if (request.Target > 0 && request.Sequence.TrueForAll(x => x < 0))
            {
                throw new ArgumentException("Target is unreachable with the sequence entered");
            }
        }
    }
}
