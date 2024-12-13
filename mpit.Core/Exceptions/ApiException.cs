namespace mpit.Core.Exceptions
{
    public class ApiException : ApplicationException
    {
        public ApiException() { }

        public ApiException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
        public int StatusCode { get; private set; }
    }

    public class NotFoundException(string message, int statusCode = 404)
    : ApiException(message, statusCode)
    { }

    public class ConflictException(string message, int statusCode = 409)
        : ApiException(message, statusCode)
    { }

    public class UnauthorizedException(string message = "Проблемы с токеном", int statusCode = 401)
    : ApiException(message, statusCode)
    { }
}
