using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using AutoMoq;

using Landmine.Domain.Abstract;
using Landmine.Tests.TestHelpers;

using LandmineWeb.Controllers;

using NFluent;

using Xunit;

namespace Landmine.Tests.Controllers
{
    public class ScoreControllerTests
    {
        private static ScoreController CreateController()
        {
            var mocker = new AutoMoqer();

            mocker.GetMock<IScoreRepository>()
                .Setup(m => m.Scores).Returns(ScoreHelper.FakeScores(10));

            return mocker.Create<ScoreController>();
        }

        [Fact]
        public void GetHighScoresReturnsNumberOfProvidedScores()
        {
            var subject = CreateController();

            Check.That(subject.GetHighScores(3)).HasSize(3);
            Check.That(subject.GetHighScores(7)).HasSize(7);
        }

        [Fact]
        public void GetHighScoresReturnsTopScoresInDescendingOrder()
        {
            var mocker = new AutoMoqer();

            var scores = ScoreHelper.FakeScores(10).ToArray().AsQueryable(); //create a query-able view of the same list
            mocker.GetMock<IScoreRepository>()
                .Setup(m => m.Scores).Returns(scores);

            var subject = mocker.Create<ScoreController>();

            var result = subject.GetHighScores(3);

            Check.That(result).ContainsExactly(scores
                .OrderByDescending(s => s.Value)
                .Take(3));
        }

        [Fact]
        public void GetHighScoreThrows400IfCountGreaterThan50()
        {
            var subject = CreateController();

            var ex = Assert.Throws<HttpResponseException>(() => { subject.GetHighScores(100); });

            Check.That(ex.Response.StatusCode).IsEqualTo(System.Net.HttpStatusCode.BadRequest);
        }
    }
}