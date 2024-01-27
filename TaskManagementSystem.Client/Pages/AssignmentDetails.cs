using Microsoft.AspNetCore.Components;
using TaskManagementSystem.Client.Model;
using TaskManagementSystem.Client.Services;

namespace TaskManagementSystem.Client.Pages;

public partial class AssignmentDetails
{
    protected string Message = string.Empty;
    
    protected CreateAssignmentDto CreateAssignmentDto { get; set; } = new CreateAssignmentDto();
    
    [Parameter] 
    public string Id { get; set; }
    
    [Inject] 
    public IAssignmentService AssignmentService { get; set; }
    
    [Inject] 
    public NavigationManager NavigationManager { get; set; }
    
    protected void HandleFailedRequest()
    {
        Message = "Something went wrong, submit form is not working.";
    }

    protected void GoToAssignments()
    {
        NavigationManager.NavigateTo("/assignments");
    }

    protected async Task HandleValidRequest()
    {
        var result = await AssignmentService.AddAssignmentAsync(CreateAssignmentDto);
        if (result != null)
        {
            NavigationManager.NavigateTo("/assignments");
        }
        else
        {
            Message = "Something went wrong, Task is not added.";
        }
        
    }
}