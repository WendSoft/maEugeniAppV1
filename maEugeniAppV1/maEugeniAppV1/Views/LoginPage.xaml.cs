using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maEugeniAppV1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using maEugeniAppV1.Views.Menu;

namespace maEugeniAppV1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_usuario.TextColor = Constants.MainTextColor;
            Lbl_password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIncon.HeightRequest = Constants.LoginIConHeight;
            //            App.StartCheckIfInternet(lbl_NoInternet, this);
            entry_usuario.Completed += (s, e) => Entry_password.Focus();
            Entry_password.Completed += (s, e) => Button_login_Clicked(s, e);
        }

        async void Button_login_Clicked(object sender, EventArgs e)
        {
            User user = new User(entry_usuario.Text, Entry_password.Text);

            if (user.CheckUserInformation())
            {

                //var result = await App.RestService.Login(user);
                var result = new Token();
                //if (result.Access_token != null)
                if (result != null)
                {
                    await DisplayAlert("Login", "Login Correcto", "ok");
                    //App.UserDatabase.SaveUser(user);
                    //App.TokenDatabase.SaveToken(result);


                    if (Device.RuntimePlatform == Device.Android)
                    {
                        Application.Current.MainPage = new NavigationPage(new MasterDetail());
                    }
                    else if (Device.RuntimePlatform == Device.iOS)
                    {
                        await Navigation.PushModalAsync(new NavigationPage(new MasterDetail()));
                    }
                    else if (Device.RuntimePlatform == Device.Windows)
                    {
                        Application.Current.MainPage = new NavigationPage(new MasterDetail());
                    }

                }

            }
            else
            {
                await DisplayAlert("Login", "Login Incorrecto", "ok");
            }
        }
    }
}