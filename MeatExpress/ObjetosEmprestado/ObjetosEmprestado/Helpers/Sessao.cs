using MeatExpress.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatExpress.Helpers
{
    public class Sessao
    {
        private static Sessao instancia = null;

        public static Sessao Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Sessao();

                return instancia;
            }
        }

        private Sessao() { }

        public Usuario UsuarioConectado { get; set; }
    }
}
