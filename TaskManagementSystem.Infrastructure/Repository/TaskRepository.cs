using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain.Models.Tasks;
using TaskManagementSystem.Infrastructure;

namespace TaskManagementSyst.Infrastructure.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _dbContext;

    public TaskRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Tasks> AddTaskAsync(Tasks task)
    {
        var createdTask = await 
            _dbContext.Tasks.AddAsync(task);

        return createdTask.Entity;
    }

    public async Task<Tasks> GetTaskByIdAsync(Guid id)
    {
        Tasks? task = await _dbContext.Tasks.
            FirstOrDefaultAsync(p => p.Id == id);

        return task;
    }

    public IQueryable<Tasks> GetAllTasks()
    {
        return _dbContext.Tasks.AsQueryable();
    }

    public async Task<Tasks> DeleteTask(Guid id)
    {
        Tasks? deletedTask = await _dbContext.Tasks.
            FirstOrDefaultAsync(p => p.Id == id);

        _dbContext.Tasks.Remove(deletedTask);

        return deletedTask;
    }

    public async Task<Tasks> UpdateTask(Guid id, Tasks task)
    {
        Tasks? updatedTask = await _dbContext.Tasks.
            FirstOrDefaultAsync(p => p.Id == id);

        updatedTask.Id = task.Id;
        updatedTask.Title = task.Title;
        updatedTask.Description = task.Description;
        updatedTask.TaskPriority = task.TaskPriority;
        updatedTask.DueDate = task.DueDate;
        updatedTask.state = task.state;
        updatedTask.Note = task.Note;

        return updatedTask;
    }
}