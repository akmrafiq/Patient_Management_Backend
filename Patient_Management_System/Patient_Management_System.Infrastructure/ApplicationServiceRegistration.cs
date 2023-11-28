using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Patient_Management_System.Data.Repositories;

namespace Patient_Management_System.Infrastructure;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
        return services;
    }
}