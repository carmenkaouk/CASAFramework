using CasaFramework.InterfaceLibrary.RequestResponse;

namespace CasaFramework.InterfaceLibrary.Interfaces;

public interface IListener
{
    event EventHandler<CommunicationEventArgs> OnRequestReceived;
    void StartListening();
    void SendResponse(IResponse response);
}