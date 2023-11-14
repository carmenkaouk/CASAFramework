using CASAFramework.RequestResponse;

namespace CASAFramework.Interfaces; 

public interface IResponse
{
    void SetStatusCode(StatusCode statusCode);
    void SetResponse(object? responseObject);
    void SetException(Exception exception);




}
