using System;
using System.Collections.Generic;
using System.ServiceModel;
using KMA.APZRPMJ2018.WalletSimulator.DBModels;

namespace KMA.APZRPMJ2018.WalletSimulator.ServiceInterface
{
    public class WalletServiceWrapper
    {
        public static bool UserExists(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IWalletContract>("Server"))
            {
                IWalletContract client = myChannelFactory.CreateChannel();
                return client.UserExists(login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IWalletContract>("Server"))
            {
                IWalletContract client = myChannelFactory.CreateChannel();
                return client.GetUserByLogin(login);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var myChannelFactory = new ChannelFactory<IWalletContract>("Server"))
            {
                IWalletContract client = myChannelFactory.CreateChannel();
                return client.GetUserByGuid(guid);
            }
        }

        public static void AddUser(User user)
        {
            using (var myChannelFactory = new ChannelFactory<IWalletContract>("Server"))
            {
                IWalletContract client = myChannelFactory.CreateChannel();
                client.AddUser(user);
            }
        }

        public static void AddWallet(Wallet wallet)
        {
            using (var myChannelFactory = new ChannelFactory<IWalletContract>("Server"))
            {
                IWalletContract client = myChannelFactory.CreateChannel();
                client.AddWallet(wallet);
            }
        }

        public static void SaveWallet(Wallet wallet)
        {
            using (var myChannelFactory = new ChannelFactory<IWalletContract>("Server"))
            {
                IWalletContract client = myChannelFactory.CreateChannel();
                client.SaveWallet(wallet);
            }
        }

        public static List<User> GetAllUsers(Guid walletGuid)
        {
            using (var myChannelFactory = new ChannelFactory<IWalletContract>("Server"))
            {
                IWalletContract client = myChannelFactory.CreateChannel();
                return client.GetAllUsers(walletGuid);
            }
        }

        public static void DeleteWallet(Wallet selectedWallet)
        {
            using (var myChannelFactory = new ChannelFactory<IWalletContract>("Server"))
            {
                IWalletContract client = myChannelFactory.CreateChannel();
                client.DeleteWallet(selectedWallet);
            }
        }
    }
}

