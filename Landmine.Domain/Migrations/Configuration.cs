namespace Landmine.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Landmine.Domain.LandmineDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Landmine.Domain.LandmineDataContext context)
        {
        //    for (var i = 0; i < 1000; i++)
        //    {
        //        context.Scores.Add(new Entities.Score()
        //        {
        //            Value = Faker.RandomNumber.Next(1, 1000),
        //            Nickname = Faker.Name.First(),
        //            Level = Faker.RandomNumber.Next(1, 5)
        //        });
        //    }
        }
    }
}
