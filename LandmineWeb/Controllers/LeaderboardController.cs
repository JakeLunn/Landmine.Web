using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Landmine.Domain.Abstract;

using PagedList;

namespace LandmineWeb.Controllers
{
    public class LeaderboardController : Controller
    {
        public int ScoresPerPage { get; set; }
        private readonly IScoreRepository _repository;

        public LeaderboardController(IScoreRepository repository)
        {
            this._repository = repository;
            this.ScoresPerPage = 20;
        }

        public ViewResult Index(int page = 1)
        {
            var query = from s in _repository.Scores
                orderby s.Value descending
                select s;

            var scores = query.ToPagedList(page, ScoresPerPage);

            return View(scores);
        }
    }
}