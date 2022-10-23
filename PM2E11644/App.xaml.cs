using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E11644.Controllers;
using System.IO;

namespace PM2E11644
{
    public partial class App : Application
    {
        static UbicacionDB basedatos;
        public static UbicacionDB BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new UbicacionDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UbicacionesDB.db3"));
                }

                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.MainPage());
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
