using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Komplettering_Labb3.DataModels.Users;
using Komplettering_Labb3.Enums;
using Komplettering_Labb3.Managerrs;

namespace Komplettering_Labb3.ViewModels
{
    public class LogInViewModel : ObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                NavigateLogInCommand.NotifyCanExecuteChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
                NavigateLogInCommand.NotifyCanExecuteChanged();
            }
        }

        private NavigationManager _navigationManager;
        public IRelayCommand NavigateRegisterCommand { get; }
        public IRelayCommand NavigateGoBackCommand { get; }
        public IRelayCommand NavigateLogInCommand { get; }

        public LogInViewModel(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            NavigateRegisterCommand = new RelayCommand(() =>
                _navigationManager.CurrentViewModel = new RegisterViewModel(_navigationManager));
            NavigateGoBackCommand = new RelayCommand(() =>
                _navigationManager.CurrentViewModel = new StartViewModel(_navigationManager));
            NavigateLogInCommand = new RelayCommand(() =>
            {
                UserManager.LogIn(Name, Password);
                if (UserManager.CurrentUser.Type.Equals(UserTypes.Admin))
                {
                    _navigationManager.CurrentViewModel = new AdminViewModel(_navigationManager);
                }
                _navigationManager.CurrentViewModel = new ShopViewModel(_navigationManager);
            });
        }

       
    }
}

