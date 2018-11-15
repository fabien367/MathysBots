using Mathys.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathys.Api.IServices
{
    public interface IExcelServices
    {
        Task<List<StepModel>> ParseExcelFile();
    }
}
