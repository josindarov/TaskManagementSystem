using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Application.Services;
using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.Infrastructure.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _appDbContext;

    public TaskRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Tasks> AddTaskAsync(Tasks task)
    {
        var createTask = await _appDbContext.Tasks
            .AddAsync(task);

        return createTask.Entity;
    }

    public async Task<Tasks> GetTaskByIdAsync(Guid id)
    {
        var task = await _appDbContext.Tasks
            .FirstOrDefaultAsync(a => a.Id == id);

        return task;
    }

    public IQueryable<Tasks> GetAllTasks()
    {
        return _appDbContext.Tasks.AsQueryable();
    }

    public async Task<Tasks> DeleteTask(Guid id)
    {
        var deletedTask = await _appDbContext.Tasks
            .FirstOrDefaultAsync(a => a.Id == id);

        _appDbContext.Tasks.Remove(deletedTask);
        return deletedTask;
    }

    public async Task<Tasks?> UpdateTask(Guid id, Tasks task)
    {
        var updatedTask = await _appDbContext.Tasks
            .FirstOrDefaultAsync(a => a.Id == id);

        if (updatedTask != null)
        {
            updatedTask.Id = task.Id;
            updatedTask.Title = task.Title;
            updatedTask.Description = task.Description;
            updatedTask.TaskPriority = task.TaskPriority;
            updatedTask.DueDate = task.DueDate;
            updatedTask.state = task.state;
            updatedTask.Note = task.Note;

            return updatedTask;
        }

        return null;
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}