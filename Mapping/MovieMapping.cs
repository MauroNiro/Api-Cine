using Cine_API.CTD;
using Cine_API.Entities;

namespace GameStore.Api.Mapping;

public static class MovieMapping
{
    public static GetMovies ToDto(this Movie movie)
    {
        return new GetMovies(
            movie.MovieId, 
            movie.MovieName,
            movie.Length,
            movie.DirectorId,
            movie.IsNational,
            movie.MovieImg);
    }
}
