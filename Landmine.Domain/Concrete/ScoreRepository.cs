using Landmine.Domain.Abstract;
using Landmine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Landmine.Domain.Concrete
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly LandmineDataContext _context;
        public ScoreRepository()
        {
            _context = new LandmineDataContext();
        }

        public IQueryable<Score> Scores => _context.Scores;

        public void SaveScore(Score score)
        {
            _context.Scores.Add(score);
            _context.SaveChanges();
        }
    }
}
