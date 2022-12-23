using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Komplettering_Labb3.Managerrs;

namespace Komplettering_Labb3.ViewModels
{
    public class StartViewModel:ObservableObject
    {
        private NavigationManager _navigationManager;
        public IRelayCommand NavigateRegisterCommand { get; }
        public IRelayCommand NavigateLogInCommand { get; }

        public StartViewModel(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            NavigateRegisterCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new RegisterViewModel(_navigationManager));
            NavigateLogInCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new LogInViewModel(_navigationManager));
        }
    }
}
