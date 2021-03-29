using System;
using System.Collections.Generic;
using System.Linq;
using ScoreCombination.Domain.Entities;
using ScoreCombination.Domain.Interfaces.Repositories;
using ScoreCombination.Domain.Interfaces.Services;
using ScoreCombination.Domain.Interfaces.Validators;
using ScoreCombination.Domain.Validators;

namespace ScoreCombination.Domain.Services
{
    public class ServiceRecord : ServiceBase<ScoreCombinationRecord>, IServiceRecord
    {
        private readonly IScoreCombinationRequestValidator _validator;
        private readonly IRepositoryRecord _repositoryRecord;

        public ServiceRecord(IRepositoryRecord repositoryRecord) : base(repositoryRecord)
        {
            _repositoryRecord = repositoryRecord;
            _validator = new ScoreCombinationRequestValidator();
        }

        public IEnumerable<ScoreCombinationRecord> GetCallHistory(DateTime initialDate, DateTime finalDate)
        {
            return _repositoryRecord.GetCallHistory(initialDate, finalDate);
        }

        public ScoreCombinationResult GetCombination(ScoreCombinationRequest request)
        {
            _validator.Validate(request);

            var result = new ScoreCombinationResult
            {
                Combination = CombinationSum(request.Sequence, request.Target)
            };

            result.Combination ??= new List<long>();

            _repositoryRecord.Add(new ScoreCombinationRecord
            {
                Combination = string.Join(',', result.Combination),
                Date = DateTime.Now,
                Sequence = string.Join(',', request.Sequence),
                Target = request.Target
            });

            return result;
        }

        private static List<long> CombinationSum(List<long> sequence, long sum)
        {
            var listOfCombinations = new List<List<long>>();
            var temp = new List<long>();

            sequence = sequence.OrderByDescending(x => x).ToList();

            FindNumbers(listOfCombinations, sequence, sum, 0, temp);

            return listOfCombinations.FirstOrDefault();
        }

        private static void FindNumbers(ICollection<List<long>> listOfCombinations, IReadOnlyList<long> combination, long sum, int index, ICollection<long> temp)
        {

            if (sum == 0)
            {
                listOfCombinations.Add(new List<long>(temp));
                return;
            }

            for (var i = index; i < combination.Count; i++)
            {
                if (sum - combination[i] >= 0)
                {
                    temp.Add(combination[i]);

                    FindNumbers(listOfCombinations, combination, sum - combination[i], i, temp);

                    temp.Remove(combination[i]);
                }
            }
        }
    }
}
