using Api_Cine.Dtos;
using Cine_API.Dtos;
using Cine_API.Entities;

namespace GameStore.Api.Mapping;

public static class ShowMapping
{
    public static Show ToAddEntity(this AddShows show)
    {
        return new Show()
        {
            Price = show.Price,
            MovieId = show.MovieId,
            Date = show.Date     
        };
}

    public static Show ToPutEntity(this PutShows show, int showId)
    {
        return new Show()
        {
            ShowId = showId,
            Price = show.Price,
            Date = show.Date
        };
    }    
    public static ShowsDetails ToDetailsDto(this Show show)
    {
        return new ShowsDetails(
            show.ShowId,
            show.Price,
            show.MovieId,
            show.Date);
    }
    public static GetShows ToGetDto(this Show show)
    {
        return new(
            show.ShowId,
            show.Price,
            show.MovieId,
            show.Movie!.MovieName,
            show.Movie!.Director!.DirectorId,
            show.Movie!.Director!.DirectorName,
            show.Movie!.IsNational,
            show.Movie!.Length,
            show.Date
        );
    }
}
