using Microsoft.AspNetCore.Components;
using TaskManagementSystem.Client.Model;
using TaskManagementSystem.Client.Services;

namespace TaskManagementSystem.Client.Pages;

public partial class ManageAssignmentDetails
{
    protected string Message = string.Empty;
    
    protected Assignment Assignment { get; set; } = new Assignment();
    
    [Parameter] 
    public string Id { get; set; }
    
    [Inject] 
    public IAssignmentService AssignmentService { get; set; }
    
    [Inject] 
    public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var assignmentId = Convert.ToInt32(Id);
        var apiAssignment = await AssignmentService.GetAssignmentById(assignmentId);
        if (apiAssignment != null)
        {
            Assignment = apiAssignment;
        }
        
    }

    protected void HandleFailedRequest()
    {
        Message = "Something went wrong, submit form is not working.";
    }

    protected void GoToAssignments()
    {
        NavigationManager.NavigateTo("/assignments");
    }

    protected async Task DeleteAssignment()
    {
        if (!string.IsNullOrEmpty(Id))
        {
            var assignmentId = Convert.ToInt32(Id);
            var result = await AssignmentService.DeleteAssignmentAsync(assignmentId);
            if (result)
                NavigationManager.NavigateTo("/assignments");
            else
                Message = "Something went wrong, Task is not deleted.";
        }
    }

    protected async Task HandleValidRequest()
    {
        var result = await AssignmentService.UpdateAssignmentAsync(Assignment);
        if (result)
        {
            NavigationManager.NavigateTo("/assignments");
        }
        else
        {
            Message = "Something went wrong, Task is not added.";
        }
        
    }    
}