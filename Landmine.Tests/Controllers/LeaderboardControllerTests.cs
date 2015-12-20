using Landmine.Domain.Abstract;
using Landmine.Domain.Entities;
using Landmine.Tests.TestHelpers;
using LandmineWeb.Controllers;
using Moq;
using NUnit.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Landmine.Tests.Controllers
{
    [TestFixture]
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

        [Test]
        public void ReturnsAPagedList()
        {
            var controller = createController(10);

            var results = (IPagedList<Score>)controller.Index(page: 1).Model;

            Assert.That(results.Count() == 3);
            Assert.That(results.TotalItemCount == 10);
            Assert.That(results.PageCount == 4);
        }

        public void SecondPageOnlyHasTwo()
        {
            var controller = createController(5);

            var results = (IPagedList<Score>)controller.Index(page: 2).Model;

            Assert.That(results.Count() == 2);
            Assert.That(results.TotalItemCount == 5);
            Assert.That(results.PageCount == 2);
        }

        [Test]
        public void ResultsAreSortedDescendingByScore()
        {
            var controller = createController(10);

            var results = (IPagedList<Score>)controller.Index(page: 1).Model;
            var scores = results.Select(s => s.Value).ToArray();
            var sortedScores = scores.OrderByDescending(i => i).ToArray();

            Assert.That(scores, Is.EqualTo(sortedScores));
        }

    }
}
