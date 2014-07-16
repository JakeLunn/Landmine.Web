using Landmine.Domain.Abstract;
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

        public IQueryable<Entities.Score> Scores
        {
            get
            {
                return context.Scores;
            }
        }
    }
}
