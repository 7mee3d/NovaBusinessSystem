using System.Reflection;

namespace NovaBusinessSystem.API;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectDependencies(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        var types = assemblies
            .Distinct()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsClass && !type.IsAbstract);

        foreach (var implementation in types)
        {
            var interfaces = implementation.GetInterfaces()
                .Where(i => i.Name == $"I{implementation.Name}");

            foreach (var serviceInterface in interfaces)
            {
                services.AddScoped(serviceInterface, implementation);
            }
        }

        return services;
    }
}