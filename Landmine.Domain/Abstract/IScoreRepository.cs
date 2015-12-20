using System;
using System.Collections.Generic;
using System.Linq;

using Landmine.Domain.Entities;

namespace Landmine.Domain.Abstract
{
    public interface IScoreRepository
    {
        IQueryable<Score> Scores { get; }
        void SaveScore(Score score);
    }
}