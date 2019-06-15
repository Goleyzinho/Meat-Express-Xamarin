using MeatExpress.Models;
using MeatExpress.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeatExpress.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        private ObservableCollection<CarnePronta> MeatExpresss;

        public MenuView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            MeatExpresss = GetTodosMeatExpresss();

            carneListView.ItemsSource = MeatExpresss;

            base.OnAppearing();
        }

        public ObservableCollection<CarnePronta> GetTodosMeatExpresss()
        {
            CarneDAO dao = new CarneDAO();
            return new ObservableCollection<CarnePronta>(dao.GetTodos());
        }

        private void OncarneSelecionado(object sender, SelectedItemChangedEventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new PagamentoPage());
        }

        private void OncarneProcurado(object sender, TextChangedEventArgs e)
        {
            string texto = carneSearchBar.Text;
            carneListView.ItemsSource = MeatExpresss.Where(
                x => x.Descricao.ToLowerInvariant().Contains(texto.ToLowerInvariant())
            );
        }
        
        private void OnHelp(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new HelpPage());
        }
    }
}