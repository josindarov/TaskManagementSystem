using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Infrastructure.Repository;

namespace TaskManagementSystem.Infrastructure;

public static class Dependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service,
        IConfiguration configuration)
    {
        service.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        service.AddScoped<ITaskRepository, TaskRepository>();
        return service;
    }
}