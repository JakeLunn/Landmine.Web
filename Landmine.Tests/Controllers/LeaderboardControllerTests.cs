using Landmine.Domain.Abstract;
using Landmine.Domain.Entities;
using Landmine.Tests.TestHelpers;
using LandmineWeb.Controllers;
using Moq;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using Xunit;

namespace Landmine.Tests.Controllers
{
    public class LeaderboardControllerTests
    {
        private static LeaderboardController createController(int totalScores = 10)
        {
            var mock = new Mock<IScoreRepository>();
            mock.Setup(m => m.Scores).Returns(ScoreHelper.FakeScores(totalScores));
            var controller = new LeaderboardController(mock.Object)
            {
                ScoresPerPage = 3
            };
            return controller;
        }

        [Fact]
        public void ReturnsAPagedList()
        {
            var controller = createController(10);

            var results = (IPagedList<Score>)controller.Index(page: 1).Model;

            Check.That(results).HasSize(3);
            Check.That(results.TotalItemCount).IsEqualTo(10);
            Check.That(results.PageCount).IsEqualTo(4);
        }

        [Fact]
        public void SecondPageOnlyHasTwo()
        {
            var controller = createController(5);

            var results = (IPagedList<Score>)controller.Index(page: 2).Model;

            Check.That(results).HasSize(2);
            Check.That(results.TotalItemCount).IsEqualTo(5);
            Check.That(results.PageCount).IsEqualTo(2);
        }

        [Fact]
        public void ResultsAreSortedDescendingByScore()
        {
            var controller = createController(10);

            var results = (IPagedList<Score>)controller.Index(page: 1).Model;
            var scores = results.Select(s => s.Value).ToArray();
            var sortedScores = scores.OrderByDescending(i => i).ToArray();

            Check.That(scores).ContainsExactly(sortedScores);
        }

    }
}
