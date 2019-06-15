using MeatExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeatExpress.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagamentoPage : ContentPage
    {
        public PagamentoPage()
        {
            InitializeComponent();
        }

        public bool PodeFazerPagamento(Usuario usuario)
        {
            return !string.IsNullOrEmpty(usuario.Nome) && !string.IsNullOrEmpty(usuario.CPF) 
                && !string.IsNullOrEmpty(usuario.CardCod) && !string.IsNullOrEmpty(usuario.DataVal.ToString()) 
                && !string.IsNullOrEmpty(usuario.Band) && !string.IsNullOrEmpty(usuario.NumCard);
        }

        private void OnDebito(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new AprovadoPage());
        }

        private void OnCredito(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = Nome.Text;
            usuario.CPF = CPF.Text;
            usuario.CardCod = CardCod.Text;
            usuario.DataVal = DataVal.Date;
            usuario.Band = Band.Text;
            usuario.NumCard = NumCard.Text;

            if (!PodeFazerPagamento(usuario))
            {
                DisplayAlert("Pagamento", "Preencha todos os campos!!!", "OK");
                return;
            }

            Application.Current.MainPage = new NavigationPage(new AprovadoPage());
        }

        private void OnBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainTabbedPage1());
        }
    }
}