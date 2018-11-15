using Mathys.Api.IServices;
using Mathys.Api.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Mathys.Api.Services
{
    public class ExcelServices : IExcelServices
    {
        private readonly Stream _importedFile;
        private HSSFWorkbook _wb;

        public ExcelServices(Stream File)
        {
            _importedFile = File;
        }

        public async Task<List<StepModel>> ParseExcelFile()
        {
            try
            {
                _wb = new HSSFWorkbook(_importedFile);
                List<StepModel> stepList = new List<StepModel>();
                ISheet sheet = _wb.GetSheet("Sheet1");

                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    if (sheet.GetRow(row) != null)
                    {
                        StepModel stepModel = new StepModel();

                        stepModel.Classification = sheet.GetRow(row).GetCell(0, MissingCellPolicy.CREATE_NULL_AS_BLANK).StringCellValue;
                        stepModel.Order = sheet.GetRow(row).GetCell(1, MissingCellPolicy.CREATE_NULL_AS_BLANK).StringCellValue;
                        stepModel.Problem = sheet.GetRow(row).GetCell(2, MissingCellPolicy.CREATE_NULL_AS_BLANK).StringCellValue;
                        stepModel.Solution = sheet.GetRow(row).GetCell(3, MissingCellPolicy.CREATE_NULL_AS_BLANK).StringCellValue;

                        stepList.Add(stepModel);
                    }
                }
                return stepList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}