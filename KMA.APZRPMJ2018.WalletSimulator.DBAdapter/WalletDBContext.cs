using System.Data.Entity;
using KMA.APZRPMJ2018.WalletSimulator.DBAdapter.Migrations;
using KMA.APZRPMJ2018.WalletSimulator.DBModels;

namespace KMA.APZRPMJ2018.WalletSimulator.DBAdapter
{
    internal class WalletDBContext : DbContext
    {
        public WalletDBContext():base("NewWalletDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WalletDBContext, Configuration>(true));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new Wallet.WalletEntityConfiguration());
        }
    }
}
