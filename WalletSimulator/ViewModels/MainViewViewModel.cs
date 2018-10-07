using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using KMA.APZRPMJ2018.WalletSimulator.Managers;
using KMA.APZRPMJ2018.WalletSimulator.Models;
using KMA.APZRPMJ2018.WalletSimulator.Properties;
using KMA.APZRPMJ2018.WalletSimulator.Tools;

namespace KMA.APZRPMJ2018.WalletSimulator.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Wallet _selectedWallet;
        private ObservableCollection<Wallet> _wallets;
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

        public ObservableCollection<Wallet> Wallets
        {
            get { return _wallets; }
        }
        public Wallet SelectedWallet
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
            FillWallets();
            PropertyChanged += OnPropertyChanged;
        }
        #endregion
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "SelectedWallet")
                OnWalletChanged(_selectedWallet);
        }
        private void FillWallets()
        {
            _wallets = new ObservableCollection<Wallet>();
            foreach (var wallet in StationManager.CurrentUser.Wallets)
            {
                _wallets.Add(wallet);
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
            FillWallets();
            OnPropertyChanged(nameof(SelectedWallet));
            OnPropertyChanged(nameof(Wallets));
        }

        private void AddWalletExecute(object o)
        {
            Wallet wallet = new Wallet("New Wallet", StationManager.CurrentUser);
            _wallets.Add(wallet);
            _selectedWallet = wallet;
        }
        
        #region EventsAndHandlers
        #region Loader
        internal event WalletChangedHandler WalletChanged;
        internal delegate void WalletChangedHandler(Wallet wallet);

        internal virtual void OnWalletChanged(Wallet wallet)
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
