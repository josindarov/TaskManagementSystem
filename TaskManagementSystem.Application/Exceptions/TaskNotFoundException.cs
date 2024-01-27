namespace TaskManagementSystem.Application.Exceptions;

public class TaskNotFoundException : Exception
{
    public TaskNotFoundException(Guid id)
        : base($"Task is not found in {id}")
    { }
}