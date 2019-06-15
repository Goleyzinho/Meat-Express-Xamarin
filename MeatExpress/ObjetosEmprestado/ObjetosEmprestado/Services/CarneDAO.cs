using MeatExpress.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MeatExpress.Services
{
    class CarneDAO
    {

        private SQLiteConnection conexao;

        public CarneDAO()
        {
            string caminho = DependencyService.Get<ICaminhoSQLite>().GetCaminhoDB("carne_db.sqlite");

            conexao = new SQLiteConnection(caminho);
            conexao.CreateTable<CarnePronta>();
        }

        public List<CarnePronta> GetTodos()
        {
            return (from dados in conexao.Table<CarnePronta>() select dados).ToList();
        }

        public List<CarnePronta> GetPromo()
        {
            return (from dados in conexao.Table<CarnePronta>() where !dados.Separado select dados).ToList();
        }

        public List<CarnePronta> GetMenuToo()
        {
            return (from dados in conexao.Table<CarnePronta>() where dados.Separado select dados).ToList();
        }

        public List<CarnePronta> GetSelecionado()
        {
            return (from dados in conexao.Table<CarnePronta>() where dados.Selecionado select dados).ToList();
        }

        public CarnePronta GetPorId(int id)
        {
            return conexao.Table<CarnePronta>().FirstOrDefault(x => x.Id == id);
        }

        public void ExlcuirTodos()
        {
            conexao.DeleteAll<CarnePronta>();
        }

        public void ExlcuirPorId(int id)
        {
            conexao.Delete<CarnePronta>(id);
        }

        public void Inserir(CarnePronta carne)
        {
            conexao.Insert(carne);
        }

        public void Atualizar(CarnePronta carne)
        {
            conexao.Update(carne);
        }

        public void Separar(CarnePronta carne)
        {
            carne.Separado = true;
            conexao.Insert(carne);
        }

        public void Selecionar(CarnePronta carne)
        {
            carne.Selecionado = true;
        }

    }
}
