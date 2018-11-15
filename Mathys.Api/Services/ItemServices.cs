using Mathys.Api.DB;
using Mathys.Api.IServices;
using Mathys.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Mathys.Api.Services
{
    public class ItemServices : IItemServices
    {
        public async Task<string> CreateItemTable(ItemModel item)
        {
            string request = @"CREATE TABLE [dbo].[{0}](
                         [ID] [int] IDENTITY(1,1) NOT NULL,
                         [Classification] [varchar](max) NOT NULL,
                         [OrderSolution] [int] NOT NULL,
                         [Problem] [varchar](max) NOT NULL,
                         [Solution] [varchar](max) NOT NULL,
                         CONSTRAINT [{0}$0] PRIMARY KEY CLUSTERED 
                         ([ID] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,
                         IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                         ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]";
            try
            {
                using (var context = new Context())
                {
                    string FinalReq = string.Format(request, item.ItemName);

                    context.Database.ExecuteSqlCommand(FinalReq);

                    return item.ItemName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DoesTableExists(string TableName)
        {
            string request = @"SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES
                 WHERE TABLE_SCHEMA = 'dbo'
                 AND TABLE_NAME = '{0}'";
            try
            {
                using (var context = new Context())
                {
                    string finalReq = string.Format(request, TableName);
                    return context.Database.SqlQuery<object>(finalReq).Any();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> WriteLine(List<StepModel> list, string TableName)
        {
            bool isCompleted = true;
            try
            {
                using (var context = new Context())
                {
                    foreach (var step in list)
                    {
                        var ret = context.Database.ExecuteSqlCommand("exec dbo.WriteLine @TableName={0}, @Classification={1}, @OrderSolution={2}, @Problem={3}, @Solution={4}",
                            TableName, step.Classification, step.Order, step.Problem, step.Solution);
                        if (ret == -1)
                            isCompleted = false;
                    }
                    return isCompleted;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DropExistingTable(string TableName)
        {
            try
            {
                using (var context = new Context())
                {
                    var ret = context.Database.ExecuteSqlCommand("exec dbo.DropTable @TableName={0}", TableName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}