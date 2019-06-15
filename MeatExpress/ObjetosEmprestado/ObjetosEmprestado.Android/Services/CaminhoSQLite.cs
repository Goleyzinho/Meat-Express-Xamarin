using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MeatExpress.Services;
using MeatExpress.Droid.Services;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(CaminhoSQLite))]
namespace MeatExpress.Droid.Services
{
    public class CaminhoSQLite : ICaminhoSQLite
    {
        public string GetCaminhoDB(string nomeDB)
        {
            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(caminho, nomeDB);
        }
    }
}