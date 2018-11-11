using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using KMA.APZRPMJ2018.WalletSimulator.DBModels;

namespace KMA.APZRPMJ2018.WalletSimulator.DBAdapter
{
    public static class EntityWrapper
    {
        public static bool UserExists(string login)
        {
            using (var context = new WalletDBContext())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var context = new WalletDBContext())
            {
                return context.Users.Include(u=>u.Wallets).FirstOrDefault(u => u.Login == login);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var context = new WalletDBContext())
            {
                return context.Users.Include(u => u.Wallets).FirstOrDefault(u => u.Guid == guid);
            }
        }

        public static List<User> GetAllUsers(Guid walletGuid)
        {
            using (var context = new WalletDBContext())
            {
                return context.Users.Where(u => u.Wallets.All(r => r.Guid != walletGuid)).ToList();
            }
        }

        public static void AddUser(User user)
        {
            using (var context = new WalletDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void AddWallet(Wallet wallet)
        {
            using (var context = new WalletDBContext())
            {
                wallet.DeleteDatabaseValues();
                context.Wallets.Add(wallet);
                context.SaveChanges();
            }
        }

        public static void SaveWallet(Wallet wallet)
        {
            using (var context = new WalletDBContext())
            {
                context.Entry(wallet).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        
        public static void DeleteWallet(Wallet selectedWallet)
        {
            using (var context = new WalletDBContext())
            {
                selectedWallet.DeleteDatabaseValues();
                context.Wallets.Attach(selectedWallet);
                context.Wallets.Remove(selectedWallet);
                context.SaveChanges();
            }
        }
    }
}
