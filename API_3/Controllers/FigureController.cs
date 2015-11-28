using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using API_3.Models;
using System.IO;
using System.Text;
using System.Net.Http.Headers;
using System.Web.Http.ModelBinding;
using System.Web.Http.Routing;
using System.Net.Http.Formatting;
using Model;

namespace API_3.Controllers
{
    public class FigureController : ApiController
    {
        public IEnumerable<Figure> GetAll()
        {
            return FigureManager.Figures;
        }
        #region 状态码

        public StatusCodeResult GetStatusCodeResult()
        {
            return new StatusCodeResult(HttpStatusCode.OK, this);
        }
        public BadRequestResult GetBadRequestResult()
        {
            return new BadRequestResult(this);
        }
        public NotFoundResult GetNotFoundResult()
        {
            return new NotFoundResult(this);
        }


        public UnauthorizedResult GetUnauthorizedResult()
        {
            return new UnauthorizedResult(new List<AuthenticationHeaderValue>() { 
            new AuthenticationHeaderValue("Authorization")
            }
                , this);
        }
        public ConflictResult GetConflictResult()
        {
            return new ConflictResult(this);
        }

        public InternalServerErrorResult GetInternalServerErrorResult()
        {
            return new InternalServerErrorResult(this);
        }
        #endregion

        #region Redirect

        public RedirectResult GetRedirectResult()
        {

            UrlHelper helper = new UrlHelper(Request);
            IDictionary<string, object> route = new Dictionary<string, object>();
            route["controller"] = "Figure";
            route["action"] = "GetAll";

            return new RedirectResult(new Uri(helper.Link("DefaultApi", route)), this);
        }

        public RedirectToRouteResult GetRedirectToRouteResult()
        {
            IDictionary<string, object> route = new Dictionary<string, object>();
            route["controller"] = "Figure";
            route["action"] = "GetAll";
            return new RedirectToRouteResult("DefaultApi", route, this);
        }
        #endregion

        #region 实体
        public FormattedContentResult<IEnumerable<Figure>> GetFormattedContentResult()
        {
            return new FormattedContentResult<IEnumerable<Figure>>(HttpStatusCode.OK,
                FigureManager.Figures,
                new JsonMediaTypeFormatter(),
                new MediaTypeHeaderValue("application/json"),
                this
                );
        }

        public NegotiatedContentResult<IEnumerable<Figure>> GetNegotiatedContentResult()
        {
            return new NegotiatedContentResult<IEnumerable<Figure>>(HttpStatusCode.OK,
                FigureManager.Figures,
                this);
        }

        public OkNegotiatedContentResult<IEnumerable<Figure>> GetOkNegotiatedContentResult()
        {
            return new OkNegotiatedContentResult<IEnumerable<Figure>>(FigureManager.Figures, this);
        }

        public JsonResult<IEnumerable<Figure>> GetJsonResult()
        {
            return new JsonResult<IEnumerable<Figure>>(FigureManager.Figures, new JsonSerializerSettings(), Encoding.UTF8, this);
        }
        #endregion


        #region 错误结果
        //500
        public ExceptionResult GetExceptionResult()
        {
            return new ExceptionResult(new NotImplementedException(), this);
        }


        //400
        public BadRequestErrorMessageResult GetBadRequestErrorMessageResult()
        {
            return new BadRequestErrorMessageResult("Error", this);
        }

        //400
        public InvalidModelStateResult GetInvalidModelStateResult()
        {

            ModelStateDictionary states = new ModelStateDictionary();
            states.AddModelError("argument", new ArgumentException());
            states.AddModelError("implemented", new NotImplementedException());
            return new InvalidModelStateResult(states, this);
            //JSON: {"Message":"请求无效。","ModelState":{"argument":["值不在预期的范围内。"],"implemented":["未实现该方法或操作。"]}}
            //XML:  <Error><Message>请求无效。</Message><ModelState><argument>值不在预期的范围内。</argument><implemented>未实现该方法或操作。</implemented></ModelState></Error>
        }

        #endregion

        #region 201 Create
        public CreatedNegotiatedContentResult<IEnumerable<Figure>> GetCreatedNegotiatedContentResult()
        {
            UrlHelper helper = new UrlHelper(Request);
            IDictionary<string, object> route = new Dictionary<string, object>();
            route["controller"] = "Figure";
            route["action"] = "GetAll";
            return new CreatedNegotiatedContentResult<IEnumerable<Figure>>(new Uri(helper.Link("DefaultApi", route)), FigureManager.Figures, this);
        }


        public CreatedAtRouteNegotiatedContentResult<IEnumerable<Figure>> GetCreatedAtRouteNegotiatedContentResult()
        {
            IDictionary<string, object> route = new Dictionary<string, object>();
            route["controller"] = "Figure";
            route["action"] = "GetAll";
            return new CreatedAtRouteNegotiatedContentResult<IEnumerable<Figure>>("DefaultApi", route, FigureManager.Figures, this);

        }
        #endregion





        /**************************ApiController 方法****************************/

        public StatusCodeResult GetMethodStatusCodeResult()
        {
            return StatusCode(HttpStatusCode.OK);
        }

        public OkResult GetMethodOkResult()
        {
            return Ok();
        }

        public BadRequestResult GetMethodBadRequestResult()
        {
            return BadRequest();//??
        }
        public NotFoundResult GetMethodNotFoundResult()
        {
            return NotFound();
        }


        public ConflictResult GetMethodConflictResult()
        {
            return Conflict();
        }

        public InternalServerErrorResult GetMethodInternalServerErrorResult()
        {
            return InternalServerError();
        }

        public UnauthorizedResult GetMethodUnauthorizedResult()
        {
            return Unauthorized(new List<AuthenticationHeaderValue>() { 
            new AuthenticationHeaderValue("Authorization")
            });
        }


        public RedirectResult GetMethodRedirectResult()
        {
            UrlHelper helper = new UrlHelper(Request);
            IDictionary<string, object> route = new Dictionary<string, object>();
            route["controller"] = "Figure";
            route["action"] = "GetAll";
            return Redirect(helper.Link("DefaultApi", route));
        }



        public RedirectToRouteResult GetMethodRedirectToRouteResult()
        {
            UrlHelper helper = new UrlHelper(Request);
            IDictionary<string, object> route = new Dictionary<string, object>();
            route["controller"] = "Figure";
            route["action"] = "GetAll";
            return RedirectToRoute("DefaultApi", route);
        }


        public FormattedContentResult<List<Figure>> GetMehtodFormattedContentResult()
        {
            return Content(HttpStatusCode.OK, FigureManager.Figures,
                new JsonMediaTypeFormatter(), new MediaTypeHeaderValue("application/json"));
        }

        public NegotiatedContentResult<List<Figure>> GetMethodNegotiatedContentResult()
        {
            return Content(HttpStatusCode.OK, FigureManager.Figures);
        }

        public JsonResult<IEnumerable<Figure>> GetMehtodJsonResult()
        {
            return Json<IEnumerable<Figure>>(FigureManager.Figures);


        }

        public OkNegotiatedContentResult<List<Figure>> GetMethodOkNegotiatedContentResult()
        {
            return Ok(FigureManager.Figures);
        }


        public ExceptionResult GetMethodExceptionResult()
        {
            return InternalServerError(new NotImplementedException());
        }


        public CreatedNegotiatedContentResult<List<Figure>> GetMethodCreatedNegotiatedContentResult()
        {
            IDictionary<string, object> route = new Dictionary<string, object>();
            UrlHelper helper = new UrlHelper(Request);
            route["controller"] = "Figure";
            route["action"] = "GetAll";
            string AbsoluteUrl = helper.Link("DefaultApi", route);
            return Created(helper.Link("DefaultApi", route), FigureManager.Figures);
        }

        public CreatedAtRouteNegotiatedContentResult<List<Figure>> GetMethodCreatedAtRouteNegotiatedContentResult()
        {
            IDictionary<string, object> route = new Dictionary<string, object>();
            route["controller"] = "Figure";
            route["action"] = "GetAll";
            return CreatedAtRoute("DefaultApi", route, FigureManager.Figures);
        }

        public ResponseMessageResult GetResponseMessage()
        {
            return ResponseMessage(new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
        }

        public HttpResponseMessage GetFile()
        {
            string json = JsonConvert.SerializeObject(FigureManager.Figures);
            var buffer = Encoding.UTF8.GetBytes(json);

            MemoryStream stream = new MemoryStream(buffer);
            HttpResponseMessage result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StreamContent(stream)
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            result.Content.Headers.Add("Content-Disposition", "attachment;filename=figure.txt");
            return result;
        }

        public HttpResponseMessage GetString()
        {
            HttpResponseMessage result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("Hello World")
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            //result.Content.Headers.Add("Content-Disposition", "attachment;filename=figure.txt");
            return result;
        }
    }
}
