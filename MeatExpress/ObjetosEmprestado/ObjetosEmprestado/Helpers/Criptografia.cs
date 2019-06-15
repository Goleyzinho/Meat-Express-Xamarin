using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MeatExpress.Helpers
{
    public static class Criptografia
    {
        public static string GetMD5Hash(string texto)
        {
            MD5 md5 = MD5.Create();
            byte[] dados = Encoding.ASCII.GetBytes(texto);
            byte[] hash = md5.ComputeHash(dados);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));
            return sb.ToString();
        }
    }
}
