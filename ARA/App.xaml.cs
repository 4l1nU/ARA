using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ARA.Data;
using System.IO;

namespace ARA
{
    public partial class App : Application
    {
        static CabinetDatabase database;
        public static CabinetDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   CabinetDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Programari.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
