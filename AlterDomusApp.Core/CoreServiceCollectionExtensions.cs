using AlterDomusApp.Core.Interfaces.Infrastructure.Github;
using AlterDomusApp.Core.Interfaces.Services;
using AlterDomusApp.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AlterDomusApp.Core
{
    public static class CoreServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IGitHubService, GitHubService>();
            return services;
        }
    }
}