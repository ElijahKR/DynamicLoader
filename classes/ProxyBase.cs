using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLoader
{
    public abstract class ProxyBase : MarshalByRefObject
    {
        protected Assembly assembly = null;
        protected ISubjectBase instance = null;
        protected Type dType = null;

        public ProxyBase(string path, string typeName)
        {
            assembly = Assembly.LoadFrom(path);
            if (assembly == null)
            {
                throw new Exception(string.Format("failed to load assembly from path \"{0}\".", path));
            }

            dType = assembly.GetType(typeName);
            if (dType == null)
            {
                throw new Exception(string.Format("failed to get type from \"{0}\"", typeName));
            }

            instance = Activator.CreateInstance(dType) as ISubjectBase;
            if (instance == null)
            {
                throw new Exception(string.Format("failed to create instance from type \"{0}\"", dType.ToString()));
            }
        }

        protected MethodInfo InitMethod(string methodName)
        {
            MethodInfo method = dType.GetMethod(methodName);
            if (method == null)
            {
                throw new Exception(string.Format("failed to get method.{0}type is \"{1}\".{0}method name is \"{2}\".",
                    Environment.NewLine,
                    dType.ToString(),
                    methodName));
            }

            return method;
        }
    }
}
