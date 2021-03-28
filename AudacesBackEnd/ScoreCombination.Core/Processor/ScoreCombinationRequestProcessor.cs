﻿using System;
using System.Collections.Generic;
using System.Linq;
using ScoreCombination.Core.DataInterface;
using ScoreCombination.Core.Domain;

namespace ScoreCombination.Core.Processor
{
    public class ScoreCombinationRequestProcessor
    {
        private readonly ScoreCombinationRequestValidator _validator;
        private readonly IScoreCombinationRepository _scoreCombinationRepository;

        public ScoreCombinationRequestProcessor(IScoreCombinationRepository scoreCombinationRepository)
        {
            _validator = new ScoreCombinationRequestValidator();
            _scoreCombinationRepository = scoreCombinationRepository;
        }

        public ScoreCombinationResult GetCombination(ScoreCombinationRequest request)
        {
            _validator.Validate(request);

            var result = new ScoreCombinationResult
            {
                Combination = CombinationSum(request.Sequence, request.Target)
            };

            result.Combination ??= new List<long>();

            _scoreCombinationRepository.Save(new ScoreCombinationRecord
            {
                Combination = result.Combination,
                Date = DateTime.Now,
                Sequence = request.Sequence,
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