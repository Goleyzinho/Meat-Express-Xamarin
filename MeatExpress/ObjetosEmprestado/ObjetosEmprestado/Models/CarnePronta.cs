using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatExpress.Models
{
    public class CarnePronta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public bool Separado { get; set; }
        public bool Selecionado { get; set; }
    }
}
