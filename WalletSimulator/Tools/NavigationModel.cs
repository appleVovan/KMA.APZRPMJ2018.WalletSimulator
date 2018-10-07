using System;
using KMA.APZRPMJ2018.WalletSimulator.Views;
using KMA.APZRPMJ2018.WalletSimulator.Views.Authentication;
using SignUpView = KMA.APZRPMJ2018.WalletSimulator.Views.Authentication.SignUpView;

namespace KMA.APZRPMJ2018.WalletSimulator.Tools
{
    internal enum ModesEnum
    {
        SignIn,
        SingUp,
        Main
    }

    internal class NavigationModel
    {
        private readonly IContentWindow _contentWindow;
        private SignInView _signInView;
        private SignUpView _signUpView;
        private MainView _mainView;

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.SignIn:
                    _contentWindow.ContentControl.Content = _signInView ?? (_signInView = new SignInView());
                    break;
                case ModesEnum.SingUp:
                    _contentWindow.ContentControl.Content = _signUpView ?? (_signUpView = new SignUpView());
                    break;
                case ModesEnum.Main:
                    _contentWindow.ContentControl.Content = _mainView ?? (_mainView = new MainView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}