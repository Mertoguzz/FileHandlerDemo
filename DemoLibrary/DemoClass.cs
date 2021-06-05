using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLibrary;

namespace DemoLibrary
{
    public class DemoClass:ImpClass
    {
        public override string UploadExcel(DataTable dt, string token)
        {
            string retVal = string.Empty;
            if (dt == null || dt.Rows.Count==0)
            {
                retVal = "(xlsx)Excel' in ilk Sheeti Boş";
            }
            return retVal;
        }
    }
}
