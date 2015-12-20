using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Landmine.Domain.Abstract;
using Landmine.Domain.Entities;

namespace LandmineWeb.Controllers
{
    public class ScoreController : ApiController
    {
        private readonly IScoreRepository _repository;

        public ScoreController(IScoreRepository repository)
        {
            _repository = repository;
        }

        [Route("api/scores/high")]
        [HttpGet]
        public IEnumerable<Score> GetHighScores(int count = 10)
        {
            if (count > 50)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "Too many scores requested. Max is 50"
                });
            }
            var query = from s in _repository.Scores
                orderby s.Value descending
                select s;
            return query.Take(count);
        }

        // POST: api/Score
        public void Post([FromBody] Score score)
        {
            _repository.SaveScore(score);
        }

        // DELETE: api/Score/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}