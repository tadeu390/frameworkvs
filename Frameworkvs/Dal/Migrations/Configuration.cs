namespace Dal.Migrations
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dal.FrameworkvsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Dal.FrameworkvsContext";
        }

        protected override void Seed(Dal.FrameworkvsContext context)
        {
            var estados = new List<Estado>
            {
            new Estado{Nome="Minas Gerais",Abreviacao="MG"},
            new Estado{Nome="Rio de Janeiro",Abreviacao="RJ"},
            };

            estados.ForEach(s => context.Estados.Add(s));
            context.SaveChanges();
        }
    }
}
