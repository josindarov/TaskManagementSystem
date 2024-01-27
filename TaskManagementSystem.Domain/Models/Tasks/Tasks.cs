using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Domain.Models.Tasks;

public class Tasks
{
    [Required(ErrorMessage = "Id is required")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Due date is required")]
    public DateTimeOffset DueDate { get; set; }

    [Required(ErrorMessage = "Task Priority is required")]
    public string TaskPriority { get; set; }

    [Required(ErrorMessage = "State is required")]
    public string state { get; set; }

    [Required(ErrorMessage = "Note is required")]
    public string Note { get; set; }
}
