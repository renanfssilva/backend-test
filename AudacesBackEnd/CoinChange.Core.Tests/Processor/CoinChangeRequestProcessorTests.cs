using System;
using System.Collections.Generic;
using System.Linq;
using CoinChange.Core.Domain;
using Xunit;

namespace CoinChange.Core.Processor
{
    public class CoinChangeRequestProcessorTests
    {
        private readonly CoinChangeRequestProcessor _processor;

        public CoinChangeRequestProcessorTests()
        {
            _processor = new CoinChangeRequestProcessor();
        }

        [Fact]
        public void ShouldReturnCoinChangeResultWithRequestValues()
        {
            var request = new CoinChangeRequest
            {
                Sequence =  new List<long> {5, 20, 2, 1},
                Target = 47
            };

            var result = _processor.CoinChange(request);

            Assert.NotNull(result);
            Assert.NotNull(result.Combination);
            Assert.Equal(request.Target, result.Combination.Sum());
        }

        [Fact]
        public void ShouldReturnEmptyListWithWrongRequestValues()
        {
            var request = new CoinChangeRequest
            {
                Sequence =  new List<long> {5, 20},
                Target = 47
            };

            var result = _processor.CoinChange(request);

            Assert.NotNull(result);
            Assert.NotNull(result.Combination);
            Assert.Equal(new List<long>(), result.Combination);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.CoinChange(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestSequenceIsEmpty()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _processor.CoinChange(new CoinChangeRequest()));

            Assert.Equal("Sequence contains no elements", exception.Message);
        }

    }
}
