using KMA.APZRPMJ2018.WalletSimulator.DBAdapter;
using KMA.APZRPMJ2018.WalletSimulator.DBModels;
using KMA.APZRPMJ2018.WalletSimulator.Tools;

namespace KMA.APZRPMJ2018.WalletSimulator.Managers
{
    public class DBManager
    {
        public static bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = EntityWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }
        
        public static void DeleteWallet(Wallet selectedWallet)
        {
            EntityWrapper.DeleteWallet(selectedWallet);
        }

        public static void AddWallet(Wallet wallet)
        {
            EntityWrapper.AddWallet(wallet);
        }
    }
}

