using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLoader
{
    public class SubjectProxy : ProxyBase, ISubjectBase
    {
        public SubjectProxy(string path, string typeName) : base (path, typeName)
        {
        }

        public int Add(int a, int b)
        {
            string methodName = MethodBase.GetCurrentMethod().Name;
            MethodInfo method = InitMethod(methodName);
            return (int)method.Invoke(instance, new object[] { a, b });
        }

        public void Show(string txt)
        {
            string methodName = MethodBase.GetCurrentMethod().Name;
            MethodInfo method = InitMethod(methodName);
            method.Invoke(instance, new object[] { txt });
        }
    }
}
