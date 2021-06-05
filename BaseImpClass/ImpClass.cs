using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary
{
    public abstract class ImpClass : BaseImpClass
    {
        public ImpClass()
        {

        }
        public virtual string UploadExcel(DataTable dt, string token)
        {
            return this.UploadExcel(dt, token);
        }
    }
}

