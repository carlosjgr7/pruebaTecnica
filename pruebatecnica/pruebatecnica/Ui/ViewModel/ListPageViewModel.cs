using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pruebatecnica.Data.Network.Interfaces;
using pruebatecnica.Models;
using pruebatecnica.Ui.Pages;
using pruebatecnica.Utils;
using Refit;
using Xamarin.Forms;

namespace pruebatecnica.Ui.ViewModel
{
    public class ListPageViewModel:BaseViewModel
    {
        private INavigation navigation;
        public List<Root> ListProducts { get; set; }


        public ListPageViewModel(INavigation navigation, List<Root> result)
        {
            this.navigation = navigation;
            this.ListProducts = result;
            
        }

        public Command ToDetailPageCommand=>new Command(async (p) =>
        {
            await navigation.PushAsync(new DetailPage((Root)p));
        });

    }
}

