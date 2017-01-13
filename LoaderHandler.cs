using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLoader
{
    public class LoaderHandler<T>
    {
        private AppDomain dynamicDomain = null;
        private T proxy = default(T);

        public LoaderHandler(string path, string typeName)
        {
            Evidence evidence = new Evidence(AppDomain.CurrentDomain.Evidence);
            AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;

            dynamicDomain = AppDomain.CreateDomain("DynamicDomain", evidence, setup);
            if (dynamicDomain != null)
            {
                Type tLoader = typeof(T);
                //proxy = dynamicDomain.CreateInstanceFrom(tLoader.Assembly.Location, tLoader.FullName).Unwrap() as SubjectProxy;
                proxy = (T)dynamicDomain.CreateInstanceFrom(
                    tLoader.Assembly.Location, 
                    tLoader.FullName, 
                    true, 
                    System.Reflection.BindingFlags.CreateInstance, 
                    null, 
                    new object[] { path, typeName}, 
                    null, null).Unwrap();

                if (proxy == null)
                {
                    throw new Exception(string.Format("failed to load \"{0}\".{1}the path is \"{2}\".", typeName, Environment.NewLine, path));
                }
            }
            else
            {
                throw new Exception("failed to initialize dynamic domain.");
            }
        }

        public T GetProxy()
        {
            return proxy;
        }

        public void Unload()
        {
            if (dynamicDomain != null)
            {
                AppDomain.Unload(dynamicDomain);
            }
        }
    }
}
