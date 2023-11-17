using CasaFramework.MainLibrary.RequestResponse;

namespace CasaFramework.MainLibrary.Interfaces;

public interface IListener
{
    event EventHandler<CommunicationEventArgs> OnRequestReceived;
    void StartListening();
    void SendResponse(IResponse response);
}