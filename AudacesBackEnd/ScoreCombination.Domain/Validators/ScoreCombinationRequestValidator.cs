using System;
using System.Collections.Generic;
using System.Linq;
using ScoreCombination.Domain.Entities;
using ScoreCombination.Domain.Interfaces.Validators;

namespace ScoreCombination.Domain.Validators
{
    public class ScoreCombinationRequestValidator : IScoreCombinationRequestValidator
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
