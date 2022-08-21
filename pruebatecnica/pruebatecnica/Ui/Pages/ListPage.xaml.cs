using System;
using System.Collections.Generic;
using pruebatecnica.Ui.ViewModel;
using Xamarin.Forms;

namespace pruebatecnica.Ui.Pages
{
    public partial class ListPage : ContentPage
    {
        public ListPage(List<Models.Root> result)
        {
            InitializeComponent();
            BindingContext = new ListPageViewModel(Navigation, result);
        }
    }
}

