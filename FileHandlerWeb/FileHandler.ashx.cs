using FileLibary;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.SessionState;
using WebLibrary;

namespace FileHandlerWeb
{
    /// <summary>
    /// Summary description for FileHnadler
    /// </summary>
    public class FileHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string message = "";
            HttpPostedFile file = context.Request.Files[0];
            Engine engine = new Engine();
            string impTestDll = ConfigurationManager.AppSettings["ImplementationTestLibrary"];
            string impTestCls = ConfigurationManager.AppSettings["ImplementationTestClass"];
            try
            {
                ImpClass impClass = engine.GetImpClass(impTestDll, impTestCls);
                DataSet data = null;
                switch (file.ContentType)
                {
                    case Constants.FileExtensions.XLSX:
                        {
                            ExcelFile currentFile = new XLSXFile(file.FileName, GetBytes(file), file.ContentType);
                            data = currentFile.WorkbookToDataTable();
                            if (data.Tables.Count > 0)
                                message = impClass.UploadExcel(data.Tables[0], "INSERT");
                            break;
                        }
                    case Constants.FileExtensions.XLS:
                        {
                            ExcelFile currentFile = new XLSFile(file.FileName, GetBytes(file), file.ContentType);
                            data = currentFile.WorkbookToDataTable();
                            if (data.Tables.Count > 0)
                                message = impClass.UploadExcel(data.Tables[0], "INSERT");
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "OK", message = message }));
            }




        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public byte[] GetBytes(HttpPostedFile file)
        {
            byte[] fileData = null;

            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            return fileData;
        }

    }
}