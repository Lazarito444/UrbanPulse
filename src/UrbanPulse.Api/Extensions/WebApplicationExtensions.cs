using Microsoft.EntityFrameworkCore;
using UrbanPulse.Infrastructure.Contexts;

namespace UrbanPulse.Infrastructure.Extensions;

public static class WebApplicationExtensions
{
    extension(WebApplication app)
    {
        public WebApplication ApplyMigrations()
        {
            using IServiceScope scope = app.Services.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
            return app;
        }
    }
}
