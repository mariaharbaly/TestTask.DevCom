namespace TestTask.DevCom.Common.Exceptions;

public class EntityAlreadyExistException : Exception
{
    public EntityAlreadyExistException(string message) : base(message)
    {
    }

    public EntityAlreadyExistException(string message, Exception innerException) : base(message, innerException)
    {
    }
}