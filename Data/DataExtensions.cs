using Microsoft.EntityFrameworkCore;

namespace Cine_API.Data
{
    public static class DataExtensions
    {
        public static async Task MigrateDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<MovieTheaterContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
