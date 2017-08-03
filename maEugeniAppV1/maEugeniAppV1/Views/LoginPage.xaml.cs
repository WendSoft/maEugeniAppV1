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
        }

        private void Button_login_Clicked(object sender, EventArgs e)
        {
            User user = new User(entry_usuario.Text, Entry_password.Text);

            if (user.CheckUserInformation())
            {
                DisplayAlert("Login", "Login Correcto", "ok");
            }
            else
            {
                DisplayAlert("Login", "Login Incorrecto ", "ok");
            }
        }
    }
}