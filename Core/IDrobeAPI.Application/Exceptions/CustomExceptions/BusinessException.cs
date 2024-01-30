namespace IDrobeAPI.Application.Exceptions.CustomExceptions;

public class BusinessException : BaseException
{
    public BusinessException(string message) : base(message)
    {
    }
}