using CasaFramework.MainLibrary.Interfaces;
using CasaFramework.MainLibrary.RequestResponse;


namespace CASAFramework.Senders.FileExtension;

public  class FileResponseWrapper : IResponse
{
    private FileResponse _response;

    public FileResponseWrapper(FileResponse response)
    {
        _response = response;
    }
    public void SetException(Exception exception)
    {
        _response.ExceptionMessage= exception.ToString();
    }

    public void SetResponseContent(object? responseObject)
    {
        _response.Content= responseObject;
    }

    public void SetStatusCode(StatusCode statusCode)
    {
        _response.StatusCode= statusCode;
    }
}
