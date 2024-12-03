using System.Reflection;
using FluentValidation;

namespace Foundzy.Sample.Layers.Web.Configurations;

public static class FluentValidationConfigs
{
    public static IServiceCollection AddFluentValidationConfigs(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}