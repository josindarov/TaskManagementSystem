using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.Application.Services;

public partial class TaskService
{
    private static void CheckTaskIsNotNull(Tasks tasks)
    {
        if (tasks is null)
        {
            throw new TaskNullException();
        }
    }

    private static void CheckTaskIsFoundOrNot(Guid id, Tasks tasks)
    {
        if (tasks is null)
        {
            throw new TaskNotFoundException(id);
        }
    }
}