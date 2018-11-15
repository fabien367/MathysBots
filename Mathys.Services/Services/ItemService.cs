using Mathys.Models;
using Mathys.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mathys.Services.Services
{
    public class ItemService : APIServices, IItemService
    {
        public ItemService()
        {
        }

        public async Task<bool> AddNewItem(ItemModel item)
        {
            try
            {
                var obj = JsonConvert.SerializeObject(item);
                var content = new StringContent(obj, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(uriBase + @"Item/AddItem", content);

                var result = await response.Content.ReadAsStringAsync();
                var objBack = JsonConvert.DeserializeObject<bool>(result);
                return objBack;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
