using CASAFramework.RequestResponse;

namespace CASAFramework.Interfaces; 

public interface IResponse
{
    void SetStatusCode(StatusCode statusCode);
    void SetResponseContent(object? responseObject);
    void SetException(Exception exception);
    void SendResponse(); 




}
