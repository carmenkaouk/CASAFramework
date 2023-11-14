using CASAFramework.RequestResponse;

namespace CASAFramework.Senders.FileExtension
{
    internal class FileResponse
    {
        public Guid RequestId { get; set; }
        public StatusCode StatusCode { get; set; }
        public object? Content { get; set;}
        public string ExceptionMessage { get; set; }
    }
}