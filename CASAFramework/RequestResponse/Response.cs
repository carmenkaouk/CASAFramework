namespace CASAFramework.RequestResponse;

public class Response
{
    public object? Content { get; set; }
    public StatusCode StatusCode { get; set; }
    public Exception Exception { get; set; }

}