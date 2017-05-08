namespace TeknolivaProje.Data.Migrations
{
  using System.Data.Entity.Migrations;

  internal sealed class Configuration : DbMigrationsConfiguration<TeknolivaProje.Data.Models.ServiceDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TeknolivaProje.Data.Models.ServiceDBContext context)
        {
           
        }
    }
}
