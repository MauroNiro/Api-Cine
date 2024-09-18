using Cine_API.Data;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Cine_API.Endpoints
{
    public static class MoviesEndpoints
    {
       
        public static RouteGroupBuilder MapMoviesEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("movies");
            //GET movies
            group.MapGet("/",async (MovieTheaterContext dbContext) =>
                await dbContext.Movies
                       .Select(movie => movie.ToDto())
                       .AsNoTracking()
                       .ToListAsync());
            return group;
        }
    }
}
