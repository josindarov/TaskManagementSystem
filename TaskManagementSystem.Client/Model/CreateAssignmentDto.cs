namespace TaskManagementSystem.Client.Model;

public class CreateAssignmentDto
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
 
    public DateTime DueDate { get; set; }
    
    public string? TaskPriority { get; set; }

    public string? State { get; set; }

    public string? Note { get; set; }
}