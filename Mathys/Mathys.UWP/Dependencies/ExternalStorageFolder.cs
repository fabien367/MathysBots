using Mathys.DepenciesServices.IServices;
using Mathys.UWP.Dependencies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(ExternalStorageFolder))]
namespace Mathys.UWP.Dependencies
{
    public class ExternalStorageFolder : IExternalStorageFolder
    {
        public string GetExternalPath()
        {
            return string.Empty;
        }
    }
}
