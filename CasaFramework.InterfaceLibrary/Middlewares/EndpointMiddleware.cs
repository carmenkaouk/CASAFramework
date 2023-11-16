
using CasaFramework.InterfaceLibrary.BaseClasses;
using CasaFramework.InterfaceLibrary.Interfaces;
using CasaFramework.InterfaceLibrary.RequestResponse;
using System.Reflection;


namespace CasaFramework.InterfaceLibrary.Middlewares;

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
      

    }
}
