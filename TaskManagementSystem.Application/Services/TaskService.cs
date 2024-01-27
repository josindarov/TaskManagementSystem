using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }
    public async Task<Tasks> AddTaskAsync(Tasks task)
    {
        throw new NotImplementedException();
    }

    public async Task<Tasks> GetTaskByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Tasks> GetAllTasks()
    {
        throw new NotImplementedException();
    }

    public async Task<Tasks> DeleteTask(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Tasks> UpdateTask(Guid id, Tasks tasks)
    {
        throw new NotImplementedException();
    }
}