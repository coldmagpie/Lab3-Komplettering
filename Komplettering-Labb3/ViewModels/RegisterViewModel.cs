using CommunityToolkit.Mvvm.Input;
using Komplettering_Labb3.Managerrs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Documents;
using CommunityToolkit.Mvvm.ComponentModel;
using Komplettering_Labb3.DataModels.Users;
using Komplettering_Labb3.Enums;

namespace Komplettering_Labb3.ViewModels
{
    public class RegisterViewModel:ObservableObject 
    {
        private NavigationManager _navigationManager;

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
                NavigateAdminCommand.NotifyCanExecuteChanged();
                //NavigateCustomerCommand.NotifyCanExecuteChanged();
            }
        }


        public IRelayCommand NavigateLogInCommand { get; }
        public IRelayCommand NavigateGoBackCommand { get; }
        public IRelayCommand NavigateAdminCommand { get; }
        public IRelayCommand NavigateCustomerCommand { get; }

        public RegisterViewModel(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            NavigateLogInCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new LogInViewModel(_navigationManager));
            NavigateGoBackCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new StartViewModel(_navigationManager));
            NavigateAdminCommand = new RelayCommand(() => UserManager.Register(Name, Password, UserTypes.Admin));
            NavigateCustomerCommand = new RelayCommand(() => UserManager.Register(Name, Password, UserTypes.Customer));
        }
    }
}
