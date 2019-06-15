using MeatExpress.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MeatExpress.Services
{
    public class UsuarioDAO
    {
        private SQLiteConnection conexao;

        public UsuarioDAO()
        {
            string caminho = DependencyService.Get<ICaminhoSQLite>().GetCaminhoDB("carne_db.sqlite");

            conexao = new SQLiteConnection(caminho);
            conexao.CreateTable<Usuario>();
        }

        public List<Usuario> GetTodos()
        {
            return (from dados in conexao.Table<Usuario>() select dados).ToList();
        }

        public Usuario GetPorId(int id)
        {
            return conexao.Table<Usuario>().FirstOrDefault(x => x.Id == id);
        }

        public void ExlcuirTodos()
        {
            conexao.DeleteAll<Usuario>();
        }

        public void ExlcuirPorId(int id)
        {
            conexao.Delete<Usuario>(id);
        }

        public void Inserir(Usuario carne)
        {
            conexao.Insert(carne);
        }

        public void Atualizar(Usuario carne)
        {
            conexao.Update(carne);
        }
    }
}
