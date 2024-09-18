namespace Cine_API.Dtos
{
    public record class GetShows(
        int ShowId,
        decimal Price,
        int MovieId,
        string MovieName,
        int DirectorId,
        string DirectorName,
        bool IsNational ,
        int Length,
        DateTime Date);
}
