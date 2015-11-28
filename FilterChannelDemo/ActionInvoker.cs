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
    public class ActionInvoker
    {
        Func<object, object[], Task<ResponseMessage>> executor;
        public ActionInvoker(MethodInfo methodInfo)
        {
            executor = GetExecutor(methodInfo);
        }
        public async Task<ResponseMessage> Invoke(ActionContext context, CancellationToken cancellationToken)
        {
            return await executor(context.Controller, context.Arguments);
        }

        private Func<object, object[], Task<ResponseMessage>> GetExecutor(MethodInfo methodInfo)
        {
            ParameterExpression instanceParameter = Expression.Parameter(typeof(object), "instance");
            ParameterExpression parametersParameter = Expression.Parameter(typeof(object[]), "paramters");
            List<Expression> parameters = new List<Expression>();
            ParameterInfo[] paramInfos = methodInfo.GetParameters();

            for (int i = 0; i < paramInfos.Length; i++)
            {
                ParameterInfo paramInfo = paramInfos[i];
                BinaryExpression valueObj = Expression.ArrayIndex(parametersParameter, Expression.Constant(i));
                UnaryExpression valueCast = Expression.Convert(valueObj, paramInfo.ParameterType);

                parameters.Add(valueCast);
            }

            UnaryExpression instanceCast = Expression.Convert(instanceParameter, methodInfo.ReflectedType);
            MethodCallExpression methodCall = Expression.Call(instanceCast, methodInfo, parameters);
            UnaryExpression result = Expression.Convert(methodCall, typeof(ResponseMessage));

            Expression<Func<object, object[], ResponseMessage>> lambda = Expression.Lambda<Func<object, object[], ResponseMessage>>(result, instanceParameter, parametersParameter);

            var func1 = lambda.Compile();

            Func<object, object[], Task<ResponseMessage>> func = (instance, arguments) =>
            {
                var response = func1(instance, arguments);
                return Task.FromResult<ResponseMessage>(response);
            };
            return func;
        }
    }
}
