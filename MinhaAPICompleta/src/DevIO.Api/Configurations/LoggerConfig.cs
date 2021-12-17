using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DevIO.Api.Configurations
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
           {
               o.ApiKey = "e2b6f9152c2a40f6bed093e28feffcc4";
               o.LogId = new Guid("157608c0-dbf7-473c-8858-aed4d83977a6");
           });

            // Para configurar o Logg do AspNetCore logar diretamente no servidor do Elmah.io
            services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "e2b6f9152c2a40f6bed093e28feffcc4";
                    o.LogId = new Guid("157608c0-dbf7-473c-8858-aed4d83977a6");
                });
                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();



            return app;
        }
    }
}
