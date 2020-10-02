using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Onion.WebApi.Swagger
{
    public static class Extensions
    {
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        {

            SwaggerOptions options = new SwaggerOptions();
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                services.Configure<SwaggerOptions>(configuration.GetSection("swagger"));

            

                configuration.GetSection(SwaggerOptions.Position).Bind(options);
            }
            services.AddSwaggerDocument(config => {
                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT token"));
                config.AddSecurity("JWT token", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    Description = "Copy 'Bearer ' + valid JWT token into field",
                    In = OpenApiSecurityApiKeyLocation.Header
                });
                config.PostProcess = (document) =>
                {
                    document.Info.Version = options.Version;
                    document.Info.Title = options.Title;
                    document.Info.Description = options.Title;
                };
            });



          
            return services;




        }

     
    }
}