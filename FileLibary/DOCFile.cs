using NPOI.Util;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLibary
{
   
    public class DOCFile : FHFile
    {
        public XWPFDocument Document { get; set; }
        public DOCFile(string fileName, byte[] data, string contentType)
        {
            Document = new XWPFDocument(new ByteArrayInputStream(data));
            this.Name = fileName;
            this.Extension = contentType;
            this.Data = data;
        }

    }
}
