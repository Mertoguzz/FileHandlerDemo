using BaseImpClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace WebEngine
{
    public class Engine
    {
        public  BaseImpClass GetImpClass(string dllName, string classPath)
        {
            string path = (AppDomain.CurrentDomain.RelativeSearchPath != null ? (AppDomain.CurrentDomain.RelativeSearchPath + "\\") : AppDomain.CurrentDomain.BaseDirectory) + string.Format("{0}.dll", dllName);
            Assembly assembly = Assembly.LoadFrom(path);
            ObjectHandle handle = Activator.CreateInstance(assembly.GetName().Name, classPath);
            BaseImpClass implementationClass = (BaseImpClass)handle.Unwrap();
            return implementationClass;
        }
    }
}
