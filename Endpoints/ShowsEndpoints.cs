using Api_Cine.Dtos;
using Cine_API.Data;
using Cine_API.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Cine_API.Endpoints
{
    public static class ShowsEndpoints
    {
        public static RouteGroupBuilder MapShowsEndpoint(this WebApplication app)
        {
            var showsGroup = app.MapGroup("shows");
            var getShowEndpoint = "GetShowEndpoint";
            //GET
            showsGroup.MapGet("/",async (MovieTheaterContext dbContext) =>
            {
                var shows = await dbContext.Shows
                .Include(show=> show.Movie)
                .Include(show=> show.Movie!.Director)
                .Select(show=> show.ToGetDto())
                .AsNoTracking().ToListAsync();
                return Results.Ok(shows);
            }).WithName(getShowEndpoint);

            //POST
            showsGroup.MapPost("/",async (AddShows newShow,MovieTheaterContext dbContext) =>
            {
                Show show = newShow.ToAddEntity();
                show.Movie = Movie.FindMovie(dbContext, show.MovieId);
                if (show.Movie == null)
                {
                    return Results.BadRequest("MovieId incorrect");
                }
                var shows = await dbContext.Shows.Include(show => show.Movie).ToListAsync();
                if (Show.ValidatePrice(show.Price) && Show.ValidateDate(show.Date))
                {
                    if (Show.ShowQuantityVerification(show, shows)) {
                        dbContext.Shows.Add(show);
                        await dbContext.SaveChangesAsync();
                        return Results.CreatedAtRoute(getShowEndpoint,value:show.ToDetailsDto());
                    }
                    else
                    {
                        return Results.BadRequest("Movie limit reached");
                    }
                }
               return Results.BadRequest("Price or date under the permitted values.");
            });

            //PUT 
            showsGroup.MapPut("/{showId}",async (int showId, PutShows showEdit, MovieTheaterContext dbContext) =>
            {
                var showsList = await dbContext.Shows.Include(show=> show.Movie).ToListAsync();
                var show = showsList.Find(show => show.ShowId == showId);
                if (show == null)
                {
                    return Results.NotFound("ShowId incorrect");
                }
                if (Show.ValidatePrice(showEdit.Price) && Show.ValidateDate(showEdit.Date))
                {
                    if (Show.ShowSameDateVerification(showEdit.Date, show.Date))
                    {
                        show.Date = showEdit.Date;
                        show.Price = showEdit.Price;
                        await dbContext.SaveChangesAsync();
                        return Results.NoContent();
                    }
                    else
                    {
                        show.Date = showEdit.Date;
                        show.Price = showEdit.Price;
                        if (Show.ShowQuantityVerification(show, showsList))
                        {
                            await dbContext.SaveChangesAsync();
                            return Results.NoContent();
                        }
                        else
                        {
                            return Results.BadRequest("Movie limit reached");
                        }
                    }
                }
                return Results.BadRequest("Price or date under the permitted values.");
            });
            //DELETE
            showsGroup.MapDelete("/{showId}",async (int showId, MovieTheaterContext dbContext) =>
            {
                await dbContext.Shows.Where(show => show.ShowId == showId).ExecuteDeleteAsync();
                return Results.NoContent();
            });
            return showsGroup;
        }
    }
}
