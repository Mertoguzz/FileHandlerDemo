using System;
using System.Reflection;
using System.Runtime.Remoting;

namespace WebLibrary
{
    public class Engine
    {
        public  ImpClass GetImpClass(string dllName, string classPath)
        {
            string path = (AppDomain.CurrentDomain.RelativeSearchPath != null ? (AppDomain.CurrentDomain.RelativeSearchPath + "\\") : AppDomain.CurrentDomain.BaseDirectory) + string.Format("{0}.dll", dllName);
            Assembly assembly = Assembly.LoadFrom(path);
            ObjectHandle handle = Activator.CreateInstance(assembly.GetName().Name, classPath);
            ImpClass implementationClass = (ImpClass)handle.Unwrap();
            return implementationClass;
        }
    }
}
