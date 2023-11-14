using CASAFramework.BaseClasses;
using CASAFramework.RequestResponse;
using Microsoft.Extensions.Configuration;

namespace CASAFramework.Interfaces;

public interface IListener
{
    event EventHandler<RequestEventArgs> OnRequestRecieved;
    void StartListening(IConfiguration configuration, BaseMiddleware headMiddleware);

    void AddDefaultMiddlewares(List<BaseMiddleware> middlewares);

}