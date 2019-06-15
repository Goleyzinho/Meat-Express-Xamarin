using MeatExpress.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatExpress.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public List<CarnePronta> Emprestimos { get; set; }
        public string CPF { get; internal set; }
        public string CardCod { get; internal set; }
        public DateTime DataVal { get; internal set; }
        public string Band { get; internal set; }
        public string NumCard { get; internal set; }
    }
}
