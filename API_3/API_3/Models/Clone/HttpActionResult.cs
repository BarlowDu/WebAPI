using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_3.Models.Clone
{

    public interface IHttpActionResult
    {
    }
    public abstract class HttpActionResult :  IHttpActionResult
    {
    }

    /// <summary>
    /// 自定义状态码
    /// </summary>
    public class CodeStatusResult : IHttpActionResult
    {
    }

    /// <summary>
    /// 400,Bad Request
    /// </summary>
    public class BadRequestResult : IHttpActionResult
    {
    }

    public class RedirectResult : IHttpActionResult
    {
    }

    /// <summary>
    /// 根据Formatter进行序列化
    /// </summary>
    public class FormattedContentResult<T> : IHttpActionResult
    {
    }

    /// <summary>
    /// 分写请求头信息进行序列化
    /// </summary>
    public class NegotiatedContentResult<T> : IHttpActionResult
    {
    }

    public class OkNegotiatedContentResult<T> : IHttpActionResult
    {
    }

    public class ExceptionResult : IHttpActionResult
    {
    }

    public class BadRequestErrorMessageResult : IHttpActionResult
    {
    }

    public class InvalidModelStateResult : IHttpActionResult
    {
    }

    public class CreatedNegotiatedContentResult<T> : IHttpActionResult
    {
    }

    public class CreatedAtRouteNegotiatedContentResult<T> : IHttpActionResult
    {
    }

    public class JsonResult<T> : IHttpActionResult
    {
    }

    public class RedirectToRouteResult
    {
    }

    /// <summary>
    /// 200,OK
    /// </summary>
    public class OkResult
    {
    }

    /// <summary>
    /// 404,Not Found
    /// </summary>
    public class NotFoundResult
    {
    }

    /// <summary>
    /// 401,UnAuthorizedResult(无授权)
    /// </summary>
    public class UnAuthorizedResult
    {
    }

    /// <summary>
    /// 409,Conflic(资源冲突)
    /// </summary>
    public class ConflictResult
    {
    }

    /// <summary>
    /// 500,Internal Server Error
    /// </summary>
    public class InternalServerErrorResult
    {
    }
}