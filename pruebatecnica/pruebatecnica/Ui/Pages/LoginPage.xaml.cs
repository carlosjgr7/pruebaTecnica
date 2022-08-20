using System;
using System.Collections.Generic;
using pruebatecnica.Ui.ViewModel;
using Xamarin.Forms;

namespace pruebatecnica.Ui.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }
    }
}

