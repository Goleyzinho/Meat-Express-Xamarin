using MeatExpress.Models;
using MeatExpress.Services;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeatExpress.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AprovadoPage : ContentPage
    {

        public AprovadoPage()
        {
            InitializeComponent();
        }

        private void OnBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainTabbedPage1());
        }
    }
}