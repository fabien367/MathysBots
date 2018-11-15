using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Mathys.DepenciesServices.IServices
{
    public interface ICreateFileInDownloads
    {
        Task<bool> CreateFile(string FileName, Stream content);
    }
}
