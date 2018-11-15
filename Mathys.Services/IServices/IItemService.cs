using Mathys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathys.Services.IServices
{
    public interface IItemService
    {
        Task<bool> AddNewItem(ItemModel item);
    }
}
