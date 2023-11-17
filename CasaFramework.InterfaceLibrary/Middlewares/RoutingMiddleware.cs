
using CasaFramework.MainLibrary;
using CasaFramework.MainLibrary.BaseClasses;
using CasaFramework.MainLibrary.Interfaces;
using System.Reflection;


namespace CasaFramework.MainLibrary.Middlewares;

internal class RoutingMiddleware : BaseMiddleware
{
    public override void Process(Context context)
    {
        var routePieces = GetRoute(((IRequest)context.Get("Request")).GetUri()); 
        var controllerName = routePieces.ServiceName;
        var methodName = routePieces.MethodName;

        Type controllerType = Assembly.GetExecutingAssembly().GetType("CASAFramework.Controllers" + controllerName + "Controller");
        if (controllerType == null || !controllerType.IsClass)
        {
            throw new Exception("Controller not found");
        }

        BaseController controllerInstance = (BaseController)new ServiceProvider().GetService(controllerType); 
        

        MethodInfo targetMethod = controllerType.GetMethod(methodName)!;
        if (targetMethod == null)
        {
            throw new Exception("Method not found");
        }
        context.Add("ControllerInstance", controllerInstance);
        context.Add("MethodInfo", targetMethod);
        Next.Process(context);


    }
    private (string ServiceName, string MethodName) GetRoute(string requestType)
    {
        var route = requestType.Split('/');
        if (route.Length == 2 && !string.IsNullOrWhiteSpace(route[0]) && !string.IsNullOrWhiteSpace(route[1]))
        {
            var serviceName = route[0];
            var methodName = route[1];
            return (serviceName, methodName);
        }
        else
        {
            throw new Exception("Invalid Route Format");
        }

    }
}
