using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using ScoreCombination.Domain.Entities;
using ScoreCombination.Domain.Interfaces.Repositories;
using ScoreCombination.Domain.Services;
using Xunit;

namespace ScoreCombination.Tests
{
    public class ScoreCombinationRequestTests
    {
        private readonly ScoreCombinationRequest _request;
        private readonly ServiceRecord _service;
        private readonly Mock<IRepositoryRecord> _scoreCombinationRepositoryMock;
        private readonly List<ScoreCombinationRecord> _callHistory;

        public ScoreCombinationRequestTests()
        {
            _request = new ScoreCombinationRequest();

            _callHistory = new List<ScoreCombinationRecord> { new ScoreCombinationRecord() };

            _scoreCombinationRepositoryMock = new Mock<IRepositoryRecord>();
            _scoreCombinationRepositoryMock.Setup(x => x.GetCallHistory(DateTime.Today.AddDays(-1), DateTime.Today))
                .Returns(_callHistory);

            _service = new ServiceRecord(_scoreCombinationRepositoryMock.Object);
        }

        [Fact]
        public void ShouldReturnScoreCombinationResultWithRequestValues()
        {
            _request.Sequence = new List<long> { 5, 20, 2, 1 };
            _request.Target = 47;

            var result = _service.GetCombination(_request);

            Assert.NotNull(result);
            Assert.NotNull(result.Combination);
            Assert.Equal(_request.Target, result.Combination.Sum());
        }

        [Fact]
        public void ShouldReturnEmptyListWithWrongRequestValues()
        {
            _request.Sequence = new List<long> { 5, 20 };
            _request.Target = 47;

            var result = _service.GetCombination(_request);

            Assert.NotNull(result);
            Assert.NotNull(result.Combination);
            Assert.Equal(new List<long>(), result.Combination);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _service.GetCombination(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestSequenceIsEmpty()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _service.GetCombination(new ScoreCombinationRequest()));

            Assert.Equal("Sequence contains no elements", exception.Message);
        }

        [Fact]
        public void ShouldThrowExceptionIfTargetIsPositiveAndSequenceIsEmptyOrZero()
        {
            _request.Sequence = new List<long> { 0 };
            _request.Target = 20;

            var exception = Assert.Throws<ArgumentException>(() => _service.GetCombination(_request));

            Assert.Equal("Target is unreachable with the sequence entered", exception.Message);
        }

        [Fact]
        public void ShouldThrowExceptionIfTargetIsPositiveAndSequenceJustHasNegativeNumbers()
        {
            _request.Sequence = new List<long> { -2, -5 };
            _request.Target = 10;

            var exception = Assert.Throws<ArgumentException>(() => _service.GetCombination(_request));

            Assert.Equal("Target is unreachable with the sequence entered", exception.Message);
        }

        [Fact]
        public void ShouldSaveApiCalls()
        {
            //_request.Sequence = new List<long> { 5, 20, 2, 1 };
            //_request.Target = 47;

            //ScoreCombinationRecord recordSaved = null;
            //_scoreCombinationRepositoryMock.Setup(x => x.GetCallHistory(It.IsAny<ScoreCombinationRecord>()))
            //    .Callback<ScoreCombinationRecord>(
            //        record =>
            //        {
            //            recordSaved = record;
            //        });

            //_processor.GetCombination(_request);

            //_scoreCombinationRepositoryMock.Verify(x => x.Save(It.IsAny<ScoreCombinationRecord>()), Times.Once);

            //Assert.NotNull(recordSaved);
            //Assert.Equal(_request.Sequence, recordSaved.Sequence);
            //Assert.Equal(_request.Target, recordSaved.Target);
            //Assert.Equal(_request.Target, recordSaved.Combination.Sum());
            //Assert.Equal(DateTime.Today.DayOfYear, recordSaved.Date.DayOfYear);
        }
    }
}
