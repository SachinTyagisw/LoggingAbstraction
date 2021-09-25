using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Common.Helper
{
    public static class ConfigureSimpleInjectorExtension
    {
        public static void ConfigureSimpleInjector(this IServiceCollection services, Container container)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Options.DefaultLifestyle = Lifestyle.Scoped;

            // Ensures the container gets disposed
            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore().AddControllerActivation();
                options.AutoCrossWireFrameworkComponents = true;
            });
            // TODO: This is the legacy behaviour of SimpleInjector pre v5.
            // Check https://simpleinjector.readthedocs.io/en/latest/resolving-unregistered-concrete-types-is-disallowed-by-default.html for more details
            container.Options.ResolveUnregisteredConcreteTypes = true;
#if DEBUG
            container.ResolveUnregisteredType += (s, e) =>
            {
                if (!e.Handled && !e.UnregisteredServiceType.IsAbstract)
                {
                    System.Console.Error.WriteLine($"UnregisteredServiceType: {e.UnregisteredServiceType}");
                }
            };
#endif
        }
    }
}
