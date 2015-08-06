


namespace ClaimEventAPI.Migrations

{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClaimEventAPI.Models.ClaimEventAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ClaimEventAPI.Models.ClaimEventAPIContext context)
        {
            context.EventHandlers.AddOrUpdate(p => p.Id,
                new Models.EventHandler {Name = "TEST1", BeginDate = DateTime.Now, EndDate = DateTime.Today, Description = "THIS IS A TEST1"},
                new Models.EventHandler {Name = "TEST2", BeginDate = DateTime.Now, EndDate = DateTime.Today, Description = "THIS IS A TEST2"}
                
                );
        }
    }
}
