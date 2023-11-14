using CASAFramework.BaseClasses;
using CASAFramework.Interfaces;
using CASAFramework.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CASAFramework.Middlewares
{
    internal class EndpointMiddleware : BaseMiddleware
    {
        public override void Process(Context context)
        {
            var controllerInstance =context.Get("ControllerInstance");
            var parameters = ((object[])context.Get("Parameters"));
            var targetMethod = ((MethodInfo)context.Get("MethodInfo"));
            var result = targetMethod.Invoke(controllerInstance, parameters);
            object responseContent = result;
            if (result is Task taskResult)
            {
                taskResult.GetAwaiter().GetResult();
                responseContent = taskResult.GetType().IsGenericType ? taskResult.GetType().GetProperty("Result").GetValue(taskResult) : null; ;
            }

            IResponse response = (IResponse)context.Get("IResponse");
            response.SetStatusCode(StatusCode.Success);
            response.SetResponseContent(responseContent); 
            response.SendResponse();

        }
    }
}
