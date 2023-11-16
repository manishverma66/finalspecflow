using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;

namespace finalspecflow.Steps
{
    public class XLUtility : IDisposable
    {
        private ExcelPackage excelPackage;
        private string path;

        public XLUtility(string path)
        {
            this.path = path;
            FileInfo fileInfo = new FileInfo(path);
            excelPackage = new ExcelPackage(fileInfo);
        }

        public int GetRowCount(string sheetName)
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[sheetName];
            if (worksheet != null)
            {
                int rowCount = worksheet.Dimension.Rows;
                return rowCount;
            }
            return 0; // Handle the case where the worksheet is not found
        }

        public int GetCellCount(string sheetName, int rowNum)
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[sheetName];
            if (worksheet != null)
            {
                int cellCount = worksheet.Cells[rowNum, 1, rowNum, worksheet.Dimension.Columns].Count();
                return cellCount;
            }
            return 0; // Handle the case where the worksheet is not found
        }

        public string GetCellData(string sheetName, int rownum, int colnum)
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[sheetName];
            if (worksheet != null)
            {
                string data = worksheet.Cells[rownum, colnum].Text;
                return data;
            }
            return string.Empty; // Handle the case where the worksheet is not found
        }

        public void SetCellData(string sheetName, int rowNum, int colNum, string data)
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[sheetName];
            if (worksheet != null)
            {
                worksheet.Cells[rowNum, colNum].Value = data;
                excelPackage.Save();
            }
            // You might want to handle the case where the worksheet is not found
        }

        public void Close()
        {
            excelPackage?.Dispose();
        }

        public void Dispose()
        {
            Close();
        }
    }
}
