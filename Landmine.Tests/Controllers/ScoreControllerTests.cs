using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using LandmineWeb.Controllers;
using Landmine.Domain.Abstract;

using System.Web.Http;
using Landmine.Tests.TestHelpers;

using NFluent;

using Xunit;

namespace Landmine.Tests.Controllers
{
    public class ScoreControllerTests
    {
        [Fact]
        public void GetHighScoresReturnsNumberOfProvidedScores()
        {
            var controller = createController();

            Check.That(controller.GetHighScores(3)).HasSize(3);
            Check.That(controller.GetHighScores(7)).HasSize(7);
        }

        private ScoreController createController()
        {
            var mock = new Mock<IScoreRepository>();
            mock.Setup(m => m.Scores).Returns(ScoreHelper.FakeScores(10));
            var controller = new ScoreController(mock.Object);
            return controller;
        }

        [Fact]
        public void GetHighScoresReturnsTopScoresInDescendingOrder()
        {
            var scores = ScoreHelper.FakeScores(10).ToArray().AsQueryable(); //create a query-able view of the same list
            var mock = new Mock<IScoreRepository>();
            mock.Setup(m => m.Scores).Returns(scores);
            var controller = new ScoreController(mock.Object);

            var result = controller.GetHighScores(3);

            Check.That(result).ContainsExactly(scores
                .OrderByDescending(s => s.Value)
                .Take(3));
        }

        [Fact]
        public void GetHighScoreThrows400IfCountGreaterThan50()
        {
            var controller = createController();

            var ex = Assert.Throws<HttpResponseException>(() => {
                controller.GetHighScores(100);
            });


            Check.That(ex.Response.StatusCode).IsEqualTo(System.Net.HttpStatusCode.BadRequest);
        }


    }
}
