
using Ejercicio2_2ANGELGARCIA.Controller;
using System;
using System.IO;
using Xamarin.Forms;


namespace Ejercicio2_2ANGELGARCIA
{
    
    public partial class App : Application
    {
        static DataBase db;
        public static DataBase DBase
        {
            get
            {
                if (db == null)
                {
                    String folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Firma.db3");
                    db = new DataBase(folderPath);
                }

                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
