using System;
using System.Collections.Generic;
using pruebatecnica.Models;
using pruebatecnica.Ui.ViewModel;
using Xamarin.Forms;

namespace pruebatecnica.Ui.Pages
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Root item)
        {
            InitializeComponent();
            BindingContext = new DetailPageViewModel(Navigation,item);
        }
    }
}

