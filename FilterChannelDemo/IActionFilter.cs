using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilterChannelDemo
{
    public interface IActionFilter
    {
        Task<ResponseMessage> ExecuteActionFilterAsync(ActionContext actionContext, CancellationToken cancellationToken, Func<Task<ResponseMessage>> continuation);
    }
}
