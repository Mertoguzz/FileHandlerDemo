using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using NPOI.Util;

namespace FileLibary
{
    public class XLSXFile : ExcelFile
    {
        public XSSFWorkbook Workbook { get; set; }

        public XLSXFile(string fileName, byte[] data, string contentType)
        {
            ByteArrayInputStream inputStream = new ByteArrayInputStream(data);
            this.Name = fileName;
            this.Extension = contentType;
            this.Data = data;
            this.Workbook = new XSSFWorkbook(inputStream);
        }
        public XLSXFile()
        {
            this.Workbook = new XSSFWorkbook();
        }

        public override DataSet WorkbookToDataTable()
        {
            DataSet result = null;
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    Workbook.Write(stream);
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    result = excelReader.AsDataSet();
                    excelReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            
            return result;
        }


    }
}
