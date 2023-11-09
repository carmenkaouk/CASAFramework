using Microsoft.Extensions.Configuration;

namespace CASAFramework;

public class App
{
    private IListener _listener;
    private IConfiguration _configeration;
    private List<BaseMiddleware> _middlewares = new();


    public void AddMiddleware(BaseMiddleware middelware)
    {
        _middlewares.Add(middelware);
    }

    public void AddMiddlewares(List<BaseMiddleware> middelwares)
    {
        _middlewares.AddRange(middelwares);
    }

    public void AddListener(IListener listener)
    {
        _listener = listener;
        _listener.AddDefaultMiddlewares(_middlewares);
    }

    public void AddConfiguration(IConfiguration configuration)
    {
        _configeration = configuration;
    }

    public void Run()
    {
        ValidateMiddlewares();
        BaseMiddleware headMiddleware = BuildPipeline();
        _listener.StartListening(_configeration, headMiddleware);

    }

    private void ValidateMiddlewares()
    {
        for (int i = 1; i < _middlewares.Count; i++)
        {
            if (_middlewares[i - 1].Priority > _middlewares[i].Priority)
            {
                throw new Exception("Invalid middleware order");
            }
        }

        for (int i = 1; i < _middlewares.Count; i++)
        {
            var prerequisite = _middlewares.GetRange(0, i).FirstOrDefault(x => _middlewares[i].Prerequisite == x.GetType());
            if (prerequisite == null)
            {
                throw new Exception("Middleware missing");
            }

        }
    }

    private BaseMiddleware BuildPipeline()
    {
        for (int i = 0; i < _middlewares.Count - 1; i++)
        {
            _middlewares[i].SetNext(_middlewares[i + 1]);
        }
        return _middlewares[0];
    }
}