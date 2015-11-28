using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilterChannelDemo
{
    public class ExpressionTree
    {
        public static Func<object, object[], object> Exec(MethodInfo methodInfo)
        {
            //Func<object, object[], ResponseMessage> func = (instance, parames) =>
            //{
            //    return (methodInfo.Invoke(instance, parames) as ResponseMessage);
            //};

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
            UnaryExpression result = Expression.Convert(methodCall, typeof(object));

            Expression<Func<object, object[], object>> lambda = Expression.Lambda<Func<object, object[], object>>(result, instanceParameter, parametersParameter);
            var func = lambda.Compile();

            return func;

        }
    }
}
