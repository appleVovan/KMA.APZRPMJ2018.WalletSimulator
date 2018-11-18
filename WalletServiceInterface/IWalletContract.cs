using System;
using System.Collections.Generic;
using System.ServiceModel;
using KMA.APZRPMJ2018.WalletSimulator.DBModels;

namespace KMA.APZRPMJ2018.WalletSimulator.ServiceInterface
{
    [ServiceContract]
    public interface IWalletContract
    {
        [OperationContract]
        bool UserExists(string login);
        [OperationContract]
        User GetUserByLogin(string login);
        [OperationContract]
        User GetUserByGuid(Guid guid);
        [OperationContract]
        List<User> GetAllUsers(Guid walletGuid);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddWallet(Wallet wallet);
        [OperationContract]
        void SaveWallet(Wallet wallet);
        [OperationContract]
        void DeleteWallet(Wallet selectedWallet);
    }
}
