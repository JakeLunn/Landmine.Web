using System;
using System.Collections.Generic;
using System.Linq;

namespace Landmine.Domain.Entities
{
    public class Score
    {
        public int ScoreId { get; set; }
        public string Nickname { get; set; }
        public int Value { get; set; }
        public int Level { get; set; }
    }
}
