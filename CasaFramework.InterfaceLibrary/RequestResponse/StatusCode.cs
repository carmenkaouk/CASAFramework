namespace CasaFramework.MainLibrary.RequestResponse;

public enum StatusCode
{
    Success = 200,
    Redirection = 300,
    BadRequest = 400,
    Unauthorized = 401,
    NotFound = 404,
    ServerError = 500,
    NotImplemented = 51,
    Exception = 600,
}