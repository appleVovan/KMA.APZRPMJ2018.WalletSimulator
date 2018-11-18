using KMA.APZRPMJ2018.WalletSimulator.DBModels;
using KMA.APZRPMJ2018.WalletSimulator.ServiceInterface;

namespace KMA.APZRPMJ2018.WalletSimulator.Managers
{
    public class DBManager
    {
        public static bool UserExists(string login)
        {
            return WalletServiceWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return WalletServiceWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            WalletServiceWrapper.AddUser(user);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = WalletServiceWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }
        
        public static void DeleteWallet(Wallet selectedWallet)
        {
            WalletServiceWrapper.DeleteWallet(selectedWallet);
        }

        public static void AddWallet(Wallet wallet)
        {
            WalletServiceWrapper.AddWallet(wallet);
        }
    }
}

