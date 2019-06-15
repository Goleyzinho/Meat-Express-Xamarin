using MeatExpress.Helpers;
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
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        private void OnLogout(object sender, EventArgs e)
        {
            Sessao.Instancia.UsuarioConectado = null;
            Application.Current.MainPage = new LoginPage();
        }
    }
}