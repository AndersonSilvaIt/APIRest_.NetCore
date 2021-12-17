using DevIO.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace DevIO.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            services.AddApiVersioning(options =>
            {
                // Quanto não tiver versão especificada, deve assumir uma versão padrão
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

                // Política padrão de acesso.
                /*options.AddDefaultPolicy(
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());*/


                options.AddPolicy("Production",
                    builder =>
                        builder
                        .WithMethods("GET", "POST")
                        .WithOrigins("http://desenvolvedor.io")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
                        .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Development"); // Usar apenas nas demos => Configuração Ideal: Production
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            return app;
        }
    }
}