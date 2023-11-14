using CASAFramework.BaseClasses;
using CASAFramework.Interfaces;
using CASAFramework.Middlewares;
using CASAFramework.Options;
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
    private ListeningOptionBuilder _listeningOptions = new(); 

   
    public void AddAuthorization(AuthorizationOptionBuilder optionsBuilder)
    {
        _middlewares.Add(new AuthorizationMiddleware(optionsBuilder)); 
    }
    public void AddAuthentication(AuthenticationOptionBuilder optionsBuilder)
    {
        _middlewares.Add(new AuthenticationMiddleware(optionsBuilder));

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
    }

    public void SetListenerOptions(ListeningOptionBuilder optionBuilder)
    {
        _listeningOptions = optionBuilder;
    }
    public void Run()
    {
        _listener.StartListening(_listeningOptions);
      
    }

    private BaseMiddleware BuildPipeline()
    {
        _middlewares.Sort();
        for (int i = 0; i < _middlewares.Count - 1; i++)
        {
            _middlewares[i].SetNext(_middlewares[i + 1]);
        }
        return _middlewares[0];
    }
    
}

