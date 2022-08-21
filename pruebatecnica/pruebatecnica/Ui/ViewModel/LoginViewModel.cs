using System;
using System.Linq;
using pruebatecnica.Data.Network.Interfaces;
using pruebatecnica.Models;
using pruebatecnica.Ui.Pages;
using pruebatecnica.Utils;
using Refit;
using Xamarin.Forms;

namespace pruebatecnica.Ui.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigation navigation;
        public String User { get; set; }
        public String Pass { get; set; }
        public Boolean Remember { get; set; }
        public LoginViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public Command NewUserCommand => new Command(async () =>
        {
            await navigation.PushAsync(new RegisterPage());

        });
        public Command BiometricsCommand => new Command(async () =>
        {
         
            var api = RestService.For<IProducts>(StaticValue.baseUrl);
            var result = await api.GetProducts();
            await navigation.PushAsync(new ListPage(result));

        });
        public Command LoginCommand => new Command(async () =>
        {
            var user = (from item in (await App.Database.GetUsersAsync())
                        where item.Username == User
                        where item.Pass == Pass
                        select item).FirstOrDefault();

            if (user!=null)
            {
                await navigation.PushAsync(new RegisterPage());
            }
            else
            {
                await Application.Current.MainPage
                .DisplayAlert("Usuario no encontrado", "Usuario o clave incorrecta", "OK");
            }
        });
    }
}

