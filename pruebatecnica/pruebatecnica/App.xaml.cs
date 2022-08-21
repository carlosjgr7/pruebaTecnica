using System;
using System.IO;
using pruebatecnica.Data.Local;
using pruebatecnica.Ui.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pruebatecnica
{
    public partial class App : Application
    {
        private static Database database;

        public App ()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment
                        .SpecialFolder.LocalApplicationData), "pruebatecnica.db3"));
                }
                return database;
            }
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

