using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using maEugeniAppV1.Views;
using Xamarin.Forms;
using maEugeniAppV1.Data;

namespace maEugeniAppV1
{
    public partial class App : Application
    {

        public static TokenDatabaseController tokenDatabase;
        public static UserDatabaseController userDatabase;
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
    }
}
