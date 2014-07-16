using Landmine.Domain.Abstract;
using Landmine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landmine.Domain.Concrete
{
    public class ScoreRepository : IScoreRepository
    {
        private LandmineDataContext context;
        public ScoreRepository()
        {
            context = new LandmineDataContext();
        }

        public IQueryable<Score> Scores
        {
            get
            {
                return context.Scores;
            }
        }

        public void SaveScore(Score score)
        {
            context.Scores.Add(score);
            context.SaveChanges();
        }
    }
}
