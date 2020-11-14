using System.Windows;
using BoardGameDesigner.DesktopApp.Windows;
using BoardGameDesigner.ViewModel;
using BoardGameDesigner.ViewModel.Main;
using SimpleInjector;

namespace BoardGameDesigner.DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        private readonly Container _container;

        public MainWindow(GameDetailsViewModel gameDetailsVm, Container container, MainViewModel mainVm)
        {
            _container = container;
            InitializeComponent();
            gameDetailsVm.GameData = "TestData";
            DataContext = mainVm;

            gameDetailsVm.LoadProjectCommand.BoardWindow = this;

            Closing += MainWindow_Closing;

            CardController.InitializeControl(_container);
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        public Window GetWindow()
        {
            return this;
        }

        public void ShowWindow()
        {
            this.Show();
        }

        public void CloseWindow()
        {
            
        }
    }
}
