using KMA.APZRPMJ2018.WalletSimulator.ViewModels.Authentication;

namespace KMA.APZRPMJ2018.WalletSimulator.Views.Authentication
{
    internal partial class SignInView
    {
        #region Constructor
        internal SignInView()
        {
            InitializeComponent();
            var signInViewModel = new SignInViewModel();
            DataContext = signInViewModel;
        }
        #endregion
    }
}
