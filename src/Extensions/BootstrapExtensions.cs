using Microsoft.Extensions.DependencyInjection;
using Orbyss.Blazor.Syncfusion.DynamicGrid.DataAdaptors;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Helpers;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interfaces;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Extensions
{
    public static class BootstrapExtensions
    {
        public static IServiceCollection AddSyncfusionDynamicGrid(this IServiceCollection services, Func<IServiceProvider, JTokenDataAdaptor>? tokenDataAdaptorFactory = null)
        {
            services
                .AddScoped<IJsonPathInterpreter, JsonPathInterpreter>()
                .AddScoped<ITableUiSchemaInterpreter, TableUiSchemaInterpreter>()
                .AddScoped<DynamicColumnBuilder>();

            if (tokenDataAdaptorFactory is not null)
            {
                services.AddTransient(tokenDataAdaptorFactory);
            }

            return services;
        }

        public static IServiceCollection AddSyncfusionDynamicGrid<TDynamicGridDataProvider>(this IServiceCollection services)
            where TDynamicGridDataProvider : class, IDynamicGridDataProvider
        {
            return services
                .AddSyncfusionDynamicGrid()
                .AddTransient<IDynamicGridDataProvider, TDynamicGridDataProvider>();
        }
    }
}
