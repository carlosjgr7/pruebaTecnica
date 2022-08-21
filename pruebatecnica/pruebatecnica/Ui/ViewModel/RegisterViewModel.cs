using System;
using PropertyChanged;
using pruebatecnica.Models;
using Xamarin.Forms;

namespace pruebatecnica.Ui.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class RegisterViewModel : BaseViewModel
    {
        private INavigation navigation;
        private static String succes = "Green";
        private static String fail = "Red";

        public String User { get; set; }
        public String Pass { get; set; }
        public String RepeatPass { get; set; }
        public String Message { get; set; }
        public String BorderUser { get; set; } = fail;
        public String BorderPass { get; set; } = fail;
        public String BorderRepeatPass { get; set; } = fail;



        public RegisterViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            
        }

        public Command ItemChangeCommand => new Command(() =>
        {
            BorderUser = (User.Length > 5) ? succes : fail;
            Message = (BorderUser == fail)? "el usuario debe tener mas de 5 caracteres":"";
        });

        public Command PassChangeCommand => new Command(() =>
        {
            BorderPass = (Pass.Length > 3) ? succes : fail;
            if (BorderPass == fail) Message = "la clave debe tener una longitud mayor a 3 caracteres";
            RepeatPassChangeCommand.Execute(null);

        });

        public Command RepeatPassChangeCommand => new Command(() =>
        {
           
            if (BorderPass == succes)
            {
                BorderRepeatPass = (Pass == RepeatPass) ? succes : fail;
                Message = (BorderRepeatPass == fail)?  "las claves no coinciden":"";
            }else
            {
                BorderRepeatPass = fail;
            }
     
        });

        public Command RegisterCommand => new Command(async() =>
        {
            if(BorderPass==succes & BorderUser==succes & BorderUser == succes)
            {
                await App.Database.SaveUsersAsync(new User
                {
                    Username = User,
                    Pass = Pass

                });
                await navigation.PopAsync();
            }
           
        });
    }
}

