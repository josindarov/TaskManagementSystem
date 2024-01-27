using TaskManagementSystem.Client.Model;

namespace TaskManagementSystem.Client.Services;

public interface IAssignmentService
{
    Task<IEnumerable<Assignment>> GetAllAsync();
    Task<Assignment> GetAssignmentById(int id);
    Task<CreateAssignmentDto> AddAssignmentAsync(CreateAssignmentDto assignment);
    Task<bool> UpdateAssignmentAsync(Assignment assignment);
    Task<bool> DeleteAssignmentAsync(int id);
}