using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using maEugeniAppV1.Views;
using Xamarin.Forms;
using maEugeniAppV1.Data;
using maEugeniAppV1.Models;
using System.Threading.Tasks;

namespace maEugeniAppV1
{
    public partial class App : Application
    {

        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;
        static RestService restService;
        private static Label labelScreen;
        private static bool hasInternet;
        private static Page currentpage;
        private static bool noInterShow;

        public App()
        {
            InitializeComponent();

            //MainPage = new maEugeniAppV1.MainPage();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //Verificar conexión con el servicio del servidor
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }
        }

        public static RestService RestService
        {
            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
        }

        public static void StartCheckIfInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constants.NoInternetText;
            label.IsVisible = false;
            hasInternet = true;
            currentpage = page;


            Device.StartTimer(TimeSpan.FromMilliseconds(3000), () =>
            {
                CheckIfInternetOverTime();
                return true;
            });
        }

        private static void CheckIfInternetOverTime()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (networkConnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await ShowDisplayAlert();
                        }
                    }

                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                    {
                        hasInternet = true;
                        labelScreen.IsVisible = false;
                    });
            }
        }

        public static async Task<bool> CheckIfInternet()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            return networkConnection.IsConnected;
        }

        public static async Task<bool> CheckIfInternetAlert()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                if (!noInterShow)
                {
                    await ShowDisplayAlert();
                }
                return false;
            }
            return true;

        }



        private static async Task ShowDisplayAlert()
        {
            noInterShow = false;
            await currentpage.DisplayAlert("Dispositivo", "El dispositivo no tiene internet", "Aceptar");
            noInterShow = false;
        }
    }
}
