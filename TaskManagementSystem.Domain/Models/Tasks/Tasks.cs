namespace TaskManagementSystem.Domain.Models.Tasks;

public class Tasks
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTimeOffset DueDate { get; set; }

    public string TaskPriority { get; set; }

    public string state { get; set; }

    public string Note { get; set; }
}
