namespace Cine_API.CTD
{
    public record class GetMovies(
         int MovieId,
         string MovieName,
         int Length,
         int DirectorId,
         bool IsNational,
         string MovieImg
    );
}
