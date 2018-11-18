using System;
using System.Collections.Generic;
using KMA.APZRPMJ2018.WalletSimulator.DBAdapter;
using KMA.APZRPMJ2018.WalletSimulator.DBModels;
using KMA.APZRPMJ2018.WalletSimulator.ServiceInterface;

namespace KMA.APZRPMJ2018.WalletSimulator.WalletService
{

    class WalletSimulatorService: IWalletContract
    {
        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public User GetUserByGuid(Guid guid)
        {
            return EntityWrapper.GetUserByGuid(guid);
        }

        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public void AddWallet(Wallet wallet)
        {
            EntityWrapper.AddWallet(wallet);
        }
        
        public List<User> GetAllUsers(Guid walletGuid)
        {
            return EntityWrapper.GetAllUsers(walletGuid);
        }
        
        public void DeleteWallet(Wallet selectedWallet)
        {
            EntityWrapper.DeleteWallet(selectedWallet);
        }


        public void SaveWallet(Wallet wallet)
        {
            EntityWrapper.SaveWallet(wallet);
        }
    }
}
