using System;
using pruebatecnica.Models;
using Xamarin.Forms;

namespace pruebatecnica.Ui.ViewModel
{
    public class DetailPageViewModel:BaseViewModel
    {
        private INavigation navigation;
        public Root Item { get; set; }

        public DetailPageViewModel(INavigation navigation, Root item)
        {
            this.navigation = navigation;
            this.Item = item;
            
        }
    }
}

