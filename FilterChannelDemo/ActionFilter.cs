using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilterChannelDemo
{
    public abstract class ActionFilter : IActionFilter
    {
        public virtual void OnActionExecuting(ActionContext actionContext)
        {
        }

        public virtual void OnActionExecuted(ActionContext actionContext)
        {
        }

        public Task OnActionExecutingAsync(ActionContext actionContext)
        {
            OnActionExecuting(actionContext);

            return Task.FromResult<AsyncVoid>(default(AsyncVoid));
        }


        public Task OnActionExecutedAsync(ActionContext actionContext, CancellationToken cancellationToken)
        {
            OnActionExecuted(actionContext);
            return Task.FromResult<AsyncVoid>(default(AsyncVoid));
        }
        public Task<ResponseMessage> ExecuteActionFilterAsync(ActionContext actionContext, System.Threading.CancellationToken cancellationToken, Func<Task<ResponseMessage>> continuation)
        {
            return ExecuteActionFilterAsyncCore(actionContext, cancellationToken, continuation);

        }
        private async Task<ResponseMessage> ExecuteActionFilterAsyncCore(ActionContext actionContext, CancellationToken cancellationToken, Func<Task<ResponseMessage>> continuation)
        {
            await OnActionExecutingAsync(actionContext);

            if (actionContext.Response != null)
            {
                return actionContext.Response;
            }

            return await CallOnActionExecutedAsync(actionContext, cancellationToken, continuation);
        }

        private async Task<ResponseMessage> CallOnActionExecutedAsync(ActionContext actionContext, CancellationToken cancellationToken, Func<Task<ResponseMessage>> continuation)
        {
            ResponseMessage response = null; ;
            try
            {
                response = await continuation();
            }
            catch (Exception ex)
            {
            }
            await OnActionExecutedAsync(actionContext, cancellationToken);
            return response;
            //throw new NotImplementedException();
        }

    }
}
