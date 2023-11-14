using CASAFramework.Interfaces;

namespace CASAFramework.RequestResponse;

public class RequestEventArgs : EventArgs
{
    public IRequest Request { get; set; }
}