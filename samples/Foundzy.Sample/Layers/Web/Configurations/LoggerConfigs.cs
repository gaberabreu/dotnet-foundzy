using Serilog;

namespace Foundzy.Sample.Layers.Web.Configurations;

public static class LoggerConfigs
{
    public static IHostBuilder AddLoggerConfigs(this IHostBuilder builder)
    {
        var logger = new LoggerConfiguration()
          .WriteTo.Console(
            outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message}{NewLine}{Exception}")
          .CreateLogger();

        builder.UseSerilog(logger);

        return builder;
    }
}
