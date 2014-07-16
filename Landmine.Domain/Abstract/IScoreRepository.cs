using Landmine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landmine.Domain.Abstract
{
    public interface IScoreRepository
    {
        IQueryable<Score> Scores { get; }

        void SaveScore(Score score);
    }
}
