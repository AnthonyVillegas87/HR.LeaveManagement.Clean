namespace HR.LeaveManagement.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message, object key) : base($"{message} with key: {key} not found")
    {
        
    }
}