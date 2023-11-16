using CasaFramework.InterfaceLibrary.RequestResponse;

namespace CASAFramework.Senders.FileExtension;

public class FileResponse
{
    public Guid RequestId { get; set; }
    public StatusCode StatusCode { get; set; }
    public object? Content { get; set;}
    public string ExceptionMessage { get; set; }
}