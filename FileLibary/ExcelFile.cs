using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLibary
{
    public abstract class ExcelFile: FHFile
    {
        public Stream ByteArrayToStream(byte[] data)
        {
            MemoryStream stream = null;
            using (stream = new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
            }
            return stream;

        }

        public virtual DataSet WorkbookToDataTable()
        {
            return new DataSet();
        }
    }

 
}
