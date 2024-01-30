namespace IDrobeAPI.Application.Exceptions.CustomExceptions;

public class BaseException : ApplicationException
{
    public BaseException(string message) : base(message)
    {
    }
}
