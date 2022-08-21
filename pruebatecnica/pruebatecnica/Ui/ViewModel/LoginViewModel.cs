using System;
using System.Linq;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using pruebatecnica.Ui.Pages;
using pruebatecnica.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace pruebatecnica.Ui.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigation navigation;
        public String User { get; set; }
        public String Pass { get; set; }
        public bool Remember { get; set; }
        public LoginViewModel(INavigation navigation)
        {
            User = Preferences.Get(Prefer.User, "");
            Pass = Preferences.Get(Prefer.Pass, "");
            this.navigation = navigation;
        }

        public Command NewUserCommand => new Command(async () =>
        {
            await navigation.PushAsync(new RegisterPage());

        });
        public Command BiometricsCommand => new Command(async () =>
        {
            if(Preferences.Get(Prefer.User, "") == "")
            {
                await DisplayAlert("Error", "No existen datos biometricos guardados", "Ok");
                return;

            }
            var availibility = await
                CrossFingerprint.Current.IsAvailableAsync();
            if (!availibility)
            {
                await DisplayAlert("Error", "No tienes sistemas biommetricos disponibles", "Ok");
                return;
            }

            var authResult = await
                CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration(
                    "Verifique su identidad", "Confirma tu huella para continuar!"));

            if (authResult.Authenticated)
            {
                User = Preferences.Get(Prefer.User, "");
                Pass = Preferences.Get(Prefer.Pass, "");
                LoginCommand.Execute(null);
            }

        });
        public Command LoginCommand => new Command(async () =>
        {

            var user = (from item in (await App.Database.GetUsersAsync())
                        where item.Username == User
                        where item.Pass == Pass
                        select item).FirstOrDefault();

            if (user != null)
            {
                if (Remember)
                {
                    Preferences.Set(Prefer.User, User);
                    Preferences.Set(Prefer.Pass, Pass);
                }
                await navigation.PushAsync(new ListPage());
            }
            else
            {
                await Application.Current.MainPage
                .DisplayAlert("Usuario no encontrado", "Usuario o clave incorrecta", "OK");
            }
        });
    }
}




