using System;
using pruebatecnica.Ui.Pages;
using Xamarin.Forms;

namespace pruebatecnica.Ui.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        private INavigation navigation;
        public String  User { get; set; }
        public String  Pass { get; set; }
        public Boolean Remember { get; set; }
        public LoginViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public Command NewUserCommand => new Command(async () =>
        {
            await navigation.PushAsync(new RegisterPage());
        });
    }
}

