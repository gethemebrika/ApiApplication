using ApiApplication.Domain.Interfaces.Repositories;
using ApiApplication.Infrastructure.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ApiApplication.Infrastructure.Repository.Extensions;

public static class DependenciesRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IShowtimesRepository, ShowTimesRepository>();
        services.AddTransient<ITicketsRepository, TicketsRepository>();
        services.AddTransient<IAuditoriumsRepository, AuditoriumsRepository>();

        return services;
    }
}