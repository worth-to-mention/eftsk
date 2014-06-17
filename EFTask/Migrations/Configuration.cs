namespace EFTask.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EFTask.EntityModel;

    internal sealed class Configuration : DbMigrationsConfiguration<EFTask.EntityModel.EFTaskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFTask.EntityModel.EFTaskContext context)
        {
            var newGood = new Good
            {
                ID = Guid.Parse("153f9a27-0fcc-4d42-af7f-d1008c15f78b"),
                Name = "New GOOD",
                Amount = 3000,
            };

            var newPayment = new Payment
            {
                ID = Guid.Parse("cebfa483-35f8-4d8e-9a54-d111135d36ad"),
                Good = newGood,
                Date = new DateTime(2013, 11, 6),
                Quantity = 10
            };
            newGood.Payments.Add(newPayment);
            
            
            context.Goods.AddOrUpdate(
                x => x.ID,
                newGood
            );

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
