using CommunityToolkit.Mvvm.Input;
using Komplettering_Labb3.Managerrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Komplettering_Labb3.ViewModels
{
    public class ShopViewModel:ObservableObject
    {
        private NavigationManager _navigationManager;
        public ShopViewModel(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }
    }
}
