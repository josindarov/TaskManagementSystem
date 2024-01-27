using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.Application.Interfaces;

public interface ITaskService
{
    public Task<Tasks> AddTaskAsync(Tasks task);
    
    public Task<Tasks> GetTaskByIdAsync(Guid id);
    
    public IQueryable<Tasks> GetAllTasks();
    
    public Task<Tasks> DeleteTask(Guid id);
    
    public Task<Tasks?> UpdateTask(Guid id, Tasks tasks);
}