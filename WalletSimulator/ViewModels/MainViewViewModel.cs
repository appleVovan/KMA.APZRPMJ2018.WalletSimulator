using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using KMA.APZRPMJ2018.WalletSimulator.DBModels;
using KMA.APZRPMJ2018.WalletSimulator.Managers;
using KMA.APZRPMJ2018.WalletSimulator.Models;
using KMA.APZRPMJ2018.WalletSimulator.Properties;
using KMA.APZRPMJ2018.WalletSimulator.Tools;

namespace KMA.APZRPMJ2018.WalletSimulator.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields
        private WalletUIModel _selectedWallet;
        private ObservableCollection<WalletUIModel> _wallets;
        #region Commands
        private ICommand _addWalletCommand;
        private ICommand _deleteWalletCommand;
        #endregion
        #endregion

        #region Properties
        #region Commands

        public ICommand AddWalletCommand
        {
            get
            {
                return _addWalletCommand ?? (_addWalletCommand = new RelayCommand<object>(AddWalletExecute));
            }
        }

        public ICommand DeleteWalletCommand
        {
            get
            {
                return _deleteWalletCommand ?? (_deleteWalletCommand = new RelayCommand<KeyEventArgs>(DeleteWalletExecute));
            }
        }

        #endregion

        public ObservableCollection<WalletUIModel> Wallets
        {
            get { return _wallets; }
        }
        public WalletUIModel SelectedWallet
        {
            get { return _selectedWallet; }
            set
            {
                _selectedWallet = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor
        public MainViewViewModel()
        {
            PropertyChanged += OnPropertyChanged;
            FillWallets();
        }
        #endregion
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "SelectedWallet")
                OnWalletChanged(_selectedWallet);
        }
        private void FillWallets()
        {
            _wallets = new ObservableCollection<WalletUIModel>();
            foreach (var wallet in StationManager.CurrentUser.Wallets)
            {
                _wallets.Add(new WalletUIModel(wallet));
            }
            if (_wallets.Count > 0)
            {
                _selectedWallet = Wallets[0];
            }
        }

        private void DeleteWalletExecute(KeyEventArgs args)
        {
            if (args.Key != Key.Delete) return;

            if (SelectedWallet == null) return;

            StationManager.CurrentUser.Wallets.RemoveAll(uwr => uwr.Guid == SelectedWallet.Guid);
            DBManager.DeleteWallet(SelectedWallet.Wallet);
            FillWallets();
            OnPropertyChanged(nameof(SelectedWallet));
            OnPropertyChanged(nameof(Wallets));
        }

        private void AddWalletExecute(object o)
        {
            Wallet wallet = new Wallet("New Wallet", StationManager.CurrentUser);
            DBManager.AddWallet(wallet);
            var walletUIModel = new WalletUIModel(wallet);
            _wallets.Add(walletUIModel);
            _selectedWallet = walletUIModel;
        }
        
        #region EventsAndHandlers
        #region Loader
        internal event WalletChangedHandler WalletChanged;
        internal delegate void WalletChangedHandler(WalletUIModel wallet);

        internal virtual void OnWalletChanged(WalletUIModel wallet)
        {
            WalletChanged?.Invoke(wallet);
        }
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }  
        #endregion
        #endregion


    }
}
