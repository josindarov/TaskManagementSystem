using Microsoft.Extensions.Logging;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.Application.Services;

public partial class TaskService
{
    private delegate Task<Tasks> ReturningTaskFunction();

    private async Task<Tasks> TryCatch(ReturningTaskFunction returningTaskFunction)
    {
        try
        {
            return await returningTaskFunction();
        }
        catch (TaskNullException taskNullException)
        {
            throw CreateAndLogValidationException(taskNullException);
        }
        catch (TaskNotFoundException taskNotFoundException)
        {
            throw CreateAndLogValidationException(taskNotFoundException);
        }
    }

    private TaskValidationException CreateAndLogValidationException(Exception exception)
    {
        var taskValidationExcepiton = new TaskValidationException(exception);
        _logging.LogError("Validation error occurs, fix it and try again");
        return taskValidationExcepiton;
    }
}