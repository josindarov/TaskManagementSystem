using Microsoft.AspNetCore.Components;
using TaskManagementSystem.Client.Model;
using TaskManagementSystem.Client.Services;

namespace TaskManagementSystem.Client.Pages;

public partial class Assignments
{
    [Inject] 
    private IAssignmentService AssignmentService { get; set; }

    private IEnumerable<Assignment> AllAssignments { get; set; } = new List<Assignment>();
    
    protected override async Task OnInitializedAsync()
    {
        var assignments = await AssignmentService.GetAllAsync();

        if (assignments != null && assignments.Any())
        {
            AllAssignments = assignments;
        }
    }
}
