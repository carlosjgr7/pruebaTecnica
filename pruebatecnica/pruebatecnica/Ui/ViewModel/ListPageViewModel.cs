using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pruebatecnica.Data.Local;
using pruebatecnica.Data.Network.Interfaces;
using pruebatecnica.Models;
using pruebatecnica.Ui.Pages;
using pruebatecnica.Utils;
using Refit;
using Xamarin.Forms;

namespace pruebatecnica.Ui.ViewModel
{
    public class ListPageViewModel : BaseViewModel
    {
        private INavigation navigation;
        public List<Root> ListProducts { get; set; }
        public bool Network { get; set; } = true;
        public bool WithoutNet { get; set; } = false;


        public ListPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            LoadFakeProducts();
            init();

        }

        public async void init()
        {
           
            Probarconexion();
            Calls local = new Calls();

            if (SinConexion)
            {
                var listprod = await local.GetPoductsList();
                if (listprod.Count > 0)
                {
                    ListProducts = listprod;
                }
                else
                {
                    Network = Conectado;
                    WithoutNet = SinConexion;
                }
            }
            else
            {
                var api = RestService.For<IProducts>(StaticValue.baseUrl);
                var result = await api.GetProducts();
                await local.DeleteRegisters();
                await local.SaveProducts(result);
                var listprod = await local.GetPoductsList();
                ListProducts = listprod;
            }

        }

        private void LoadFakeProducts()
        {
            List<Root> prood = new List<Root>();
            for (int i = 0; i < 10; i++)
            {
                prood.Add(new Root()
                {
                    title = "aaaaaaaaaaa",
                    category = "aaaaaaaaaaaa",
                    image = "https://i.ibb.co/54d3grJ/car.png",
                    description="",
                    price=1,
                    rating=new Rating() { id=1,count=1,rate=1},
                    id=1
                    
                });
            }
            ListProducts = prood;
        }

        public Command ToDetailPageCommand => new Command(async (p) =>
          {
              await navigation.PushAsync(new DetailPage((Root)p));
          });

        public Command ToLoginCommand => new Command(async () =>
        {
            await navigation.PopAsync();
        });
    }
}

