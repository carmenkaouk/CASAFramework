using Microsoft.Extensions.Configuration;

namespace CASAFramework;

public interface IListener
{

    void StartListening(IConfiguration configuration, BaseMiddleware headMiddleware);

    void AddDefaultMiddlewares(List<BaseMiddleware> middlewares);

}