namespace TaskManagementSystem.Application.Exceptions;

public class TaskNullException : Exception
{
    public TaskNullException()
        : base("Task is null")
    { }
}