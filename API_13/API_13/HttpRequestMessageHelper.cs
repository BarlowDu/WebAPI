using API_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace API_13
{
    public class HttpRequestMessageHelper
    {
        public const string HeaderName = "Request_Content";
        public static void Init(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey(HeaderName) == false)
            {
                request.Properties.Add(HeaderName, new List<FilterModel>());
            }
        }

        public static void Add(HttpRequestMessage request, FilterModel filterModel)
        {
            var requestMsg = (request.Properties[HeaderName] as List<FilterModel>);
            if (requestMsg != null)
            {
                requestMsg.Add(filterModel);
            }
        }

        public static HttpContent GetContent(HttpRequestMessage request)
        {
            var requestMsg = (request.Properties[HeaderName] as List<FilterModel>);
            HttpConfiguration configuration = request.GetConfiguration();
            IContentNegotiator negotiator = configuration.Services.GetContentNegotiator();
            var negotiatorResult = negotiator.Negotiate(typeof(List<FilterModel>), request, configuration.Formatters);
            return new ObjectContent<List<FilterModel>>(requestMsg, negotiatorResult.Formatter);
        }
    }
}