using TaskManagementSystem.Client.Model;

namespace TaskManagementSystem.Client.Services;

public interface IAssignmentService
{
    Task<IEnumerable<Assignment>> GetAllAsync();
    Task<Assignment> GetAssignmentById(Guid id);
    Task<Assignment> AddAssignmentAsync(Assignment assignment);
    Task<bool> UpdateAssignmentAsync(Assignment assignment);
    Task<bool> DeleteAssignmentAsync(Guid id);
}