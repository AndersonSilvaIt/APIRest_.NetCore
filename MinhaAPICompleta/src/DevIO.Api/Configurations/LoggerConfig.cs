using DevIO.Api.Extensions;
using Elmah.Io.Extensions.Logging;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DevIO.Api.Configurations
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services, IConfiguration configuration )
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

            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    options.ApiKey = "388dd3a277cb44c4aa128b5c899a3106";
                    options.LogId = new Guid("c468b2b8-b35d-4f1a-849d-f47b60eef096");
                    options.HeartbeatId = "API Fornecedores";
                })
                .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))// Implementado a validação de produtos no banco, caso não tiver produtos, ele não está saudável.
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "Banco SQL");

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();
            app.UseHealthChecks("/api/hc", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options => { options.UIPath = "api/hc-ui"; });


            return app;
        }
    }
}
