

using CasaFramework.MainLibrary.RequestResponse;

namespace CasaFramework.MainLibrary.Interfaces; 

public interface IResponse
{
    void SetStatusCode(StatusCode statusCode);
    void SetResponseContent(object? responseObject);
    void SetException(Exception exception);




}
