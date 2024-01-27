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
        var addedTask = await _repository.AddTaskAsync(task);
        await _repository.SaveChangesAsync();
        return addedTask;
    }

    public async Task<Tasks> GetTaskByIdAsync(Guid id)
    {
        var task = await _repository.GetTaskByIdAsync(id);
        return task;
    }

    public IQueryable<Tasks> GetAllTasks()
    {
        return _repository.GetAllTasks();
    }

    public async Task<Tasks> DeleteTask(Guid id)
    {
        var task = await _repository.DeleteTask(id);
        await _repository.SaveChangesAsync();
        return task;
    }

    public async Task<Tasks?> UpdateTask(Guid id, Tasks tasks)
    {
        var task = await _repository.UpdateTask(id, tasks);
        await _repository.SaveChangesAsync();
        return task;
    }
}