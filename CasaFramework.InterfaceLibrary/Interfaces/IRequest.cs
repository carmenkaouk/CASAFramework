namespace CasaFramework.MainLibrary.Interfaces;

public interface IRequest
{
    string GetUsername();
    string GetToken();
    string GetUri();
    Dictionary<string, object> GetContent();
}