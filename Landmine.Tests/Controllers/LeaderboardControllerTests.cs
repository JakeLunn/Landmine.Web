using System;
using System.Collections.Generic;
using System.Linq;

using AutoMoq;

using Landmine.Domain.Abstract;
using Landmine.Domain.Entities;
using Landmine.Tests.TestHelpers;

using LandmineWeb.Controllers;

using NFluent;

using PagedList;

using Xunit;

namespace Landmine.Tests.Controllers
{
    public class LeaderboardControllerTests
    {
        private static LeaderboardController CreateController(int totalScores = 10)
        {
            var mocker = new AutoMoqer();
            mocker.GetMock<IScoreRepository>()
                .Setup(m => m.Scores).Returns(ScoreHelper.FakeScores(totalScores));

            var controller = mocker.Create<LeaderboardController>();
            controller.ScoresPerPage = 3;

            return controller;
        }

        [Fact]
        public void ReturnsAPagedList()
        {
            var subject = CreateController(10);

            var results = (IPagedList<Score>)subject.Index(page: 1).Model;

            Check.That(results).HasSize(3);
            Check.That(results.TotalItemCount).IsEqualTo(10);
            Check.That(results.PageCount).IsEqualTo(4);
        }

        [Fact]
        public void SecondPageOnlyHasTwo()
        {
            var subject = CreateController(5);

            var results = (IPagedList<Score>)subject.Index(page: 2).Model;

            Check.That(results).HasSize(2);
            Check.That(results.TotalItemCount).IsEqualTo(5);
            Check.That(results.PageCount).IsEqualTo(2);
        }

        [Fact]
        public void ResultsAreSortedDescendingByScore()
        {
            var subject = CreateController(10);

            var results = (IPagedList<Score>)subject.Index(page: 1).Model;
            var scores = results.Select(s => s.Value).ToArray();
            var sortedScores = scores.OrderByDescending(i => i).ToArray();

            Check.That(scores).ContainsExactly(sortedScores);
        }
    }
}