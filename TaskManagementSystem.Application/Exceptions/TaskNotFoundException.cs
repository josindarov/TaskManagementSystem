namespace TaskManagementSystem.Application.Exceptions;

public class TaskNotFoundException : Exception
{
    public TaskNotFoundException(int id)
        : base($"Task is not found in {id}")
    { }
}