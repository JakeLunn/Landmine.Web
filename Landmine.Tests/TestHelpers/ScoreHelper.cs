using Landmine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landmine.Tests.TestHelpers
{
    static class ScoreHelper
    {
        public static IQueryable<Score> FakeScores(int count = 10)
        {
            return Enumerable.Range(1, count).Select(i => new Score
            {
                ScoreId = i,
                Level = Faker.RandomNumber.Next(1, 5),
                Nickname = Faker.Name.First(),
                Value = Faker.RandomNumber.Next(1, 400)
            }).AsQueryable();
        }
    }
}
