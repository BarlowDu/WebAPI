using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Dispatcher;

namespace API_6
{
    public class HttpMethodChangeHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var method = request.Method;
            if(request.Method == HttpMethod.Post)
            {
                request.Method = HttpMethod.Put;
            }
            else if(request.Method == HttpMethod.Put)
            {
                request.Method = HttpMethod.Post;
            }
            return base.SendAsync(request, cancellationToken);
        }


    }

    public class AllBackHttpMessageHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return Task.Run<HttpResponseMessage>(() =>
            {
                HttpResponseMessage result = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                result.Content = new StringContent("AllHttpMessageHandler");
                return result;
                

            });
        }
    }
}