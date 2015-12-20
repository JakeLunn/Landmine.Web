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
        public int ScoresPerPage { get; set; } = 20;

        private readonly IScoreRepository _repository;

        public LeaderboardController(IScoreRepository repository)
        {
            _repository = repository;
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