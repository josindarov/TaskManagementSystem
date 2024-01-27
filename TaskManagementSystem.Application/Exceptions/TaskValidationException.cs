namespace TaskManagementSystem.Application.Exceptions;

public class TaskValidationException : Exception
{
    public TaskValidationException(Exception innerException)
        : base("Validation error occurs, fix it and try again.")
    { }
}