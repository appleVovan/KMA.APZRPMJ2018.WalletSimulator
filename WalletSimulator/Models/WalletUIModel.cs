using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KMA.APZRPMJ2018.WalletSimulator.DBModels;
using KMA.APZRPMJ2018.WalletSimulator.Properties;

namespace KMA.APZRPMJ2018.WalletSimulator.Models
{
    public class WalletUIModel:INotifyPropertyChanged
    {
        #region Fields
        private Wallet _wallet;
        #endregion

        #region Properties
        internal Wallet Wallet
        {
            get { return _wallet; }
            private set
            {
                _wallet = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _wallet.Title; }
            set
            {
                _wallet.Title = value;
                OnPropertyChanged();
            }
        }
        public long TotalIncome
        {
            get { return _wallet.TotalIncome; }
        }
        public long TotalOutcome
        {
            get { return _wallet.TotalOutcome; }
        }

        public Guid Guid
        {
            get { return _wallet.Guid; }
        }

        #endregion

        public WalletUIModel(Wallet wallet)
        {
            _wallet = wallet;
        }

        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
