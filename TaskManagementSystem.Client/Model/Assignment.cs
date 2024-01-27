namespace TaskManagementSystem.Client.Model;

public class Assignment
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
 
    public DateTimeOffset DueDate { get; set; }
    
    public string? TaskPriority { get; set; }

    public string? State { get; set; }

    public string? Note { get; set; }
}