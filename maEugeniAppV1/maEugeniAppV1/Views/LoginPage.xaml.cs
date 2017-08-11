using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maEugeniAppV1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            entry_usuario.Completed += (s, e) => Entry_password.Focus();
            Entry_password.Completed += (s, e) => Button_login_Clicked(s, e);
        }

        private void Button_login_Clicked(object sender, EventArgs e)
        {
            User user = new User(entry_usuario.Text, Entry_password.Text);

            if (user.CheckUserInformation())
            {
                DisplayAlert("Login", "Login Correcto", "ok");
                App.UserDatabase.SaveUser(user);
            }
            else
            {
                DisplayAlert("Login", "Login Incorrecto", "ok");
            }
        }
    }
}