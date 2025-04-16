using Mapster;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiAuthCRUD.BAL.Configs
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
