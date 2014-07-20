using Landmine.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace LandmineWeb.Controllers
{
    public class LeaderboardController : Controller
    {
        public int ScoresPerPage { get; set; }
        private IScoreRepository repository;
        public LeaderboardController(IScoreRepository repository)
        {
            this.repository = repository;
            this.ScoresPerPage = 20;
        }

        public ViewResult Index(int page = 1)
        {
            var query = from s in repository.Scores
                        orderby s.Value descending
                        select s;

            var scores = query.ToPagedList(page, ScoresPerPage);
            

            return View(scores);
        }
    }
}