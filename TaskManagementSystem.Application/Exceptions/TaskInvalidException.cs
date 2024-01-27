namespace TaskManagementSystem.Application.Exceptions;

public class TaskInvalidException : Exception
{
    public TaskInvalidException()
        : base("Task is invalid")
    { }
}