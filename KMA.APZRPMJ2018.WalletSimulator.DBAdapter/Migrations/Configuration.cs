using System.Data.Entity.Migrations;

namespace KMA.APZRPMJ2018.WalletSimulator.DBAdapter.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WalletDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WalletDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
