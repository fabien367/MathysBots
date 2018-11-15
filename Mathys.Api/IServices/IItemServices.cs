using Mathys.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Mathys.Api.IServices
{
    public interface IItemServices
    {
        Task<string> CreateItemTable(ItemModel item);
        Task DropExistingTable(string TableName);
        bool DoesTableExists(string TableName);
        Task<bool> WriteLine(List<StepModel> list, string TableName);
    }
}