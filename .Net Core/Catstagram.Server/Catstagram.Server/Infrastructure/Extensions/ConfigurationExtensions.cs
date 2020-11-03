using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Catstagram.Server.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");

        public static AppSettings GetAppSettings(this IServiceCollection services,
            IConfiguration configuration)
        {
            var appSettingSection = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(configuration.GetSection("ApplicationSettings"));

            return appSettingSection.Get<AppSettings>();
        }
    }
}
