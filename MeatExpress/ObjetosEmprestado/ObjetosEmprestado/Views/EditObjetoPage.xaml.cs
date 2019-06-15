using MeatExpress.Helpers;
using MeatExpress.Models;
using MeatExpress.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeatExpress.Views
{
 
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditcarnePage : ContentPage
	{
        public enum EditType { Separar, Excluir, Nenhum };

        private CarnePronta CarnePronta;

        public EditcarnePage (CarnePronta CarnePronta, EditType tipo)
		{
			InitializeComponent ();

            if (CarnePronta != null) // Editar / Excluir
            {
                this.CarnePronta = CarnePronta;
                DescricaoEntry.Text = CarnePronta.Descricao;
                NomeEntry.Text = CarnePronta.Nome;
                PrecoEntry.Text = CarnePronta.Preco;
                Title = "Editar os carnes emprestados";
                SalvarButton.IsVisible = false;
                SalvarMenuButton.IsVisible = false;
                AttButton.IsVisible = true;
                if (tipo == EditType.Excluir)
                    ExcluirButton.IsVisible = true;
                else if (tipo == EditType.Separar)
                    SepararButton.IsVisible = true;

            }
            else // Novo
            {
                Title = "Nova Carne";
            }

            /*
            DescricaoEntry.Text = CarnePronta.Descricao;
            NomeEntry.Text = CarnePronta.Nome;
            DataEntry.Text = CarnePronta.Data.ToString("dd/MM/yyyy");
            */
        }

        private void OnSalvar(object sender, System.EventArgs e)
        {
            // Criar
            CarnePronta carne = new CarnePronta();
            carne.Descricao = DescricaoEntry.Text;
            carne.Nome = NomeEntry.Text;
            carne.Preco = PrecoEntry.Text;

            CarneDAO dao = new CarneDAO();
            dao.Inserir(carne);

            Navigation.PopAsync();
        }

        private void OnAtt(object sender, System.EventArgs e)
        {
            // Att
            CarnePronta.Descricao = DescricaoEntry.Text;
            CarnePronta.Nome = NomeEntry.Text;
            CarnePronta.Preco = PrecoEntry.Text;

            CarneDAO dao = new CarneDAO();
            dao.Atualizar(CarnePronta);

            Navigation.PopAsync();
        }

        private void OnExcluir(object sender, System.EventArgs e)
        {

            CarneDAO dao = new CarneDAO();
            dao.ExlcuirPorId(CarnePronta.Id);

            Navigation.PopAsync();
        }

        private void OnSeparar(object sender, EventArgs e)
        {
            CarneDAO dao = new CarneDAO();
            dao.Separar(CarnePronta);

            Navigation.PopAsync();
        }

        private void OnSalvar2(object sender, EventArgs e)
        {
            CarnePronta carne = new CarnePronta();
            carne.Descricao = DescricaoEntry.Text;
            carne.Nome = NomeEntry.Text;
            carne.Preco = PrecoEntry.Text;

            CarneDAO dao = new CarneDAO();
            dao.Separar(carne);

            Navigation.PopAsync();
        }
    }
}