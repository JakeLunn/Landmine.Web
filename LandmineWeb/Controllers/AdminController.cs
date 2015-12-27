using Landmine.Domain.Abstract;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LandmineWeb.Controllers
{
    public class AdminController : Controller
    {
        public int ScoresPerPage { get; set; } = 20;

        private readonly IScoreRepository _repository;

        public AdminController(IScoreRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Leaderboard(int page = 1)
        {
            if (TempData["AdminMessage"] != null)
            {
                ViewBag.AdminMessage = (string)TempData["AdminMessage"];
            }

            var query = from s in _repository.Scores
                        orderby s.Value descending
                        select s;

            var scores = query.ToPagedList(page, ScoresPerPage);

            return View(scores);
        }

        public ActionResult DeleteScore(int id)
        {
            var score = _repository.Scores.Where(s => s.ScoreId == id).Single();
            _repository.DeleteScore(score);

            TempData["AdminMessage"] = "Score " + score.ScoreId + " Deleted";

            return RedirectToAction("Leaderboard", "Admin");
        }
    }
}