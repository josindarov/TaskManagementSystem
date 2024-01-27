using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.Application.Interfaces;

public interface ITaskRepository
{
    public Task<Tasks> AddTaskAsync(Tasks task);
    public Task<Tasks> GetTaskByIdAsync(int id);
    public IQueryable<Tasks> GetAllTasks();
    public Task<Tasks> DeleteTask(int id);
    public Task<Tasks?> UpdateTask(int id, Tasks tasks);
    
    public Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}