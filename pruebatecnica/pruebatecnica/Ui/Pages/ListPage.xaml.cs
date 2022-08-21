using System;
using System.Collections.Generic;
using pruebatecnica.Ui.ViewModel;
using Xamarin.Forms;

namespace pruebatecnica.Ui.Pages
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = new ListPageViewModel(Navigation);
        }
    }
}

