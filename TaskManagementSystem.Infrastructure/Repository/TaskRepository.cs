using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.Infrastructure.Repository;

public class TaskRepository : ITaskRepository
{
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