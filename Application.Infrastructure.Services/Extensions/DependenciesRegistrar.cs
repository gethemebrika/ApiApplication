using Application.Infrastructure.Services.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProtoDefinitions;

namespace Application.Infrastructure.Services.Extensions;

public static class DependenciesRegistrar
{
    public static IServiceCollection AddServicesGrpcService(this IServiceCollection services, IConfiguration configuration )
    {
        services.AddGrpcClient<MoviesApi.MoviesApiClient>(options =>
        {
            options.Address = new Uri(configuration[Constants.ProviderApiBaseUri]);
        }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        }).AddCallCredentials(((_, metadata) =>
        {
            metadata.Add("X-Apikey", configuration[Constants.ProviderApiKey]);
            return Task.CompletedTask;
        }));

        return services;
    }
}