
using CasaFramework.MainLibrary.Interfaces;

namespace CASAFramework.Senders.FileExtension;

public class FileRequestWrapper : IRequest
{
    private  FileRequest _request;
    public FileRequestWrapper(FileRequest request)
    {
        _request = request;
    }
    public Dictionary<string, object> GetContent()
    {
        return _request.Content;
    }

    public string GetToken()
    {
        return _request.Token;
    }

    public string GetUri()
    {
        return _request.Uri; 
    }

    public string GetUsername()
    {
        return _request.SenderUsername; 
    }
}
