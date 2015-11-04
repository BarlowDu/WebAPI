using API_9.Controllers;
using API_9.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace API_9.App_Start
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        static UnityDependencyResolver instance;
        IUnityContainer container = new UnityContainer();
        private UnityDependencyResolver()
        {
            container.RegisterType(typeof(DemoController));
            container.RegisterType<IPrintService, LaserPrintService>();
        }

        static UnityDependencyResolver()
        {
            instance = new UnityDependencyResolver();
        }
        public static UnityDependencyResolver Instance
        {
            get { return instance; }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}