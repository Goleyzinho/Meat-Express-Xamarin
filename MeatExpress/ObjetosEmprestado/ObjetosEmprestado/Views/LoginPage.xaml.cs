using MeatExpress.Helpers;
using MeatExpress.Models;
using MeatExpress.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeatExpress.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        public bool PodeFazerLogin(Usuario usuario)
        {
            return !string.IsNullOrEmpty(usuario.Email) && !string.IsNullOrEmpty(usuario.Senha);
        }

        private void OnLogin(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Email = Email.Text;
            usuario.Senha = Senha.Text;

            if (!PodeFazerLogin(usuario))
            {
                DisplayAlert("Login", "Preencha todos os campos!!!", "OK");
                return;
            }

            if (!string.Equals(usuario.Email.ToString(), "juninho"))
            {   
                    DisplayAlert("Login", "Usuario ou senha invalido!!!", "OK");
                    return;
            }

            if (!string.Equals(usuario.Senha.ToString(), "123456"))
            {
                DisplayAlert("Login", "Usuario ou senha invalido!!!", "OK");
                return;
            }

            Application.Current.MainPage = new NavigationPage(new MainTabbedPage()); 
        }

        private void OnBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new InitialPage());
        }
    }
}