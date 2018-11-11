using KMA.APZRPMJ2018.WalletSimulator.Models;
using KMA.APZRPMJ2018.WalletSimulator.ViewModels;

namespace KMA.APZRPMJ2018.WalletSimulator.Views.Wallet
{
    /// <summary>
    /// Interaction logic for WalletConfigurationView.xaml
    /// </summary>
    public partial class WalletConfigurationView
    {
        public WalletConfigurationView(WalletUIModel wallet)
        {
            InitializeComponent();
            var walletModel = new WalletConfigurationViewModel(wallet);
            DataContext = walletModel;
        }
    }
}
