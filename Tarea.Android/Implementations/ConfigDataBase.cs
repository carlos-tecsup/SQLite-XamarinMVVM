using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xamarin.Forms;

using Tarea.Interfaces;
using Tarea.Droid.Implementations;

[assembly: Dependency(typeof(ConfigDataBase))]
namespace Tarea.Droid.Implementations
{
    class ConfigDataBase : IConfigDataBase
    {
        public string GetDbPath()
        {
            return "hol";
        }

        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), databaseFileName);
        }
    }

}
