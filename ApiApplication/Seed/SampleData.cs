using ApiApplication.Infrastructure.Data;
using ApiApplication.Infrastructure.Data.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ApiApplication.Seed
{
    public static class SampleData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<CinemaContext>();
            context.Database.EnsureCreated();
            
            context.SeedData();
        }
    }
}
