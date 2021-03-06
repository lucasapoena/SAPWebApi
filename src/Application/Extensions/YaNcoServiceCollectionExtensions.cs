using System;
using Application;
using Application.Adapters;
using Dbosoft.YaNco;
using Dbosoft.YaNco.TypeMapping;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Configuration
{
    public static class YaNcoServiceCollectionExtensions
    {

        public static IServiceCollection AddYaNco(this IServiceCollection services)
        {
            services.AddSingleton<ILogger, RfcLoggingAdapter>();
            services.AddSingleton<Func<ILogger, IFieldMapper, RfcRuntimeOptions, IRfcRuntime>>(
                sp => (l, m, o) => new RfcRuntime(sp.GetService<ILogger>(), m, o));
            services.AddSingleton<SAPConnectionFactory>();
            services.AddSingleton(sp => sp.GetRequiredService<SAPConnectionFactory>().CreateConnectionFunc());
            services.AddTransient<IRfcContext, RfcContext>();

            return services;
        }
    }
}