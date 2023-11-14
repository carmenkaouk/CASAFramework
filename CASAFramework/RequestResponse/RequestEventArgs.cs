using CASAFramework.Interfaces;

namespace CASAFramework.RequestResponse;

public class CommunicationEventArgs : EventArgs
{
    public IRequest Request { get; set; }
    public IResponse Response {  get; set; } 
}