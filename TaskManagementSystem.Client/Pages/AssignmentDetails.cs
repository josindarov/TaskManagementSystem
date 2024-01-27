using Microsoft.AspNetCore.Components;
using TaskManagementSystem.Client.Model;
using TaskManagementSystem.Client.Services;

namespace TaskManagementSystem.Client.Pages;

public partial class AssignmentDetails
{
    protected string Message = string.Empty;
    
    protected Assignment Assignment { get; set; } = new Assignment();
    protected CreateAssignmentDto CreateAssignmentDto { get; set; } = new CreateAssignmentDto();
    
    [Parameter] 
    public string Id { get; set; }
    
    [Inject] 
    public IAssignmentService AssignmentService { get; set; }
    
    [Inject] 
    public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrEmpty(Id))
        {
            // add new assignment
        }
        else
        {
            var assignmentId = Convert.ToInt32(Id);
            var apiAssignment = await AssignmentService.GetAssignmentById(assignmentId);
            if (apiAssignment != null)
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
        if (string.IsNullOrEmpty(Id))
        {
            var result = await AssignmentService.AddAssignmentAsync(CreateAssignmentDto);
            if(result != null)
                NavigationManager.NavigateTo("/assignments");
            else
                Message = "Something went wrong, Task is not added.";
        }
        else
        {
            var result = await AssignmentService.UpdateAssignmentAsync(Assignment);
            if(result)
                NavigationManager.NavigateTo("/assignments");
            else
                Message = "Something went wrong, Task is not added.";
        }
    }
}