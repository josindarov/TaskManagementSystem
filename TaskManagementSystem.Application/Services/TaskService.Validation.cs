using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.Application.Services;

public partial class TaskService
{
    private static void ValidateTaskOnAdd(Tasks tasks)
    {
        CheckTaskIsNotNull(tasks);
    }

    private static void CheckTaskIsNotNull(Tasks tasks)
    {
        if (tasks is null)
        {
            throw new TaskNullException();
        }
    }
}