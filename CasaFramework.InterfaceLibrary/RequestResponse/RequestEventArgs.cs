using CasaFramework.MainLibrary.Interfaces;

namespace CasaFramework.MainLibrary.RequestResponse;

public class CommunicationEventArgs : EventArgs
{
    public IRequest Request { get; set; }
    public IResponse Response {  get; set; } 
}