using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScoreCombination.Core.Domain;

namespace ScoreCombination.Core.Database
{
    public class ScoreDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ScoreCombinationDbContext(serviceProvider
                    .GetRequiredService<DbContextOptions<ScoreCombinationDbContext>>()))
            {
                if (context.Record.Any())
                {
                    return;
                }

                context.Record.AddRange(
                    new ScoreCombinationRecord
                    {
                        Id = 1,
                        Sequence = { 5, 20, 2, 1 },
                        Target = 47,
                        Combination = new List<long> { 20, 20, 5, 2 },
                        Date = new DateTime(2021, 3, 28)
                    },
                    new ScoreCombinationRecord
                    {
                        Id = 2,
                        Sequence = { 3, 20 },
                        Target = 21,
                        Combination = new List<long> { 3, 3, 3, 3, 3, 3, 3 },
                        Date = new DateTime(2021, 3, 27)
                    },
                    new ScoreCombinationRecord
                    {
                        Id = 3,
                        Sequence = { 3, 10 },
                        Target = 43,
                        Combination = new List<long> { 10, 10, 10, 10, 3 },
                        Date = new DateTime(2020, 3, 27)
                    });

                context.SaveChanges();
            }
        }
    }
}
