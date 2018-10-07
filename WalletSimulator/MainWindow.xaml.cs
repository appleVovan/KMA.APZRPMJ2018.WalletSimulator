using System.Windows.Controls;
using KMA.APZRPMJ2018.WalletSimulator.Managers;
using KMA.APZRPMJ2018.WalletSimulator.Tools;

namespace KMA.APZRPMJ2018.WalletSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            navigationModel.Navigate(ModesEnum.SignIn);
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
