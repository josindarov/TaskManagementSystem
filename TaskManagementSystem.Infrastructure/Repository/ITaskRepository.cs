using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSyst.Infrastructure.Repository;

public interface ITaskRepository
{
    public Task<Tasks> AddTaskAsync(Tasks task);
    public Task<Tasks> GetTaskByIdAsync(Guid id);
    public IQueryable<Tasks> GetAllTasks();
    public Task<Tasks> DeleteTask(Guid id);
    public Task<Tasks> UpdateTask(Guid id, Tasks tasks);
}