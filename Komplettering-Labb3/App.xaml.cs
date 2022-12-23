using Komplettering_Labb3.Managerrs;
using Komplettering_Labb3.ViewModels;
using System.Windows;

namespace Komplettering_Labb3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly NavigationManager _navigationManager;

        public App()
        {
            _navigationManager = new NavigationManager();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationManager.CurrentViewModel = new StartViewModel(_navigationManager);
            var mainWindow = new MainWindow { DataContext = new MainViewModel(_navigationManager) };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
