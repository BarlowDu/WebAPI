using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace API_13
{
    public class FilterMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            request.Properties.Add("Response_Content", new List<string>());
            HttpRequestMessageHelper.Init(request);
            HttpResponseMessage response = base.SendAsync(request, cancellationToken).Result;
            GetResponseMessageFromRequest(request, response);
            return Task.FromResult(response);
        }

        private void GetResponseMessageFromRequest(HttpRequestMessage request, HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.NoContent||
                response.StatusCode == HttpStatusCode.InternalServerError)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Content = HttpRequestMessageHelper.GetContent(request);
            }
        }
    }
}