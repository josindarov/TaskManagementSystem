using Microsoft.AspNetCore.Mvc;
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
        var postedTask = await _taskService.AddTaskAsync(tasks);
        return Ok(postedTask);
    }

    [HttpGet] 
    public ActionResult<IQueryable<Tasks>> GetTasksList()
    {
        var tasks =  _taskService.GetAllTasks();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tasks>> GetTaskByIdAsync(Guid id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Tasks>> DeleteTaskAsync(Guid id)
    {
        var task = await _taskService.DeleteTask(id);
        return task;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Tasks>> UpdateTaskAsync(Guid id, Tasks tasks)
    {
        var task = await _taskService.UpdateTask(id, tasks);
        return task;
    }
    
}