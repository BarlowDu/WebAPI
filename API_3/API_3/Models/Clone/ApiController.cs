using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace API_3.Models.Controller
{
    public abstract class ApiController
    {
        
        protected internal virtual InvalidModelStateResult BadRequest(ModelStateDictionary modelState);
 
        protected internal virtual NegotiatedContentResult<T> Content<T>(HttpStatusCode statusCode, T value);
     
        protected internal FormattedContentResult<T> Content<T>(HttpStatusCode statusCode, T value, MediaTypeFormatter formatter);
      
        protected internal virtual FormattedContentResult<T> Content<T>(HttpStatusCode statusCode, T value, MediaTypeFormatter formatter, MediaTypeHeaderValue mediaType);
      
        protected internal FormattedContentResult<T> Content<T>(HttpStatusCode statusCode, T value, MediaTypeFormatter formatter, string mediaType);
      
        protected internal CreatedNegotiatedContentResult<T> Created<T>(string location, T content);
      
        protected internal virtual CreatedNegotiatedContentResult<T> Created<T>(Uri location, T content);
     
        protected internal virtual CreatedAtRouteNegotiatedContentResult<T> CreatedAtRoute<T>(string routeName, IDictionary<string, object> routeValues, T content);
     
        protected internal CreatedAtRouteNegotiatedContentResult<T> CreatedAtRoute<T>(string routeName, object routeValues, T content);


     
        protected internal virtual InternalServerErrorResult InternalServerError();
     
        protected internal virtual ExceptionResult InternalServerError(Exception exception);
     
        protected internal JsonResult<T> Json<T>(T content);
  
        protected internal JsonResult<T> Json<T>(T content, JsonSerializerSettings serializerSettings);
    
        protected internal virtual JsonResult<T> Json<T>(T content, JsonSerializerSettings serializerSettings, Encoding encoding);
      
        protected internal virtual NotFoundResult NotFound();
     
        protected internal virtual OkResult Ok();
    
        protected internal virtual OkNegotiatedContentResult<T> Ok<T>(T content);
     
        protected internal virtual RedirectResult Redirect(string location);

        protected internal virtual RedirectResult Redirect(Uri location);
     
        protected internal virtual RedirectToRouteResult RedirectToRoute(string routeName, IDictionary<string, object> routeValues);
    
        protected internal RedirectToRouteResult RedirectToRoute(string routeName, object routeValues);
      
        protected internal virtual ResponseMessageResult ResponseMessage(HttpResponseMessage response);
       
        protected internal virtual StatusCodeResult StatusCode(HttpStatusCode status);
      
        protected internal virtual UnauthorizedResult Unauthorized(IEnumerable<AuthenticationHeaderValue> challenges);
      
        protected internal UnauthorizedResult Unauthorized(params AuthenticationHeaderValue[] challenges);
        
    }
}