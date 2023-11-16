using CASAFramework.BaseClasses;
using CASAFramework.Interfaces;
using CASAFramework.Middlewares;
using CASAFramework.RequestResponse;
using Microsoft.Extensions.Configuration;

namespace CASAFramework;

public class App
{
    private IListener _listener;
    private List<BaseMiddleware> _middlewares = new List<BaseMiddleware> (){new RoutingMiddleware(),
                                                new ParameterExtractionMiddleware(),
                                                new ExceptionHandlingMiddleware(),
                                                new EndpointMiddleware()}; 

   
    public void AddAuthorization()
    {
        _middlewares.Add(new AuthorizationMiddleware()); 
    }
    public void AddAuthentication()
    {
        _middlewares.Add(new AuthenticationMiddleware());

    }
    public void SetListener(IListener listener)
    {
        _listener = listener;
        _listener.OnRequestReceived += HandleRequest; 
    }

    private void HandleRequest(object sender, CommunicationEventArgs communicationArg)
    {
        BaseMiddleware headMiddleware = BuildPipeline();
        Context context = new Context();
        context.Add("Request", communicationArg.Request);
        context.Add("Response", communicationArg.Response); 
        headMiddleware.Process(context);
        _listener.SendResponse(communicationArg.Response);
    }

    public void Run()
    {
        _listener.StartListening();
      
    }

    private BaseMiddleware BuildPipeline()
    {
        var sortedMiddlewares = _middlewares.OrderBy(c=> c.Priority).ToList();
        for (int i = 0; i < sortedMiddlewares.Count - 1; i++)
        {
            sortedMiddlewares[i].SetNext(_middlewares[i + 1]);
        }
        return sortedMiddlewares[0];
    }
    
}

