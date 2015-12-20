using Landmine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Landmine.Domain
{
    public class LandmineDataContext : DbContext
    {
        public LandmineDataContext()
           : base("DefaultConnection")
        {
        }

        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("lndm");
        }
    }
}
