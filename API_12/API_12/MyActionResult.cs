using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace API_12
{
    public class MyContentNegotiationResult<T> : IHttpActionResult
    {

        public MyContentNegotiationResult(T content, ApiController _controller)
        {
            Content = content;
            configuration = _controller.Configuration;
            request = _controller.Request;
        }

        public T Content { get; private set; }

        private HttpConfiguration configuration;
        private HttpRequestMessage request;
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
                IContentNegotiator negotiator = configuration.Services.GetContentNegotiator();
                ContentNegotiationResult result=negotiator.Negotiate(typeof(T), request, configuration.Formatters);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ObjectContent(typeof(T), Content, result.Formatter);
                return Task.FromResult<HttpResponseMessage>(response);
        }
    }
}