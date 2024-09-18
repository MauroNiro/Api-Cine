using Cine_API.Data;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Cine_API.Endpoints
{
    public static class DirectorEndpoints
    {
        public static RouteGroupBuilder MapDirectorsEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("directors");
            //GET movies
            group.MapGet("/", async (MovieTheaterContext dbContext) => 
            await dbContext.Directors
                       .Select(director => director.ToDto())
                       .AsNoTracking()
                       .ToListAsync());
            group.MapGet("/{directorId}", async (int directorId, MovieTheaterContext dbContext) =>
            {
                var director = await dbContext.Directors.FindAsync(directorId);
                if (director == null)
                    return Results.BadRequest("DirectorId doesn't exist");
                return Results.Ok(director.ToDto());
            });
                
            return group;
        }
    }
}
