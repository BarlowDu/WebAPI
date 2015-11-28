using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ValueProviders;

namespace API_8.Controllers
{
    public class MyValueProviderFactory : ValueProviderFactory
    {

        public override IValueProvider GetValueProvider(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            throw new NotImplementedException();
        }
    }
}