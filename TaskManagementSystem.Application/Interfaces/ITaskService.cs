using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.Application.Interfaces;

public interface ITaskService
{
    public Task<Tasks> AddTaskAsync(Tasks task);
    
    public Task<Tasks> GetTaskByIdAsync(int id);
    
    public IQueryable<Tasks> GetAllTasks();
    
    public Task<Tasks> DeleteTask(int id);
    
    public Task<Tasks?> UpdateTask(Tasks tasks);
}