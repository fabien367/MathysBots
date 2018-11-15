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

[assembly: Dependency(typeof(CreateFileDownloads))]
namespace Mathys.UWP.Dependencies
{
    public class CreateFileDownloads : ICreateFileInDownloads
    {
        public async Task<bool> CreateFile(string FileName, Stream content)
        {
            try
            {
                var storageFile = await Windows.Storage.DownloadsFolder.CreateFileAsync(FileName, CreationCollisionOption.GenerateUniqueName);

                byte[] buffer = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    content.CopyTo(ms);
                    buffer = ms.ToArray();
                }
                var f = Windows.Storage.FileIO.WriteBytesAsync(storageFile, buffer);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
