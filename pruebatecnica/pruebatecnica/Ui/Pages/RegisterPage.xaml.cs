using System;
using System.Collections.Generic;
using pruebatecnica.Ui.ViewModel;
using Xamarin.Forms;

namespace pruebatecnica.Ui.Pages
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel(Navigation);
        }
    }
}

