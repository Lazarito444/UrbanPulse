using Microsoft.OpenApi;

namespace UrbanPulse.Api.Extensions;

public static class IServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection SetupApi()
        {
            services.SetupOpenApi();
            return services;
        }
        private IServiceCollection SetupOpenApi()
        {
            return services.AddOpenApi(opt =>
            {
                opt.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Title = "UrbanPulse API",
                        Version = "v1",
                        Description = "API responsible for managing UrbanPulse",
                        Contact = new OpenApiContact
                        {
                            Name = "Ariel Lázaro (@Lazarito444)",
                            Email = "ariellazaro444@gmail.com",
                            Url = new Uri("https://github.com/Lazarito444/")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }
                    };

                    return Task.CompletedTask;
                });
            });
        }
    }
}
