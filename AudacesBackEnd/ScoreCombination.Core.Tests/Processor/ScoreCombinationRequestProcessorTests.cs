using System;
using System.Collections.Generic;
using System.Linq;
using ScoreCombination.Core.Domain;
using ScoreCombination.Core.Processor;
using Xunit;

namespace ScoreCombination.Core.Tests.Processor
{
    public class ScoreCombinationRequestProcessorTests
    {
        private readonly ScoreCombinationRequestProcessor _processor;

        public ScoreCombinationRequestProcessorTests()
        {
            _processor = new ScoreCombinationRequestProcessor();
        }

        [Fact]
        public void ShouldReturnCoinChangeResultWithRequestValues()
        {
            var request = new ScoreCombinationRequest
            {
                Sequence = new List<long> { 5, 20, 2, 1 },
                Target = 47
            };

            var result = _processor.GetCombination(request);

            Assert.NotNull(result);
            Assert.NotNull(result.Combination);
            Assert.Equal(request.Target, result.Combination.Sum());
        }

        [Fact]
        public void ShouldReturnEmptyListWithWrongRequestValues()
        {
            var request = new ScoreCombinationRequest
            {
                Sequence = new List<long> { 5, 20 },
                Target = 47
            };

            var result = _processor.GetCombination(request);

            Assert.NotNull(result);
            Assert.NotNull(result.Combination);
            Assert.Equal(new List<long>(), result.Combination);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.GetCombination(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestSequenceIsEmpty()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _processor.GetCombination(new ScoreCombinationRequest()));

            Assert.Equal("Sequence contains no elements", exception.Message);
        }

        [Fact]
        public void ShouldThrowExceptionIfTargetIsPositiveAndSequenceIsEmptyOrZero()
        {
            var request = new ScoreCombinationRequest()
            {
                Sequence = new List<long> { 0 },
                Target = 20
            };

            var exception = Assert.Throws<ArgumentException>(() => _processor.GetCombination(request));

            Assert.Equal("Target is unreachable with the sequence entered", exception.Message);
        }

        [Fact]
        public void ShouldThrowExceptionIfTargetIsPositiveAndSequenceJustHasNegativeNumbers()
        {
            var request = new ScoreCombinationRequest()
            {
                Sequence = new List<long> {-2, -5},
                Target = 10
            };

            var exception = Assert.Throws<ArgumentException>(() => _processor.GetCombination(request));

            Assert.Equal("Target is unreachable with the sequence entered", exception.Message);
        }
    }
}
