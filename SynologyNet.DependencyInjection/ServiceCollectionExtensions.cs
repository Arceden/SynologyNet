using Microsoft.Extensions.DependencyInjection;

namespace SynologyNet.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSynology(this IServiceCollection services)
    {
        // todo add services
    }

    public static void AddSynology(this IServiceCollection services, SynologyOptions options)
    {
        // todo register login

        AddSynology(services);
    }
}