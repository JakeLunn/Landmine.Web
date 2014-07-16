using Landmine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landmine.Domain
{
    public class LandmineDataContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }
    }
}
