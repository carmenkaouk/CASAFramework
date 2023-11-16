

using CasaFramework.InterfaceLibrary.RequestResponse;

namespace CasaFramework.InterfaceLibrary.Interfaces; 

public interface IResponse
{
    void SetStatusCode(StatusCode statusCode);
    void SetResponseContent(object? responseObject);
    void SetException(Exception exception);




}
