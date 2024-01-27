using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public async Task<ActionResult<Tasks>> PostTaskAsync(Tasks tasks)
    {
        try
        {
            var postedTask = await _taskService.AddTaskAsync(tasks);
            return Ok(postedTask);
        }
        catch (TaskValidationException taskValidationException)
        {
            return BadRequest(taskValidationException.InnerException);
        }
    }

    [HttpGet] 
    public async Task<ActionResult<IQueryable<Tasks>>> GetTasksList()
    {
        var tasks =  await _taskService.GetAllTasks().ToListAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tasks>> GetTaskByIdAsync(Guid id)
    {
        try
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            return Ok(task);
        }
        catch (TaskValidationException taskValidationException)
        {
            return BadRequest(taskValidationException.InnerException);
        }
        
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Tasks>> DeleteTaskAsync(Guid id)
    {
        try
        {
            var task = await _taskService.DeleteTask(id);
            return task;
        }
        catch (TaskValidationException taskValidationException)
        {
            return BadRequest(taskValidationException.InnerException);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Tasks>> UpdateTaskAsync(Tasks tasks)
    {
        try
        {
            var task = await _taskService.UpdateTask(tasks);
            return task;
        }
        catch (TaskValidationException taskValidationException)
        {
            return BadRequest(taskValidationException.InnerException);
        }
        
    }
    
}