using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilterChannelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            MethodInfo actionMethod = typeof(Controller).GetMethod("Get");

            CancellationToken cancellationToken = new CancellationToken();

            List<IActionFilter> filters = new List<IActionFilter>() { 
            new FirstActionFilter(),
            new SecondActionFilter()
            };
            ActionContext context = new ActionContext()
            {
                Controller = controller,
                Action = actionMethod,
                Arguments = new object[0]
            };
            ActionInvoker invoker = new ActionInvoker(context.Action);

            Func<Task<ResponseMessage>> result = () =>
            {
                return invoker.Invoke(context, cancellationToken);
            };

            for (int i = 0; i <= filters.Count - 1; i++)
            {
                IActionFilter filter = filters[i];

                Func<Func<Task<ResponseMessage>>, IActionFilter, Func<Task<ResponseMessage>>> chainContinuation =
                    (continuation, innerFilter) =>
                    {
                        return () =>
                        {
                            return innerFilter.ExecuteActionFilterAsync(context, cancellationToken, continuation);
                        };
                    };
                result = chainContinuation(result, filter);
            }
            //string res = continuation()().Result.Message;
            result.Invoke();
            Console.ReadKey();
        }
    }
}
