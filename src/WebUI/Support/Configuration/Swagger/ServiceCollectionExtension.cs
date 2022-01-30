using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using WeeloApi.WebUI.Filters;

namespace WeeloApi.WebUI.Support.Configuration.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtension
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="services"></param>
       /// <returns></returns>
        public static IServiceCollection ConfigureSwaggerDocument(this IServiceCollection services)
        {
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = Configuration.SwaggerConfiguration.Version1,
                    Title = Configuration.SwaggerConfiguration.Title,
                    Description = Configuration.SwaggerConfiguration.Description,
                    TermsOfService = new Uri(Configuration.SwaggerConfiguration.TermsOfService),
                    Contact = new OpenApiContact
                    {
                        Name = Configuration.SwaggerConfiguration.ContactName,
                        Email = Configuration.SwaggerConfiguration.ContactEmail,
                        Url = new Uri(Configuration.SwaggerConfiguration.ContactUrl)
                    },
                });
                c.OperationFilter<FileOperationFilter>();
               
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    
                });
                c.OperationFilter<AuthenticationRequirementsOperationFilter>();
                // configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
                //var xmlFileDocumentationName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlFileDocumentationPath = Path.Combine(AppContext.BaseDirectory, xmlFileDocumentationName);
                //c.IncludeXmlComments(xmlFileDocumentationPath);
                // Adding the xml documentation of the Main project
                var xmlFileDocumentationName = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                  var xmlFileDocumentationPath = Path.Combine(AppContext.BaseDirectory, xmlFileDocumentationName);
                  c.IncludeXmlComments(xmlFileDocumentationPath, true);

                // Adding the xml documentation of the Sub project
                xmlFileDocumentationPath = Path.Combine(AppContext.BaseDirectory, "WeeloApi.Infrastructure.xml");
                c.IncludeXmlComments(xmlFileDocumentationPath, true);
                xmlFileDocumentationPath = Path.Combine(AppContext.BaseDirectory, "WeeloApi.Application.xml");
                c.IncludeXmlComments(xmlFileDocumentationPath, true);
                xmlFileDocumentationPath = Path.Combine(AppContext.BaseDirectory, "WeeloApi.Domain.xml");
                c.IncludeXmlComments(xmlFileDocumentationPath, true);
                c.EnableAnnotations();
            });

            return services;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }
    }
}
