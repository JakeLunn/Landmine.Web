using Landmine.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landmine.Domain.Concrete
{
    public class LandmineDataContext : IScoreRepository
    {
        private LandmineDataContext context;
        public LandmineDataContext()
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
