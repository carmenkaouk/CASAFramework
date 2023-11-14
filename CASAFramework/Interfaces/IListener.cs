using CASAFramework.BaseClasses;
using CASAFramework.Options;
using CASAFramework.RequestResponse;
using Microsoft.Extensions.Configuration;

namespace CASAFramework.Interfaces;

public interface IListener
{
    event EventHandler<CommunicationEventArgs> OnRequestReceived;
    void StartListening();

}