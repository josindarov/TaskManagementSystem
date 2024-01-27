using Microsoft.Extensions.Logging;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.Application.Services;

public partial class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;
    private readonly ILogger<TaskService> _logging;

    public TaskService(ITaskRepository repository, ILogger<TaskService> logging)
    {
        _repository = repository;
        _logging = logging;
    }

    public Task<Tasks> AddTaskAsync(Tasks task) =>
        TryCatch( async () =>
        {
            ValidateTaskOnAdd(task);
            
            var addedTask = await _repository
                .AddTaskAsync(task);
            
            await _repository.SaveChangesAsync();
            return addedTask;
        });

    public Task<Tasks> GetTaskByIdAsync(Guid id) =>
        TryCatch(async () =>
        {
            var task = await _repository
                .GetTaskByIdAsync(id);
            
            CheckTaskIsFoundOrNot(id, task);
            return task;
        });

    public IQueryable<Tasks> GetAllTasks()
    {
        return _repository.GetAllTasks();
    }

    public Task<Tasks> DeleteTask(Guid id) =>
        TryCatch(async () =>
        {
            var task = await _repository
                .DeleteTask(id);
            
            CheckTaskIsFoundOrNot(id, task);
            await _repository.SaveChangesAsync();
            return task;
        });

    public async Task<Tasks?> UpdateTask(Guid id, Tasks tasks)
    {
        var task = await _repository.UpdateTask(id, tasks);
        await _repository.SaveChangesAsync();
        return task;
    }
}