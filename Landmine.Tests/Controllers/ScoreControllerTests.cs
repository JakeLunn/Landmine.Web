using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using LandmineWeb.Controllers;
using Landmine.Domain.Abstract;
using Landmine.Domain.Entities;
using System.Web.Http;
using Landmine.Tests.TestHelpers;

namespace Landmine.Tests.Controllers
{
    [TestFixture]
    public class ScoreControllerTests
    {
        [Test]
        public void GetHighScoresReturnsNumberOfProvidedScores()
        {
            var controller = createController();

            Assert.That(controller.GetHighScores(3).Count(), Is.EqualTo(3));
            Assert.That(controller.GetHighScores(7).Count(), Is.EqualTo(7));
        }

        private ScoreController createController()
        {
            var mock = new Mock<IScoreRepository>();
            mock.Setup(m => m.Scores).Returns(ScoreHelper.FakeScores(10));
            var controller = new ScoreController(mock.Object);
            return controller;
        }

        [Test]
        public void GetHighScoresReturnsTopScoresInDescendingOrder()
        {
            var scores = ScoreHelper.FakeScores(10).ToArray().AsQueryable(); //create a query-able view of the same list
            var mock = new Mock<IScoreRepository>();
            mock.Setup(m => m.Scores).Returns(scores);
            var controller = new ScoreController(mock.Object);

            var result = controller.GetHighScores(3);

            Assert.That(result.ToArray(), Is.EqualTo(scores
                                                        .OrderByDescending(s => s.Value)
                                                        .Take(3)
                                                        .ToArray()));
        }

        [Test]
        public void GetHighScoreThrows400IfCountGreaterThan50()
        {
            var controller = createController();

            var ex = Assert.Throws<HttpResponseException>(() => {
                controller.GetHighScores(100);
            });

            Assert.That(ex.Response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

        
    }
}
