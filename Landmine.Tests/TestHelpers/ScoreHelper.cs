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
            var rand = new Random();
            return Enumerable.Range(1, count).Select(i => new Score
            {
                ScoreId = i,
                Level = rand.Next(5),
                Nickname = "Player " + i,
                Value = rand.Next(400)
            }).AsQueryable();
        }
    }
}
