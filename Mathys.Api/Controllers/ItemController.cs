using Mathys.Api.DB;
using Mathys.Api.IServices;
using Mathys.Api.Models;
using Mathys.Api.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mathys.Api.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> AddItem(ItemModel item)
        {
            IItemServices itemServices = new ItemServices();
            item.ItemName = Regex.Replace(item.ItemName, "[^a-zA-Z0-9]", "", RegexOptions.Compiled);
            
            try
            {
                if (itemServices.DoesTableExists(item.ItemName))
                    await itemServices.DropExistingTable(item.ItemName);
                var tableName = await itemServices.CreateItemTable(item);

                IExcelServices excelServices = new ExcelServices(new MemoryStream(item.ItemContent));

                var list = await excelServices.ParseExcelFile();
                var ret = await itemServices.WriteLine(list, item.ItemName);
                return new JsonResult { Data = ret, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}