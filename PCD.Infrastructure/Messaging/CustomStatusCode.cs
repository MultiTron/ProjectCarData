namespace PCD.Infrastructure.Messaging;

public enum CustomStatusCode
{
    Success = 200,
    Redirection = 300,
    ClientError = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    ServerError = 500
}
