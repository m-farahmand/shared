using System;
using System.Collections.Generic;
using System.IO;
using MicroElements.Swashbuckle.FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using CesarBmx.Shared.Api.ResponseExamples;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class SwaggerConfig
    {
        /// <summary>
        /// Common configuration for swagger
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="appName">The name of the application (e.g. Fraud API)</param>
        /// <param name="type">Swagger example type</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureSharedSwagger(this IServiceCollection services, string appName, Type type)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(
                    "Bearer", 
                    new OpenApiSecurityScheme
                {
                    Description = @"Please enter the bearer token (e.g 'Bearer eyJhbGciOiJIUzI1Ni....')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

                var assemblyName = type.Assembly.GetName();

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = appName,
                        Version = assemblyName.Version.ToString()
                    }); 
                c.ExampleFilters();
                c.OperationFilter<AddResponseHeadersFilter>(); 
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();              
                c.EnableAnnotations();
                c.SchemaFilter<FluentValidationRules>();
                c.OperationFilter<FluentValidationOperationFilter>();
                
                // XML documentation file
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var commentsFileName = assemblyName.Name + ".xml";
                var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                c.IncludeXmlComments(commentsFile);
            });

            // Add swagger examples
            services.AddSwaggerExamplesFromAssemblyOf(typeof(BadRequestExample), type);

            // Enums as strings
            services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }

        public static IApplicationBuilder ConfigureSharedSwagger(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.'Method 'Apply' in type 'Swashbuckle.AspNetCore.Filters.ExamplesOperationFilter
            app.UseSwagger(c =>
                // Add host
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"https://{httpReq.Host.Value}{httpReq.PathBase}" } };
                })
            );

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", string.Empty);
                c.RoutePrefix = string.Empty; // Serve the Swagger UI at the app's root
            });

            return app;
        }
    }
}
