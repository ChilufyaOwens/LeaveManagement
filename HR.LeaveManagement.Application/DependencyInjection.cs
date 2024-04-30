using System.Reflection;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Contracts.Persistence.Common;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
            //options.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        return services;
    }
    
}