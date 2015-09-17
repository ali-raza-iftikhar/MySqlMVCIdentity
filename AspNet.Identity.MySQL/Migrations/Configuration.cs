namespace AspNet.Identity.MySQL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNet.Identity.MySQL.MySQLDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspNet.Identity.MySQL.MySQLDatabase context)
        {

            var adminRole = new IdentityRole("Admin");
            if (context.Roles.Where(x => x.Name == adminRole.Name).FirstOrDefault() == null)
                context.Roles.Add(adminRole);
            var userRole = new IdentityRole("User");
            if (context.Roles.Where(x => x.Name == userRole.Name).FirstOrDefault() == null)
                context.Roles.Add(userRole);
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
