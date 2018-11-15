using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Mathys.DepenciesServices.IServices;
using Mathys.Droid.Dependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(ExternalStorageFolder))]
namespace Mathys.Droid.Dependencies
{
    public class ExternalStorageFolder : IExternalStorageFolder
    {
        public string GetExternalPath()
        {
            return Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDocuments);
        }
    }
}