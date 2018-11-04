using System.Windows.Controls;
using KMA.APZRPMJ2018.WalletSimulator.Managers;
using KMA.APZRPMJ2018.WalletSimulator.Tools;
using KMA.APZRPMJ2018.WalletSimulator.ViewModels;

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
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            mainWindowViewModel.StartApplication();
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
