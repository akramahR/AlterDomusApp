using AlterDomusApp.Core.Interfaces.Infrastructure.Github;
using AlterDomusApp.Github.Client;
using Microsoft.Extensions.DependencyInjection;

namespace AlterDomusApp.Github.Extensions
{
    public static class GithubServiceCollectionExtensions
    {
        /// <summary>
        /// Extension method for configuring and adding the dependencies of this project
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddGithubClientServices(this IServiceCollection services)
        {
            services.AddTransient<IGithubResources, GithubResources>();
            services.AddTransient<IGithubClient,GithubClient>();
            return services;
        }
    }
}
