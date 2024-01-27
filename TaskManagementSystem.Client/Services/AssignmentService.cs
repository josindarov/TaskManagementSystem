using System.Text;
using System.Text.Json;
using TaskManagementSystem.Client.Model;

namespace TaskManagementSystem.Client.Services;

public class AssignmentService : IAssignmentService
{
    private readonly HttpClient _httpClient;

    public AssignmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<Assignment>> GetAllAsync()
    {
        var apiResponse = await _httpClient.GetStreamAsync("api/Task");
        
        IEnumerable<Assignment>? assignments = await JsonSerializer.DeserializeAsync<IEnumerable<Assignment>>(apiResponse,
            new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

        return assignments;
    }

    public async Task<Assignment> GetAssignmentById(Guid id)
    {
        var response = await _httpClient.GetStreamAsync($"api/Task/{id}");

        var assignment = await JsonSerializer.DeserializeAsync<Assignment>(response, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        });

        return assignment;
    }

    public async Task<Assignment> AddAssignmentAsync(Assignment assignment)
    {
        var itemJson = new StringContent(JsonSerializer.Serialize(assignment), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("api/Tasks", itemJson);

        if(response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStreamAsync();

            var addAssignment = await JsonSerializer.DeserializeAsync<Assignment>(responseBody,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

            return addAssignment;
        }

        return null;
    }

    public async Task<bool> UpdateAssignmentAsync(Assignment assignment)
    {
        var itemJson = new StringContent(JsonSerializer.Serialize(assignment), Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync("api/Tasks", itemJson);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAssignmentAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/Task/{id}");
        return response.IsSuccessStatusCode;
    }
}