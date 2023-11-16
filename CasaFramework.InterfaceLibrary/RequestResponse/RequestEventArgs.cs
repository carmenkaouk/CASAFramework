using CasaFramework.InterfaceLibrary.Interfaces;

namespace CasaFramework.InterfaceLibrary.RequestResponse;

public class CommunicationEventArgs : EventArgs
{
    public IRequest Request { get; set; }
    public IResponse Response {  get; set; } 
}