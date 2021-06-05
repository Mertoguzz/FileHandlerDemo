using ExcelDataReader;
using NPOI.HSSF.UserModel;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLibary
{
    public  class XLSFile : ExcelFile
    {
        public HSSFWorkbook Workbook { get; set; }

        public XLSFile(string fileName, byte[] data, string contentType)
        {
            ByteArrayInputStream inputStream = new ByteArrayInputStream(data);
            this.Name = fileName;
            this.Extension = contentType;
            this.Data = data;
            this.Workbook = new HSSFWorkbook(inputStream);
        }
        public XLSFile()
        {
            this.Workbook = new HSSFWorkbook();
        }

        public override DataSet WorkbookToDataTable()
        {
            DataSet result = null;
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    Workbook.Write(stream);
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
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
