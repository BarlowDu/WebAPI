using API_13.App_Start;
using API_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_13.Controllers
{
    public class ExceptionController : ApiController
    {
        /*当Action本身抛出异常时,ActionFilter管道会继续执行,并最终进入ExceptionFilter管道*/
        [ExceptionFilterFirst]
        [ActionFilterSecond]
        public void GetActionException()
        {
            HttpRequestMessageHelper.Add(Request, new FilterModel() { Message = "Action" });
            throw new Exception("test");
        }

        /*当ActionFilter的OnActionExecuting方法抛出异常时,ActionFilter管道结束执行,并进入ExceptionFilter管道*/
        [ExceptionFilterFirst]
        [ExcutingExceptionActionFilter]
        public void GetActionFilterExecutingException()
        {
            HttpRequestMessageHelper.Add(Request, new FilterModel() { Message = "Action" });
        }

        /*当ActionFilter的OnActionExecuted方法抛出异常时,ActionFilter管道会继续执行,并最终进入ExceptionFilter管道*/
        [ExceptionFilterFirst]
        [ExcutedExceptionActionFilter]
        public void GetActionFilterExecutedException()
        {
            HttpRequestMessageHelper.Add(Request, new FilterModel() { Message = "Action" });
        }


        /*当ExceptionFilter中抛出异常时,后续ExceptionFilter不会执行*/
        [ExceptionFilterFirst]
        [ExceptionFilterThird]
        public void GetExceptionFilterError()
        {
            HttpRequestMessageHelper.Add(Request, new FilterModel() { Message = "Action" });
        }
    }
}
