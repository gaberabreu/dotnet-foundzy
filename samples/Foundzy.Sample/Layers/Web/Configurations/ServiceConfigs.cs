using Foundzy.Sample.Layers.Infrastructure;

namespace Foundzy.Sample.Layers.Web.Configurations;

public static class ServiceConfigs
{
    public static IServiceCollection AddServiceConfigs(this IServiceCollection services)
    {
        services.AddInfrastructureServices()
            .AddMediatrConfigs()
            .AddFluentValidationConfigs();

        return services;
    }


}
